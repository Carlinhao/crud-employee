using System;
using System.Data;

namespace employers.infrastructure.DbConfiguration.Interfaces
{
    public interface IDapperWrapper : IDisposable
    {
        IDbConnection GetConnection();
    }
}
