using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDemo.ExtentReportV4
{
    [TestFixture]
    public class C_ExtentLogsWithChildNode
    {
        [Test]
        public void TestMethod()
        {
            //To create report object
            var htmlReporter = new ExtentHtmlReporter("E:\\Test.html");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            ExtentTest testlog;
            ExtentTest childLog;

            testlog = extent.CreateTest("Test log with Child node");
            testlog.Log(Status.Info, MarkupHelper.CreateLabel("This is Info log", ExtentColor.Orange));
            testlog.Log(Status.Pass, MarkupHelper.CreateLabel("This is pass log", ExtentColor.Cyan));

            //Child test node to integrate with Parent test
            childLog = testlog.CreateNode("Childnode-1");
            childLog.Info("This is Info log");
            childLog.Pass("This is Pass log");
            childLog.Fail("This is Fail log");

            extent.Flush();
        }
    }
}
