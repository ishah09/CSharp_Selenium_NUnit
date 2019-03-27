using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NUnitDemo.SeleniumCommonTech
{   

    class GmailSearch
    {
        bool flagEmail = false;
        String testResult = "";

        IWebDriver driver;
        IJavaScriptExecutor js;
        ArrayList tabs;
        PageWaiterClass PageWaiter;
        WebDriverWait wait;

        #region To define DataAttributes

        //Gmail Sign in link
        public By gmailSignInLinkDA = By.XPath("//a[@class='gmail-nav__nav-link gmail-nav__nav-link__sign-in']");

        //Gmail login and password field
        public By loginEmailIDInputDA = By.XPath("//input[@id='identifierId']");
        public By loginEmailNextDA = By.XPath("//div[@id='identifierNext']");
        public By loginPasswordInputDA = By.XPath("//input[@name='password']");
        public By loginPasswordNextDA = By.XPath("//div[@id='passwordNext']");

        //Gmail search inputs
        public By gmailSearchInputDA = By.XPath("//input[@placeholder='Search mail']");
        public By gmailSearchButtonDA = By.XPath("//button[@aria-label='Search Mail']");
        public By gmailSearchResultDA = By.XPath("//div[@class='ae4 UI']//tr");

        //Search result attributes
        public By confirmResetPasswordSearchResult = By
                .XPath("//tr[@class='zA zE']//span[contains(text(),'Password Reset Instructions')]");
        public By gmailSearchResultForPasswordReset = By.CssSelector("div.xT>div.y6>span.bog");

        //Locate to delete email
        public By SelectElementMenuDA = By.XPath("//img[@role='menu']");
        public By deleteEmailDA = By.XPath("//*[text()='Delete this message']");
        public By deleteIcon = By.XPath("//div[@data-tooltip='Delete']//div[@class='ar9 T-I-J3 J-J5-Ji']");

        //Gmail Logout attributes
        public By gmailProfileLinkDA = By.XPath("//span[@class='gb_8a gbii']");
        public By logoutLinkDA = By.XPath("//a[@id='gb_71']");
        #endregion

        #region To initialize objects
        public GmailSearch()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            PageWaiter = new PageWaiterClass();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        #endregion

        #region To open Gmail-Login link
        public void Check()
        {
            try
            {
                //To open new tab
                js.ExecuteScript("window.open()");
                tabs = new ArrayList(driver.WindowHandles);
                driver.SwitchTo().Window(driver.WindowHandles[tabs.Count - 1]);

                //Assign Gmail link
                driver.Url = "https://mail.google.com/";

                //Check if pre-login link
                if (driver.Url.Equals("https://mail.google.com/mail/u/0/#inbox"))
                {
                    PageWaiter.PageCallingUtility();
                }
                //Check if about link opened
                else if (driver.Url.Contains("gmail/about/#"))
                {
                    driver.FindElement(gmailSignInLinkDA).Click();
                    PageWaiter.PageCallingUtility();
                    Login();
                }
                //Go for login if actual link opened
                else
                {
                    Login();
                }
            }
            catch (Exception)
            {
                PageWaiter.PageCallingUtility();

                //If exection raised, it will move on actual execution
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[tabs.Count - 2]);
            }
        }
        #endregion

        #region To enter credentials
        public void Login()
        {
            PageWaiter.PageCallingUtility();

            //To Enter email id and click next
            driver.FindElement(loginEmailIDInputDA).SendKeys("ishita@trivenitechnologies.in");
            js.ExecuteScript("arguments[0].click();", driver.FindElement(loginEmailNextDA));
            PageWaiter.PageCallingUtility();

            //To Enter password and click next
            driver.FindElement(loginPasswordInputDA).SendKeys("triveni@123");
            js.ExecuteScript("arguments[0].click();",
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(driver.FindElement(loginPasswordNextDA))));
            PageWaiter.PageCallingUtility();
        }
        #endregion

        #region Steps to search keyword in Gmail 
        public void SearchOperation(String findKey)
        {
            PageWaiter.PageCallingUtility();

            //To search given key
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(gmailSearchInputDA)).Clear();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(gmailSearchInputDA)).SendKeys(findKey);
            js.ExecuteScript("arguments[0].click();", driver.FindElement(gmailSearchButtonDA));
            PageWaiter.PageCallingUtility();

            //Trace key from filtered result
            IList<IWebElement> email = driver.FindElements(gmailSearchResultDA);
            PageWaiter.PageCallingUtility();

            for (int i = 1; i <= email.Count; i++)
            {
                PageWaiter.PageCallingUtility();

                //Compare keyword from filtered result
                if (driver.FindElement(By.XPath("//div[@class='ae4 UI']//tr['" + i + "']")).Text
                        .Contains(findKey) == true)
                {
                    //Keyword matched, So assigned flag True
                    testResult = "Email search key has been matched.";
                    flagEmail = true;
                    PageWaiter.PageCallingUtility();

                    //To Open email and take screenshots
                    js.ExecuteScript("arguments[0].click();", wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='ae4 UI']//tr['" + i + "']"))));
                    //SS.CalltakeScreenShot(findKey);
                    PageWaiter.PageCallingUtility();

                    //To open menu, for Deleting email
                    Actions obj1 = new Actions(driver);
                    obj1.MoveToElement(driver.FindElement(SelectElementMenuDA)).Click().Perform();
                    PageWaiter.PageCallingUtility();

                    //Click on Delete option
                    IWebElement clickMenu = driver.FindElement(deleteEmailDA);
                    Actions obj2 = new Actions(driver);
                    obj2.MoveToElement(clickMenu).Click().Perform();
                    PageWaiter.PageCallingUtility();

                    //Check if email moved to traced or not
                    if (driver.FindElement(By.XPath("//span[contains(text(),'moved to Trash')]")).Displayed)
                    {
                        testResult = "Email moved to trash.";
                    }
                    break;
                }
            }
        }
        #endregion

        #region Scenario to search keyword in Gmail
        public void SearchKey(String findKey)
        {
            try
            {
                SearchOperation(findKey);
                //If email found and flag got True, It will pass details for log
                if (flagEmail == true)
                {
                    testResult = "Email is Matched.";
                }
                else
                {
                    testResult = "Email is not Matched.";

                    SearchOperation(findKey);

                    if (flagEmail == true)
                        testResult = "Email is Matched.";
                    else
                        testResult = "Email is not Matched again.";
                }
                PageWaiter.PageCallingUtility();
            }
            catch (Exception)
            { }
            finally
            {
                PageWaiter.PageCallingUtility();
                driver.Close();

                //Block of code prevention from Edge browser popup
                //if (browserType.Equals("edge"))
                //{
                //    try
                //    {
                //        js.ExecuteScript("$(Window).off('beforeunload');");
                //    }
                //    catch (Exception)
                //    { }
                //}
                driver.SwitchTo().Window(driver.WindowHandles[tabs.Count - 2]);
            }
        }
        #endregion
    }

    [TestFixture]
    class TestGmailInbox : GmailSearch
    {
        [Test]
        public void TestKeywordInGmail()
        {
            Check();
            SearchKey("Selenium");
        }
    }
}
