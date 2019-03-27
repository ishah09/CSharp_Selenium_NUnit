using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitDemo.EnvironmentFixture
{    
    [SetUpFixture]
    [Parallelizable]
    public class BaseClass
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void setupMethod()
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void terminateMethod()
        {            
            driver.Quit();

            Assert.Pass("Test success");
        }
    }
}
