using BusinessObjects.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Finap_Test_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            LoadConfigurations(services);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(_ => true).AllowCredentials());
            });


            #region Swagger

            var key = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            //services.AddSwaggerGen(option =>
            //{
            //    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //    {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer",
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            //    });
            //    option.AddSecurityRequirement(new OpenApiSecurityRequirement
            //         {
            //             {
            //                   new OpenApiSecurityScheme
            //                     {
            //                         Reference = new OpenApiReference
            //                         {
            //                             Type = ReferenceType.SecurityScheme,
            //                             Id = "Bearer"
            //                         }
            //                     },
            //                     new string[] {}
            //             }
            //         });

            //});


            #endregion


        }

        private void LoadConfigurations(IServiceCollection services)
        {
            AppSettings.ConnectionString = Configuration.GetSection("Appsettings:ConnectionString").Value;
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });

        //    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        //app.UseSwagger();
        //        //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CrudOperations v1"));
        //    }

        //    app.UseHttpsRedirection();

        //    app.UseRouting();

        //    app.UseAuthorization();
        //    app.UseCors("AllowAllOrigins");

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //    });
        //}
















    }
}
}
