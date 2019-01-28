using Microsoft.Expression.Encoder.ScreenCapture;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnitDemo.SeleniumCommonTech
{
    [TestFixture]
    public class C_TestRecorder
    {
        String scriptRecording = "true";
        ScreenCaptureJob scj;

        [Test]
        public void TestMethod()
        {
            if (scriptRecording.Equals("true"))
            {
                scj = new ScreenCaptureJob();
                scj.OutputScreenCaptureFileName = "E:\\" + this.GetType().Name + ".avi";
                scj.Start();
            }

            Thread.Sleep(3000);
            scj.Stop();
        }
    }
}
