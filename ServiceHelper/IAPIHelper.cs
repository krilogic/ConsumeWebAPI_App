using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeWebAPI_App.ServiceHelper
{
    public interface IAPIHelper
    {
        string GetBaseURL();
        string GetReadSegmentURL(string segmentName);
        string GetReadByIdSegmentURL(string segmentName);
        string GetCreateSegmentURL(string segmentName);
        string GetUpdateSegmentURL(string segmentName);
        string GetDeleteSegmentURL(string segmentName);

    }
}
