using System;

namespace employer.repository.tests.Base
{
    public abstract class BaseTest
    {
        public BaseTest() {}
    }

    public class DbTest : IDisposable
    {

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
