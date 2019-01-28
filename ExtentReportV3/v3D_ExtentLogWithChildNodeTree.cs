using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace NUnitDemo.ExtentReportV4
{
    [TestFixture]
    public class V3C_ExtentLogWithChildNodes
    {
        [Test]
        public void TestMethod()
        {
            //To create report object
            var htmlReporter = new ExtentV3HtmlReporter("E:\\" + this.GetType().Name + ".html");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            ExtentTest testlog;
            ExtentTest childLog;

            testlog = extent.CreateTest("Test log with Child nodes");
            testlog.Log(Status.Info, MarkupHelper.CreateLabel("This is Info log", ExtentColor.Orange));
            testlog.Log(Status.Pass, MarkupHelper.CreateLabel("This is pass log", ExtentColor.Cyan));

            //Child test node to integrate with Parent test
            childLog = testlog.CreateNode("Childnode-1");
            childLog.Info("This is Info log");
            childLog.Pass("This is Pass log");
            childLog.Fail("This is Fail log");

            childLog = childLog.CreateNode("Childnode-2");
            childLog.Info("This is Info log");
            childLog.Pass("This is Pass log");

            childLog = testlog.CreateNode("Childnode-3");
            childLog.Info("This is Info log");
            childLog.Pass("This is Pass log");
            childLog.Warning("This is Warning log");

            extent.Flush();
        }
    }
}
