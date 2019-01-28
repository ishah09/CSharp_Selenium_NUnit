using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace NUnitDemo.SeleniumCommonTech
{
    [TestFixture]
    public class A_CrossBrowser
    {
        IWebDriver driver;
        ICapabilities browserCap;
        String browserName;
        String browserType = "chrome";
        readonly String headlessBrowser = "false";

        [Test]
        public void TestMethod()
        {
            if (browserType.Contains("chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browserType.Contains("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if (browserType.Contains("edge"))
            {
                driver = new EdgeDriver();
            }

            //To define driver properties
            browserCap = ((RemoteWebDriver)driver).Capabilities;
            browserName = browserCap.GetCapability("browserName").ToString();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Cookies.DeleteAllCookies();

            driver.Url = "http://google.com";
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
