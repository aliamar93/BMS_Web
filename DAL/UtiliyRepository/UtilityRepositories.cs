using DAL.Models;
using Microsoft.EntityFrameworkCore;
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
        public enum ApiStatusCode
        {
            Success = 200,
            BadRequest = 400,
            Unauthorized = 401,
            Forbidden = 403,
            NotFound = 404,
            InternalServerError = 500,
            ServiceUnavailable = 503,
            // Add more status codes as needed
        }

        public static AmStamp MatchStamp(IList<AmStamp> _amStamps, AmStamp _stamp)
        {
            int scope, Id = 0;
            if (_amStamps.Count >= 0 && (String.IsNullOrEmpty(_stamp.StampString) || _stamp.Stamp != null))
            {
                foreach (var item in _amStamps)
                {
                    if (_stamp.Stamp != null)
                    {
                        scope=fpengine.MatchTemplateOne(_stamp.Stamp, item.Stamp, 512);
                        //scope=fpengine.MatchTemplateOne("pSrcData", "DstData", 512);
                        if (scope >= 70)
                        {
                            Id = item.Id;
                        }
                    }
                    if (_stamp.StampString != null)
                    {
                        scope=fpengine.MatchBase64Str(System.Text.Encoding.Default.GetBytes(_stamp.StampString), System.Text.Encoding.Default.GetBytes(item.StampString), 0);
                        //fpengine.MatchBase64Str("pSrcData", "DstData", 0);
                        if (scope >= 70)
                        {
                            Id = item.Id;
                        }
                    }
                }
            }
            return _amStamps.Where(x => x.Id == Id).FirstOrDefault();
        }

        public static string getBaseUrl()
        {
            string hostingEnvironment = GetAppSettings("HostingEnvironment");
            string baseUrl = string.Empty;

            if (hostingEnvironment == "0")
            {
                //baseUrl = ConfigurationManager.AppSettings["APIBaseUrlBraunLocal"].ToString();
            }
            else
            {
                //baseUrl = ConfigurationManager.AppSettings["APIBaseUrlBraunUAT"].ToString();
            }

            return baseUrl;
        }

        //public static string getAppSettingKey(string keyName)
        //{
        //    string url = string.Empty;
        //    var endPoint = ConfigurationManager.AppSettings[keyName];
        //    if (endPoint != null)
        //    {
        //        url = endPoint.ToString();
        //    }
        //    return url;
        //}

        public static string GetAppSettings(string baseUrl)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appConfiguration.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            // Accessing settings
            string setting1 = configuration["AppSettings:SettingKey"];
            string setting2 = configuration["AppSettings:Setting2"];

            //Console.WriteLine($"Setting 1: {setting1}");
            //Console.WriteLine($"Setting 2: {setting2}");

            return setting1 + setting2;
        }

    }

    public partial class Response
    {
        public int Status { get; set; }
        public string Request { get; set; }
    }
}
