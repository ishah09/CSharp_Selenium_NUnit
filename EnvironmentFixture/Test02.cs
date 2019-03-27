using NUnit.Framework;
using NUnitDemo.EnvironmentFixture;
using System.Threading;

namespace NUnitDemo.ParallelTestExecution
{
    [TestFixture]
    public class Test02 : BaseClass
    {
        [Test]
        public void TestMethod()
        {
            driver.Url = "http://gmail.com";
            Thread.Sleep(3000);

            // TODO: Add your test code here
            var answer = 43;
            Assert.That(answer, Is.GreaterThan(42), "Some useful error message");
        }
    }
}
