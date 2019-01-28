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
    public class B_HeadlessBrowser
    {
        IWebDriver driver;
        ICapabilities browserCap;
        String browserName;
        String browserType = "firefox";
        String headlessBrowser = "true";

        [Test]
        public void TestMethod()
        {
            if (browserType.Contains("chrome"))
            {
                //Headless browser will execute script without GUI interference
                if (headlessBrowser.Equals("true"))
                {
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--headless", "--disable-gpu");
                    driver = new ChromeDriver(options);
                }
                else
                {
                    driver = new ChromeDriver();
                }
            }
            else if (browserType.Contains("firefox"))
            {
                //System.Environment(FirefoxDriver.SystemProperty.BROWSER_LOGFILE, "/dev/null");
                if (headlessBrowser.Equals("true"))
                {
                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArguments("--headless", "--disable-gpu");
                    driver = new FirefoxDriver(options);
                }
                else
                {
                    driver = new FirefoxDriver();
                }
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
