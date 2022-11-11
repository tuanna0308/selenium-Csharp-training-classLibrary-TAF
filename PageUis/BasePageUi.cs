using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCsharpSeleniumHomework.PageUis
{
    public class BasePageUi
    {
        public const string MENU_PARENT_XPATH = "//div[@class='header-text' and text()='{0}']//span";
        public const string MENU_CHILD_XPATH = "//ul[@class='menu-list']/li//span[text()='{0}']";
    }
}
