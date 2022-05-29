using employers.infrastructure.DbConfiguration.Interfaces;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace employers.infrastructure.DbConfiguration.Implementation
{
    [ExcludeFromCodeCoverage]
    public class DapperWrapper : IDapperWrapper
    {
        private bool _disposed = false;
        private readonly IDbConnection _dbConnection;

        public DapperWrapper(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IDbConnection GetConnection()
        {
            return _dbConnection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_dbConnection.State != ConnectionState.Closed)
                    _dbConnection.Close();

                _dbConnection.Dispose();
            }

            _disposed = true;
        }
    }
}
