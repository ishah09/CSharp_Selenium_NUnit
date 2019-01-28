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
    public class BasicTestAttributes
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region This method will call single time before text execution
        [OneTimeSetUp]
        public void SetupTestExecution()
        {
            Log.Info("This is initial call.");
        }
        #endregion

        #region This method will call before each test method
        [SetUp]
        public void BeforeTestExecution()
        {
            Log.Info("This is call before each test execution.");
        }
        #endregion

        #region This method is actual test method-1
        [Test]
        public void TestMethod()
        {
            Log.Info("This is call from TestExecution method-1");
        }
        #endregion

        #region This method is actual test method-2
        [Test]
        public void TestMethod2()
        {
            Log.Info("This is call from TestExecution method-2");
        }
        #endregion

        #region This method will call after each test method
        [TearDown]
        public void AfterTestExecution()
        {
            Log.Info("This is call from after TestExecution");
        }
        #endregion

        #region This method will call single time after actual test
        [OneTimeTearDown]
        public void QuitTestExecution()
        {
            Log.Info("This is Quit call.");
        }
        #endregion
    }
}
