using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCsharpSeleniumHomework.PageUis
{
    public class HomePageUi : BasePageUi
    {
        #region saucedemo.com
        public const string LOGO_DIV_CSS = ".app_logo";
        #endregion

        #region demoqa.com
        public const string ELEMENT_XPATH = "//div[@class='card-body']/h5[text()='{0}']";

        #region Text Element
        public const string ELEMENTS_TEXT = "Elements";
        public const string CHECKBOX_TEXT = "Check Box";
        public const string RADIO_BUTTON_TEXT = "Radio Button";
        public const string YES_TEXT = "Yes";
        public const string IMPRESSIVE_TEXT = "Impressive";
        public const string FORMS_TEXT = "Forms";
        public const string PRACTICE_FORM_TEXT = "Practice Form";


        public const string STUDENT_NAME_TEXT = "Student Name";
        public const string STUDENT_EMAIL_TEXT = "Student Email";
        public const string GENDER_TEXT = "Gender";
        public const string MOBILE_TEXT = "Mobile";
        public const string DATE_OF_BIRTH_TEXT = "Date of Birth";
        public const string SUBJECTS_TEXT = "Subjects";
        public const string HOBBIES_TEXT = "Hobbies";


        #endregion

        #region Checkbox
        public const string CHECKBOX_ID = "tree-node-home";
        public const string RESULT_CHECKBOX_ID = "result";
        #endregion

        #region Radiobutton
        public const string RESULT_RADIO_BUTTON_CSS = ".mt-3 span.text-success";
        public const string YES_RADIO_BUTTON_ID = "yesRadio";
        public const string IMPRESSIVE_RADIO_BUTTON_ID = "impressiveRadio";
        #endregion

        #region Form
        public const string FIRST_NAME_INPUT_ID = "firstName";
        public const string LAST_NAME_INPUT_ID = "lastName";
        public const string EMAIL_INPUT_ID = "userEmail";
        public const string MALE_GENDER_RADIO_ID = "gender-radio-1";
        public const string MOBILE_NUMBER_INPUT_ID = "userNumber";
        public const string SUBJECT_INPUT_ID = "subjectsInput";
        public const string SPORTS_CHECKBOX_ID = "hobbies-checkbox-1";
        public const string MUSIC_CHECKBOX_ID = "hobbies-checkbox-3";
        public const string SUBMIT_BUTTON_ID = "submit";

        public const string POPUP_CONFIRM_XPATH = "//div[@id='example-modal-sizes-title-lg' and text()='Thanks for submitting the form']";
        public const string VALUE_ROW_TABLE_BY_LABEL_XPATH = POPUP_CONFIRM_XPATH + "/parent::div/following-sibling::div//td[text()='{0}']/following-sibling::td";
        #endregion

        #endregion
    }
}
