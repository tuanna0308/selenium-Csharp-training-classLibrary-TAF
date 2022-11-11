using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using PageObjectBase.Commons;
using System.Configuration;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TrainingCsharpSeleniumHomework.Tests
{
    public class Task1 : BaseTest
    {
        // Ctrl + K + C
        // Ctrl + K + U

        [SetUp]
        public void setup()
        {
            SetupDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");

            Log.Info("Test");

            Assert.True(driver.Title.Contains("Google"));

            IWebElement searchTextbox;
            string searchText = "C# Tutorial";

            // Find by xpath
            searchTextbox = driver.FindElement(By.XPath("//input[@name='q']"));
            Assert.IsTrue(searchTextbox.Displayed);

            // Find by CSS
            searchTextbox = driver.FindElement(By.CssSelector("input[name='q']"));
            Assert.IsTrue(searchTextbox.Displayed);

            // Find by Name
            searchTextbox = driver.FindElement(By.Name("q"));
            Assert.IsTrue(searchTextbox.Displayed);

            searchTextbox.SendKeys(searchText);
            searchTextbox.SendKeys(Keys.Enter);

            Assert.IsTrue(driver.FindElement(By.XPath("(//div[@id=\"search\"]//a//h3)[1]")).Text.Contains(searchText));
        }

    }
}