using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;
using System.IO;

namespace NUnitDemo.ExtentReportV4
{
    [TestFixture]
    public class V3A_SimpleExtentLogs
    {
        [Test]
        public void TestMethod()
        {
            //To create report object
            var htmlReporter = new ExtentV3HtmlReporter("E:\\" + this.GetType().Name + ".html");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            ExtentTest extentTest;

            //To define system info
            extent.AddSystemInfo("Host Name", "Web Portal");
            extent.AddSystemInfo("Environment", "Automation Testing");
            extent.AddSystemInfo("User Name", "QA Automation");

            //To define system config
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.CSS = "";
            htmlReporter.Config.ReportName = "This is Report name";
            htmlReporter.Config.DocumentTitle = "This is Document Title";

            //Create simple logs 
            extentTest = extent.CreateTest("Simple Logs", "<i>This is simple log description.</i>");
            extentTest.Info("This is Info Log");
            extentTest.Pass("This is Pass Log");
            extentTest.Fail("This is Fail Log");
            extentTest.Fatal("This is Fatal Log");
            extentTest.Warning("This is Warning Log");

            //Create simple logs by another way 
            extentTest = extent.CreateTest("Detail Logs");
            extentTest.Log(Status.Info, "This is Info Log");
            extentTest.Log(Status.Fail, "This is Fail Log");
            extentTest.Log(Status.Pass, "This is Pass Log");
            extentTest.Log(Status.Skip, "This is Skip Log");
            extentTest.Log(Status.Debug, "This is Debug Log");
            extentTest.Log(Status.Error, "This is Error Log");
            extentTest.Log(Status.Fatal, "This is Fatal Log");
            extentTest.Log(Status.Warning, "This is Warning Log");

            //Create markup logs
            extentTest = extent.CreateTest("Markup Logs");
            extentTest.Info(MarkupHelper.CreateLabel("This is Info Log", ExtentColor.Amber));
            extentTest.Pass(MarkupHelper.CreateLabel("This is Pass Log", ExtentColor.Indigo));
            extentTest.Fail(MarkupHelper.CreateLabel("This is Fail Log", ExtentColor.Purple));
            extentTest.Fatal(MarkupHelper.CreateLabel("This is Fatal Log", ExtentColor.Transparent));
            extentTest.Warning(MarkupHelper.CreateLabel("This is Warning Log", ExtentColor.Lime));

            extent.Flush();

            double per = extent.Stats.ParentPercentageFail + extent.Stats.ChildPercentageFail;
            string testStatus = "";

            if (per > 0)
                testStatus = "Fail";
            else
                testStatus = "Pass";

            string date = DateTime.Now.ToString("dd-MM-yyyy");
            String result = this.GetType().Name + "\t" + testStatus + "\t" + htmlReporter.StartTime.TimeOfDay + "\t" + htmlReporter.EndTime.TimeOfDay;

            if (!File.Exists("E:/" + date + ".html"))
            {
                result = "<table border='1'>"
                        + "<col width = '600'>" + "<col width = '60'>" + "<col width = '200'>" + "<col width = '200'>"
                        + "<tr> <td colspan=4> <h1 align = 'center'> Automation Script Test Report for the Day</h1></td></tr>"
                        + "<tr>"
                        + "<th align='left'>TestName</th>"
                        + "<th align='left'>Status</th>"
                        + "<th align='left'>StartTime</th>"
                        + "<th align='left'>EndTime</th>"
                        + "</tr>";
                File.AppendAllText("E:/" + date + ".html", result + Environment.NewLine);
            }

            result = "<tr>"
                    + "<td>" + this.GetType().Name + "</td>"
                    + "<td>" + testStatus + "</td >"
                    + "<td>" + htmlReporter.StartTime.TimeOfDay + "</td>"
                    + "<td>" + htmlReporter.EndTime.TimeOfDay + "</td>"
                    + "</tr>";

            File.AppendAllText("E:/" + date + ".html", result + Environment.NewLine);
        }
    }
}

