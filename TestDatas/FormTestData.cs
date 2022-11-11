using Microsoft.Extensions.Configuration;
using PageObjectBase.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesBase;

namespace TrainingCsharpSeleniumHomework.TestDatas
{
    public class FormTestData
    {
        private IConfigurationRoot configuration;

        public FormTestData()
        {
            configuration = JsonReaderUtil.GetDataFromJsonFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + GlobalConstants.TEST_DATA_PATH + "FormTestData.json");
            ListData = configuration.GetSection(GlobalConstants.FORM_TEST_DATA).Get<List<Data>>();
        }

        public List<Data> ListData { get; set; }

        public class Data
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserEmail { get; set; }
            public string Gender { get; set; }
            public string UserPhoneNumber { get; set; }
        }
    }
}
