using NUnit.Framework;
using System.Threading;

namespace NUnitDemo.ParallelTestExecution
{
    [TestFixture]
    [Parallelizable]
    public class ParallelTest01 : ParallelCommonClass
    { 
        [SetUp]
        public void testsetup()
        {
            driver.Url = "http://google.com";
        }

        [Test]
        public void TestMethod()
        {
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
            driver.Url = "http://map.google.com";
            Thread.Sleep(3000);
        }

        [Test]
        public void Testsecondmethod()
        {
            driver.Url = "http://web.skype.com";
            Thread.Sleep(3000);
        }
    }
}
