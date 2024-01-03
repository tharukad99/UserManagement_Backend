using System;
using System.Data.Common;

namespace DataAccessLayer
{
    public abstract class IDataService : IDisposable
    {
        public abstract void BeginTransaction();
        public abstract void CommitTransaction();
        public abstract void RollbackTransaction();
        public abstract void CloseConnection();
        public abstract int ExecuteNonQuery(string spName, DbParameter[] sqlParameters, int? timeout = null);
        public abstract DbDataReader ExecuteReader(string spName, DbParameter[] sqlParameters, int? timeout = null);
        public abstract object ExecuteScalar(string spName, DbParameter[] sqlParameters);
        public abstract void Dispose();
    }
}
