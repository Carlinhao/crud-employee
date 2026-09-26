using employers.infrastructure.DbConfiguration.Interfaces;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace employers.infrastructure.DbConfiguration.Implementation;

[ExcludeFromCodeCoverage]
public class DapperWrapper(IDbConnection dbConnection) : IDapperWrapper
{
    private bool _disposed = false;

    public IDbConnection GetConnection()
    {
        return dbConnection;
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
            if (dbConnection.State != ConnectionState.Closed)
                dbConnection.Close();

            dbConnection.Dispose();
        }

        _disposed = true;
    }
}
