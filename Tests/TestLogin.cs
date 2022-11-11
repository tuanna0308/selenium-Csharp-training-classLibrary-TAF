using NUnit.Framework;
using PageObjectBase.Commons;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCsharpSeleniumHomework.Pages;

namespace TrainingCsharpSeleniumHomework.Tests
{
    public class TestLogin : BaseTest
    {
        LoginPage loginPage;

        [SetUp]
        public void setup()
        {
            SetupDriver();
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void Login_Test_01()
        {
            Log.Info("Login_Test_01");
            //loginPage.openPage().Login(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]).IsLoginSuccessfully();
        }
    }
}
