using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UtiliyRepository
{
    public class UtilityRepositories
    {
        public static string getBaseUrl()
        {
            string hostingEnvironment = getAppSettingKey("HostingEnvironment");
            string baseUrl = string.Empty;

            if (hostingEnvironment == "0")
            {
                baseUrl = ConfigurationManager.AppSettings["APIBaseUrlBraunLocal"].ToString();
            }
            else
            {
                baseUrl = ConfigurationManager.AppSettings["APIBaseUrlBraunUAT"].ToString();
            }

            return baseUrl;
        }

        public static string getAppSettingKey(string keyName)
        {
            string url = string.Empty;
            var endPoint = ConfigurationManager.AppSettings[keyName];
            if (endPoint != null)
            {
                url = endPoint.ToString();
            }
            return url;
        }
    }
}
