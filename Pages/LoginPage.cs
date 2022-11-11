using AngleSharp.Io;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageObjectBase.Commons;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCsharpSeleniumHomework.PageUis;

namespace TrainingCsharpSeleniumHomework.Pages
{
    public class LoginPage : BasePage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPage openPage()
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings[GlobalConstants.PAGE_URL]);
            return this;
        }

        public HomePage Login(string userName, string password)
        {
            SendKeyToElement(driver, By.Id(LoginPageUi.USER_NAME_ID), userName); 
            SendKeyToElement(driver, By.Id(LoginPageUi.PASSWORD_ID), password); 

            ClickToElement(driver, By.Name(LoginPageUi.LOGIN_BUTTON_NAME));
            //return new HomePage(driver);
            return HomePage.Instance;
        }
    }
}
