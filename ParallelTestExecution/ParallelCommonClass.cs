using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitDemo.ParallelTestExecution
{   
    public class ParallelCommonClass
    {
        public IWebDriver driver;

       public ParallelCommonClass()
        {
            driver = new ChromeDriver();
        }
    }
}
