using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDemo.ExtentReportV4
{
    [TestFixture]
    public class E_extentLogwithScreenshot
    {
        [Test]
        public void TestMethod()
        {           
            //Chrome Driver should be installed in your System
            IWebDriver driver = new ChromeDriver();
            driver.Url="http://google.com";

            // Report will generate in Project Directory only.
            // After execution, refresh project directory.
            
            ExtentV3HtmlReporter htmlreport = new ExtentV3HtmlReporter("E:\\Tests.html");
            ExtentReports reports = new ExtentReports();
            reports.AttachReporter(htmlreport);

            // This is the object of extentTest class, by which log is generate.
            ExtentTest testlog;

            //This is Light theme of report
            htmlreport.Config.Theme = Theme.Standard;    

            testlog = reports.CreateTest("Test log with Extent Color");
            testlog.Log(Status.Info, MarkupHelper.CreateLabel("This is Info log", ExtentColor.Orange));
            testlog.Log(Status.Pass, MarkupHelper.CreateLabel("This is pass log", ExtentColor.Cyan));

            //To take screenshot
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            //To save screenshot
            file.SaveAsFile("E:\\SSName" + ".png", ScreenshotImageFormat.Png);
            //To log screenshot
            testlog.Info("Details with Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath("E:\\SSName" + ".png").Build());
            
            // If flush method did not call, Report will not generate.
            reports.Flush();
            driver.Quit();
        }
    }
}
