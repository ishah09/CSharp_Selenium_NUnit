using log4net;
using NUnit.Framework;
using System;
using System.Configuration;

namespace NUnitDemo.SeleniumCommonTech
{
    [TestFixture]
    public class D_ConfigReader
    {
        private static readonly ILog Log =
           LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Test]
        public void TestMethod()
        {
            //To use ConfigurationManager class, it will be needed to add System.Configuration dll
            String language = ConfigurationManager.AppSettings["Language"];
            String selenium = ConfigurationManager.AppSettings["Selenium"];

            Log.Info("String language:" + language);
            Log.Info("String selenium:" + selenium);
        }    
    }
}

