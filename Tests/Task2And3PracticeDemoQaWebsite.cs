using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectBase.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCsharpSeleniumHomework.Pages;
using TrainingCsharpSeleniumHomework.PageUis;
using TrainingCsharpSeleniumHomework.TestDatas;
using UtilitiesBase;

namespace TrainingCsharpSeleniumHomework.Tests
{
    public class Task2And3PracticeDemoQaWebsite : BaseTest
    {
        HomePage homePage;

        [SetUp]
        public void setup()
        {
            SetupDriver();

            homePage = HomePage.Instance;
            homePage.SetDriver(driver);

            homePage.ClickToElement(driver, homePage.CategoryBy(HomePageUi.ELEMENTS_TEXT));
        }

        [Test]
        public void TestElement_Checkbox()
        {
            homePage.ClickToElement(driver, homePage.MenuChildBy(HomePageUi.CHECKBOX_TEXT));

            //Assert.True(homePage.IsElementUnDisplayed(driver, homePage.ResultCheckboxBy));

            homePage.ClickToElementByJs(driver, homePage.CheckboxBy);
            Assert.True(homePage.IsElementSelected(driver, homePage.CheckboxBy));
            Assert.True(homePage.IsElementDisplayed(driver, homePage.ResultCheckboxBy));

            homePage.ClickToElementByJs(driver, homePage.CheckboxBy);
            Assert.False(homePage.IsElementSelected(driver, homePage.CheckboxBy));
            Assert.True(homePage.IsElementUnDisplayed(driver, homePage.ResultCheckboxBy));
        }

        [Test]
        public void TestElement_RadioButton()
        {
            homePage.ClickToElement(driver, homePage.MenuChildBy(HomePageUi.RADIO_BUTTON_TEXT));

            //Assert.True(homePage.IsElementUnDisplayed(driver, homePage.ResultRadioButtonBy));

            homePage.ClickToElementByJs(driver, homePage.YesRadioButtonBy);

            Assert.True(homePage.IsElementSelected(driver, homePage.YesRadioButtonBy));
            Assert.True(homePage.IsElementDisplayed(driver, homePage.ResultRadioButtonBy));
            Assert.That(HomePageUi.YES_TEXT, Is.EqualTo(homePage.GetElementText(driver, homePage.ResultRadioButtonBy)));

            homePage.ClickToElementByJs(driver, homePage.ImpressiveRadioButtonBy);

            Assert.True(homePage.IsElementSelected(driver, homePage.ImpressiveRadioButtonBy));
            Assert.True(homePage.IsElementDisplayed(driver, homePage.ResultRadioButtonBy));
            Assert.That(HomePageUi.IMPRESSIVE_TEXT, Is.EqualTo(homePage.GetElementText(driver, homePage.ResultRadioButtonBy)));
        }

        private static List<FormTestData.Data> getData()
        {
            FormTestData formTestData = new FormTestData();
            return formTestData.ListData;
        }

        [TestCaseSource(nameof(getData))]
        public void TestForms(FormTestData.Data formTestData)
        {
            homePage.ScrollToElement(driver, homePage.MenuParentBy(HomePageUi.FORMS_TEXT));
            homePage.ClickToElement(driver, homePage.MenuParentBy(HomePageUi.FORMS_TEXT));
            homePage.ClickToElement(driver, homePage.MenuChildBy(HomePageUi.PRACTICE_FORM_TEXT));

            homePage.SendKeyToElement(driver, homePage.FirstNameInputBy, formTestData.FirstName);
            homePage.SendKeyToElement(driver, homePage.LastNameInputBy, formTestData.LastName);
            homePage.SendKeyToElement(driver, homePage.EmailInputBy, formTestData.UserEmail);
            if (formTestData.Gender.Equals(HomePageUi.MALE_TEXT))
                homePage.ClickToElementByJs(driver, homePage.MaleGenderRadioBy);
            if (formTestData.Gender.Equals(HomePageUi.FEMALE_TEXT))
                homePage.ClickToElementByJs(driver, homePage.FeMaleGenderRadioBy);
            homePage.SendKeyToElement(driver, homePage.MobileNumberInputBy, formTestData.UserPhoneNumber);


            homePage.ClickToElementByJs(driver, homePage.SportsCheckboxBy);
            homePage.ClickToElementByJs(driver, homePage.MusicCheckboxBy);

            homePage.ZoomPage(driver, 80);

            homePage.WaitForElementToBeClickable(driver, homePage.SubmitButtonBy);
            homePage.ClickToElementByJs(driver, homePage.SubmitButtonBy);

            homePage.WaitForElementVisible(driver, homePage.PopupConfirmBy);

            Assert.That(formTestData.FirstName + " " + formTestData.LastName, Is.EqualTo(homePage.GetElementText(driver, homePage.ValueTableByLableBy(HomePageUi.STUDENT_NAME_TEXT))));
            Assert.That(formTestData.UserEmail, Is.EqualTo(homePage.GetElementText(driver, homePage.ValueTableByLableBy(HomePageUi.STUDENT_EMAIL_TEXT))));
            Assert.That(formTestData.Gender, Is.EqualTo(homePage.GetElementText(driver, homePage.ValueTableByLableBy(HomePageUi.GENDER_TEXT))));
            Assert.That(formTestData.UserPhoneNumber, Is.EqualTo(homePage.GetElementText(driver, homePage.ValueTableByLableBy(HomePageUi.MOBILE_TEXT))));
        }
    }
}
