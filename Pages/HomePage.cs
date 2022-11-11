using OpenQA.Selenium;
using PageObjectBase.Commons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCsharpSeleniumHomework.PageUis;

namespace TrainingCsharpSeleniumHomework.Pages
{
    public class HomePage : BasePage
    {
        private IWebDriver driver;

        #region Lazy Initialize
        private static readonly ThreadLocal<HomePage> instance = new ThreadLocal<HomePage>(() => new HomePage());

        public static HomePage Instance
        {
            get
            {
                Console.WriteLine("Get HomePage");
                return instance.Value;
            }
            protected internal set
            {
                Console.WriteLine("Init HomePage");
                instance.Value = value;
            }
        }

        public void SetDriver(IWebDriver driver)
        {
            this.driver = driver;
        }
        #endregion

        #region Elements By
        public By CategoryBy(string categoryName) => By.XPath(GetDynamicLocator(HomePageUi.ELEMENT_XPATH, categoryName));
        public By MenuParentBy(string menuName) => By.XPath(GetDynamicLocator(HomePageUi.MENU_PARENT_XPATH, menuName));
        public By MenuChildBy(string menuName) => By.XPath(GetDynamicLocator(HomePageUi.MENU_CHILD_XPATH, menuName));

        #region Checkbox
        public By ResultCheckboxBy => By.Id(HomePageUi.RESULT_CHECKBOX_ID);
        public By CheckboxBy => By.Id(HomePageUi.CHECKBOX_ID);
        #endregion

        #region Radiobutton
        public By ResultRadioButtonBy => By.CssSelector(HomePageUi.RESULT_RADIO_BUTTON_CSS);
        public By YesRadioButtonBy => By.Id(HomePageUi.YES_RADIO_BUTTON_ID);
        public By ImpressiveRadioButtonBy => By.Id(HomePageUi.IMPRESSIVE_RADIO_BUTTON_ID);
        #endregion

        #region Forms
        public By FirstNameInputBy => By.Id(HomePageUi.FIRST_NAME_INPUT_ID);
        public By LastNameInputBy => By.Id(HomePageUi.LAST_NAME_INPUT_ID);
        public By EmailInputBy => By.Id(HomePageUi.EMAIL_INPUT_ID);
        public By MaleGenderRadioBy => By.Id(HomePageUi.MALE_GENDER_RADIO_ID);
        public By FeMaleGenderRadioBy => By.Id(HomePageUi.FEMALE_GENDER_RADIO_ID);
        public By MobileNumberInputBy => By.Id(HomePageUi.MOBILE_NUMBER_INPUT_ID);
        public By SubjectInputBy => By.Id(HomePageUi.SUBJECT_INPUT_ID);
        public By SportsCheckboxBy => By.Id(HomePageUi.SPORTS_CHECKBOX_ID);
        public By MusicCheckboxBy => By.Id(HomePageUi.MUSIC_CHECKBOX_ID);
        public By SubmitButtonBy => By.Id(HomePageUi.SUBMIT_BUTTON_ID);
        public By PopupConfirmBy => By.XPath(HomePageUi.POPUP_CONFIRM_XPATH);
        public By ValueTableByLableBy(string labelName) => By.XPath(GetDynamicLocator(HomePageUi.VALUE_ROW_TABLE_BY_LABEL_XPATH, labelName));
        #endregion

        #endregion

        #region Actions
        public bool IsLoginSuccessfully()
        {
            return IsElementDisplayed(driver, By.CssSelector(HomePageUi.LOGO_DIV_CSS));
        }
        #endregion


    }
}
