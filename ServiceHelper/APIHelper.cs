using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeWebAPI_App.ServiceHelper
{
    public class APIHelper : IAPIHelper
    {
        IConfiguration _configuration;
        public APIHelper(IConfiguration iconfiguration)
        {
            _configuration = iconfiguration;
        }
        public string GetBaseURL()
        {
            return _configuration.GetSection("API")["BaseURL"];
        }
        public string GetReadSegmentURL(string segmentName)
        {
            string relativeURL = _configuration.GetSection("API:" + segmentName)["GetURL"];
            return relativeURL;
        }
        public string GetReadByIdSegmentURL(string segmentName)
        {
            string relativeURL = _configuration.GetSection("API:" + segmentName)["GetURLById"];
            return relativeURL;
        }
        public string GetCreateSegmentURL(string segmentName)
        {
            string relativeURL = _configuration.GetSection("API:" + segmentName)["CreateURL"];
            return relativeURL;
        }
        public string GetUpdateSegmentURL(string segmentName)
        {
            string relativeURL = _configuration.GetSection("API:" + segmentName)["UpdateURL"];
            return relativeURL;
        }
        public string GetDeleteSegmentURL(string segmentName)
        {
            string relativeURL = _configuration.GetSection("API:" + segmentName)["DeleteURL"];
            return relativeURL;
        }
    }
}
