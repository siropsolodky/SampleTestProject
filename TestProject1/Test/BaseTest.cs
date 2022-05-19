using NUnit.Framework;

namespace TestProject1.Test
{
    [Parallelizable(ParallelScope.All)]
    public abstract class BaseTest
    {
        protected string _serviceBaseAddress;

        [SetUp]
        public void Setup()
        {
            _serviceBaseAddress = TestContext.Parameters.Get("serviceBaseAddress", "https://reqres.in");
        }

    }
}
