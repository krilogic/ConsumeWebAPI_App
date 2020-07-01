using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeWebAPI_App.ServiceHelper
{
    public class ServiceRepository : IServiceRepository
    {
        protected IAPIHelper _apiHelper;
        public HttpClient Client { get; set; }

        public ServiceRepository(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
            Client = new HttpClient();
            Client.BaseAddress = new Uri(_apiHelper.GetBaseURL());
        }
        public HttpResponseMessage GetResponse(string segment)
        {
            string segmentURL = _apiHelper.GetReadSegmentURL(segment);
            return Client.GetAsync(segmentURL).Result;
        }
        public HttpResponseMessage PostResponse(string segment, object model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            string segmentURL = _apiHelper.GetCreateSegmentURL(segment);
            //return Client.PostAsync(segmentURL, model).Result;
            return Client.PostAsync(segmentURL, content).Result;

        }
        public HttpResponseMessage GetByIdResponse(string segment, string guid)
        {
            string segmentURL = _apiHelper.GetReadByIdSegmentURL(segment) + guid;
            return Client.GetAsync(segmentURL).Result;
        }
        public HttpResponseMessage PutResponse(string segment, object model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            string segmentURL = _apiHelper.GetUpdateSegmentURL(segment);
            //HttpResponseMessage response = Client.PutAsJsonAsync(segmentURL, model).Result;
            HttpResponseMessage response = Client.PutAsync(segmentURL, content).Result;
            return response;

        }
        public HttpResponseMessage DeleteResponse(string segment, string guid)
        {

            string segmentURL = _apiHelper.GetDeleteSegmentURL(segment) + guid;
            return Client.DeleteAsync(segmentURL).Result;
        }

    }
}
