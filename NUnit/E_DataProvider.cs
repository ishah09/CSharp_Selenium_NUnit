using log4net;
using NUnit.Framework;
using System;

namespace NUnitDemo.TestDemo
{
    [TestFixture]
    public class DataProvider
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region To define test data
        public static object[] TestData =
        {
          new object[] {"1", "India", "Mumbai", },
          new object[] {"2", "India", "Pune", },
          new object[] {"3", "India", "Banglore ", },
          new object[] {"4", "India", "Hydbad", },
          new object[] {"5", "India", "Gujarat", },
        };
        #endregion

        #region To retrieve Login Test data from data provider
        static readonly object[] GetTestData = TestData;
        #endregion

        [TestCaseSource("GetTestData")]
        public void TestMethod(String firstCol, String secondCol, String thirdCol)
        {
            Log.Info("First Column : " + firstCol + "\nSecond Column : " + secondCol + "\nThird Column : " + thirdCol);
        }
    }
}
