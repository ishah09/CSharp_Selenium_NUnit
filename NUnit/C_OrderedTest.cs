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
    public class OrderedTest
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Test,Order(1)]
        public void TestMethod01()
        {
            Log.Info("Hello from TestMethod01");
        }

        [Test, Order(2)]
        public void TestMethod02()
        {
            Log.Info("Hello from TestMethod02");
        }

        [Test, Order(3)]
        public void TestMethod04()
        {
            Log.Info("Hello from TestMethod04");
        }

        [Test, Order(4)]
        public void TestMethod03()
        {
            Log.Info("Hello from TestMethod03");
        }
    }
}
