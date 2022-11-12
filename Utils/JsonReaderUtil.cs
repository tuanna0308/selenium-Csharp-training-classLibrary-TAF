using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesBase
{
    public class JsonReaderUtil
    {
        public static IConfigurationRoot GetDataFromJsonFile(String jsonFilePath)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.AddJsonFile(jsonFilePath, optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
