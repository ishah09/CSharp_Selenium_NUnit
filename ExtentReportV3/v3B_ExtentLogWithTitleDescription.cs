using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;

namespace NUnitDemo.ExtentReportV4
{
    [TestFixture]
    public class V3B_ExtentLogWithTitleDescriptionV3B_ExtentLogWithTitleDescription
    {
        [Test]
        public void TestMethod()
        {
            //To create report object
            var htmlReporter = new ExtentV3HtmlReporter("E:\\" + this.GetType().Name + ".html");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            ExtentTest testlog;

            //Represents HTML log
            testlog = extent.CreateTest("Test Log Method-2", "<br/>"
                + "Lorem Ipsum is simply dummy text of the printing and typesetting industry." + "<br/><br/>"
                + "<b>Where can I get some?</b>" + "<br/>"
                + "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.");
            testlog.Log(Status.Info, "This is Info log");
            testlog.Log(Status.Pass, "This is Pass log");
            testlog.Log(Status.Fail, "This is Fail log");

            testlog = extent.CreateTest("Test log with Extent Color");
            testlog.Log(Status.Info, MarkupHelper.CreateLabel("This is Info log", ExtentColor.Orange));
            testlog.Log(Status.Pass, MarkupHelper.CreateLabel("This is pass log", ExtentColor.Cyan));

            //If flush method did not call, Report will not generate.
            extent.Flush();
        }
    }
}
