using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.server.HelperClasses
{
    public class MyErrorResponse
    {

        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public MyErrorResponse(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
            StackTrace = ex.ToString();
        }

    }
}
