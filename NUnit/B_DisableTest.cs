using log4net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDemo.TestDemo
{
    [TestFixture]
    public class DisableTest
    {
        private static readonly ILog Log =
           LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Test,Ignore("Test ignore")]
        public void TestMethod01()
        {
            Log.Info("Hello from TestMethod01");
        }

        [Test]
        public void TestMethod02()
        {
            Log.Info("Hello from TestMethod02");
        }

        [Test]
        public void TestMethod04()
        {
            Log.Info("Hello from TestMethod04");
        }

        [Test]
        public void TestMethod03()
        {
            Log.Info("Hello from TestMethod03");
        }
    }
}
