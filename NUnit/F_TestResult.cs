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
    public class TestResult
    {
        private static readonly ILog Log =
           LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Test]
        public void TestMethod()
        {
            int temp = 5;                       
            Log.Info("Division Formula :" + temp / 0);
        }

        [TearDown]
        public void TestResultCheck()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString() == "Failed")
            {
                Log.Info("TestContext.Message = " + TestContext.CurrentContext.Result.Message);
                Log.Info("TestContext.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status.ToString() == "Passed")
            {
                Log.Info("TestContext.Status = " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
            }
            else
            {
                Log.Info("Undefined TestContext.Status = " + TestContext.CurrentContext.Result.Outcome.Status.ToString());
            }
        }
    }
}
