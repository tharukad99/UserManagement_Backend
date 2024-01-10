using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement_BusinessObjects.User;

namespace Authentication_System.DataAccessLayer
{
    //User registration and login Data Access Layer
    public class AuthenticationDataAccess : IAuthenticationDataAccess
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _mySqlConnection;

        IDataService _dataService;

        public AuthenticationDataAccess(IDataService dataService)
        {
            _dataService = dataService;
        }

        //This method use to user registration
        public async Task<Status> RegisterUser(User request)
        {
            Status status = new Status();
            User response = new User();

            try
            {
                byte[] encData_byte = new byte[request.Password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(request.Password);
                string encriptedPassword = Convert.ToBase64String(encData_byte);

                request.Password = encriptedPassword;

                DbParameter[] arrSqlParam = new DbParameter[9];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@UserID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, value: request.UserID);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@FirstName", System.Data.DbType.String, System.Data.ParameterDirection.Input, value: request.FirstName);
                arrSqlParam[2] = DataServiceBuilder.CreateDBParameter("@LastName", System.Data.DbType.String, System.Data.ParameterDirection.Input, request.LastName);
                arrSqlParam[3] = DataServiceBuilder.CreateDBParameter("@NIC", System.Data.DbType.String, System.Data.ParameterDirection.Input, request.NIC);
                arrSqlParam[4] = DataServiceBuilder.CreateDBParameter("@MobileNo", System.Data.DbType.String, System.Data.ParameterDirection.Input, request.MobileNo);
                arrSqlParam[5] = DataServiceBuilder.CreateDBParameter("@AddressLine1", System.Data.DbType.String, System.Data.ParameterDirection.Input, request.AddressLine1);
                arrSqlParam[6] = DataServiceBuilder.CreateDBParameter("@AddressLine2", System.Data.DbType.String, System.Data.ParameterDirection.Input, request.AddressLine2);
                arrSqlParam[7] = DataServiceBuilder.CreateDBParameter("@UserName", System.Data.DbType.String, System.Data.ParameterDirection.Input, request.UserName);
                arrSqlParam[8] = DataServiceBuilder.CreateDBParameter("@Password", System.Data.DbType.String, System.Data.ParameterDirection.Input, request.Password);

                _dataService.ExecuteNonQuery("[dbo].[InsertUser]", arrSqlParam);

                status.IsSuccess = true;
                status.Message = "User Create Success!";

            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = "Exception Occurs : " + ex.Message;
            }
            return status;
        }

        public async Task<Status> UserExist(string UserName)
        {
            Status status = new Status();
            User exsistUser = new User();

            DbParameter[] arrSqlParam = new DbParameter[1];
            arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@UserName", System.Data.DbType.String, System.Data.ParameterDirection.Input, value: UserName);
            DbDataReader reader = _dataService.ExecuteReader("[dbo].[ExistUser]", arrSqlParam);

            if (reader.HasRows)
            {
                exsistUser = new User();
                while (reader.Read())
                {
                    DataReader dataReader = new DataReader(reader);
                    exsistUser.UserID = dataReader.GetInt32("UserID");
                    exsistUser.UserName = dataReader.GetString("UserName");
                }
                reader.Close();
            }

            if(exsistUser.UserID == 0)
            {
                status.IsSuccess = false;
                status.Message = "User Not Exist";
            }
            else
            {
                status.IsSuccess = true;
                status.Message = "User Already Exist";
            }
            


            return status;
        }


         public User UserLogin(Login request)
        {
            User user = new User();
            try
            {
                byte[] encData_byte = new byte[request.Password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(request.Password);
                string encriptedPassword = Convert.ToBase64String(encData_byte);

                request.Password = encriptedPassword;

                DbParameter[] arrSqlParam = new DbParameter[2];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@UserName", System.Data.DbType.String, System.Data.ParameterDirection.Input, value: request.UserName);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@Password", System.Data.DbType.String, System.Data.ParameterDirection.Input, value: request.Password);
                DbDataReader reader = _dataService.ExecuteReader("[dbo].[Login]", arrSqlParam);

                if (reader.HasRows)
                {
                    user = new User();
                    while (reader.Read())
                    {      
                        DataReader dataReader = new DataReader(reader);
                        user.UserID = dataReader.GetInt32("UserID");
                        user.UserName = dataReader.GetString("UserName");                       
                    }
                    reader.Close();
                }
                var token = GenerateToken(user);

                user.Token = token;
                return user;
            }
            catch(Exception ex)
            {
                user.IsSuccess = false;
                user.Message = "Exception Occurs : " + ex.Message;
                return user;
            }   
        }

        //public static string Secret = "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08";

        public static string GenerateToken(User user)
        {
            string Secret = "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08";
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor


            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name , user.UserName.ToString()),
                    //new Claim(ClaimTypes.Role , user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

















        //------------------------------------------------------
        //This method use to get a JWT tocken
        public string GenerateJWT(string Username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: _configuration[key: "Jwt:Key"]));//(s: Configuration["Jwt:Key"])
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //claim is used to add identity to JWT token
            var claims = new[] {
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Sid, Username),
             //new Claim(JwtRegisteredClaimNames.Email, Password),
             new Claim("Date", DateTime.Now.ToString()),
             };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Audiance"],
              claims,    //null original value
              expires: DateTime.Now.AddMinutes(120),

              //notBefore:
              signingCredentials: credentials);

            string Data = new JwtSecurityTokenHandler().WriteToken(token); //return access token 
            return Data;
        }
    }
}
