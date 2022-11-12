using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PageObjectBase.DriverConfig
{

    public class DriverSingleton
    {
        private static IWebDriver? driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriverByBrowser(BrowserType browserType)
        {
            if (driver == null)
            {
                switch (browserType)
                {
                    case BrowserType.CHROME:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    case BrowserType.FIREFOX:
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    case BrowserType.OPERA:
                        new DriverManager().SetUpDriver(new OperaConfig());
                        driver = new OperaDriver();
                        break;
                    default: throw new ArgumentException("Please update the browser name again!");
                }
            }

            return driver;
        }

        public static void quiteBrowser()
        {
            if (driver != null)
                driver.Quit();
            driver = null;
        }
    }
}
