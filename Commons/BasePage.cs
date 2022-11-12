using AngleSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectBase.Commons
{
    public class BasePage
    {
        protected log4net.ILog Log;

        private IJavaScriptExecutor jsExecutor;

        private WebDriverWait driverWait;

        private Actions actions;

        public BasePage()
        {
            Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public string GetDynamicLocator(string locator, params string[] paramArray)
        {
            return String.Format(locator, paramArray);
        }

        public IWebElement GetWebElement(IWebDriver driver, By by)
        {
            return driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> GetWebElements(IWebDriver driver, By by)
        {
            return driver.FindElements(by);
        }

        public void SendKeyToElement(IWebDriver driver, By by, string value)
        {
            GetWebElement(driver, by).Clear();
            GetWebElement(driver, by).SendKeys(value);
        }

        public void ClickToElement(IWebDriver driver, By by)
        {
            GetWebElement(driver, by).Click();
        }

        public bool IsElementDisplayed(IWebDriver driver, By by)
        {
            return GetWebElement(driver, by).Displayed;
        }

        public void ClickToElementByJs(IWebDriver driver, By by)
        {
            jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", GetWebElement(driver, by));
        }

        public bool IsElementSelected(IWebDriver driver, By by)
        {
            return GetWebElement(driver, by).Selected;
        }

        public void CheckToCheckbox(IWebDriver driver, By by)
        {
            IWebElement checkbox = GetWebElement(driver, by);
            if (!checkbox.Selected)
                checkbox.Click();
        }

        public void UnCheckToCheckbox(IWebDriver driver, By by)
        {
            IWebElement checkbox = GetWebElement(driver, by);
            if (checkbox.Selected)
                checkbox.Click();
        }

        public bool IsElementUnDisplayed(IWebDriver driver, By by)
        {
            bool isElementUnDisplayed = true;

            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(by);
            if (webElements.Count > 0 && webElements[0].Displayed)
                isElementUnDisplayed = false;

            return isElementUnDisplayed;
        }

        public string GetElementText(IWebDriver driver, By by)
        {
            return GetWebElement(driver, by).Text;
        }

        public void ScrollToElement(IWebDriver driver, By by)
        {
            jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", GetWebElement(driver, by));
        }

        public void WaitForElementVisible(IWebDriver driver, By by)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings[GlobalConstants.LONG_TIME_OUT])));
            driverWait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitForElementToBeClickable(IWebDriver driver, By by)
        {
            driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings[GlobalConstants.LONG_TIME_OUT])));
            driverWait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public void ZoomPage(IWebDriver driver, int level)
        {
            jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript(String.Format("document.body.style.zoom='{0}%'", level));
        }
    }
}
