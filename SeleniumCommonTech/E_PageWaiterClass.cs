using OpenQA.Selenium;
using System.Threading;

namespace NUnitDemo.SeleniumCommonTech
{
   public class PageWaiterClass
    {
        IWebDriver driver;
        IJavaScriptExecutor js;

        public PageWaiterClass()
        {

            js = (IJavaScriptExecutor)driver;
        }

        #region To check page has been loaded with Javascript
        public bool DomHasLoaded(int timeout = 5)
        {
            var hasThePageLoaded = js.ExecuteScript("return document.readyState").ToString();
            while (hasThePageLoaded == null || (hasThePageLoaded != "complete" && timeout > 0))
            {
                Thread.Sleep(500);
                timeout--;
                if (timeout != 0) continue;
                return false;
            }
            return true;
        }
        #endregion

        #region To check JQuery has been used in page
        public bool IsJqueryBeingUsed()
        {
            var isTheSiteUsingJQuery = js.ExecuteScript("return Window.jQuery != undefined");
            return (bool)isTheSiteUsingJQuery;
        }
        #endregion

        #region To check page has been loaded with Jquery
        public bool JqueryHasLoaded(int timeout = 5)
        {
            var hasTheJQueryLoaded = js.ExecuteScript("jQuery.active === 0");
            while (hasTheJQueryLoaded == null || (!(bool)hasTheJQueryLoaded && timeout > 0))
            {
                Thread.Sleep(100);
                timeout--;
                hasTheJQueryLoaded = js.ExecuteScript("jQuery.active === 0");
                if (timeout != 0) continue;
                return false;
            }
            return (bool)hasTheJQueryLoaded;
        }
        #endregion

        #region To check Angular has been used in page
        public bool AngularIsBeingUsed()
        {
            bool isTheSiteUsingAngular = (bool)js.ExecuteScript("return Window.angular === undefined");
            //string UsingAngular = @"if (Window.angular){return true;}";
            //var isTheSiteUsingAngular = js.ExecuteScript(UsingAngular);
            return isTheSiteUsingAngular;
        }
        #endregion

        #region To check page has been loaded with Angular
        public bool AngularHasLoaded(int timeout = 5)
        {
            string HasAngularLoaded =
                @"return (Window.angular !== undefined) && (angular.element(document.body).injector() !== undefined) && (angular.element(document.body).injector().get('$http').pendingRequests.length === 0)";
            var hasTheAngularLoaded = js.ExecuteScript(HasAngularLoaded);
            while (hasTheAngularLoaded == null || (!(bool)hasTheAngularLoaded && timeout > 0))
            {
                Thread.Sleep(200);
                timeout--;
                hasTheAngularLoaded = js.ExecuteScript(HasAngularLoaded);
                if (timeout != 0) continue;
                return false;
            }
            return (bool)hasTheAngularLoaded;
        }
        #endregion

        #region To check pahe has been loaded with JS, Jquery, Angular
        public void PageCallingUtility()
        {
            if (DomHasLoaded() == true)
            {
                if (IsJqueryBeingUsed() == true)
                {
                    JqueryHasLoaded();
                }

                if (AngularIsBeingUsed() == true)
                {
                    AngularHasLoaded();
                }
            }
        }
        #endregion
    }
}
