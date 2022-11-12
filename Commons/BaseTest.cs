using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectBase.DriverConfig;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectBase.Commons
{
    public class BaseTest
    {

        protected IWebDriver driver;

        protected static ILog Log { get; set; } = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseTest()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void SetupDriver()
        {
            //Console.WriteLine("Console: ConfigurationManager.AppSettings[GlobalConstants.BROWSER].ToUpper(): " + ConfigurationSettings.AppSettings[GlobalConstants.BROWSER].ToUpper());
            //Log.Info("ConfigurationManager.AppSettings[GlobalConstants.BROWSER].ToUpper(): " + ConfigurationSettings.AppSettings[GlobalConstants.BROWSER].ToUpper());

            //string browser = ConfigurationSettings.AppSettings[GlobalConstants.BROWSER].ToUpper();
            string browser = "CHROME";
            BrowserType browserType = (BrowserType) Enum.Parse(typeof(BrowserType), browser);
            driver = DriverSingleton.GetDriverByBrowser(browserType);

            driver.Manage().Window.Maximize();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationSettings.AppSettings[GlobalConstants.SHORT_TIME_OUT]));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings[GlobalConstants.PAGE_URL]);
            driver.Navigate().GoToUrl("https://demoqa.com/");
        }


        [TearDown]
        public void TearDown()
        {
            Log.Info("Tear Down");
            DriverSingleton.quiteBrowser();
        }

    }
}
