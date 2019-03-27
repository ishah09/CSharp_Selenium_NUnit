using Microsoft.Expression.Encoder.ScreenCapture;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
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
                string path = "E:\\" + this.GetType().Name + ".avi";
                scj.OutputScreenCaptureFileName = path;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                scj.Start();
            }

            Thread.Sleep(3000);
            scj.Stop();
        }
    }
}
