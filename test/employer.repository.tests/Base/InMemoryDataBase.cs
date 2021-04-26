using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.Data;

namespace employer.repository.tests.Base
{
    internal class InMemoryDataBase
    {
        private readonly OrmLiteConnectionFactory dbFactory =
        new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public IDbConnection DbConnection() => this.dbFactory.OpenDbConnection();
        public void Insert<T>(T item)
        {
            using var db = DbConnection();
            db.CreateTableIfNotExists<T>();
            db.Insert(item);           
        }
    }
}
