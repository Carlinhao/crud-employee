using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace employers.infrastructure.DbConfiguration.Interfaces
{
    [ExcludeFromCodeCoverage]
    public interface IDapperWrapper : IDisposable
    {
        IDbConnection GetConnection();
    }
}
