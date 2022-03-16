using System;
using System.Net;

namespace unit_be.Helpers
{
    public class ServicesResponse
    {

        public ServicesResponse()
        {
        }

        public ServicesResponse(HttpStatusCode code, string title, string message, object data)
        {
            Code = code;
            Title = title;
            Message = message;
            Data = data;
        }

        public HttpStatusCode Code { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

    }
}
