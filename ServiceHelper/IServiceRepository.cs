using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumeWebAPI_App.ServiceHelper
{
    public interface IServiceRepository
    {
        HttpResponseMessage GetResponse(string segment);
        HttpResponseMessage PostResponse(string segment, object model);
        HttpResponseMessage GetByIdResponse(string segment, string guid);
        HttpResponseMessage PutResponse(string segment, object model);
        HttpResponseMessage DeleteResponse(string segment, string guid);

    }
}
