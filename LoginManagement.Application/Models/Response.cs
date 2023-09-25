using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Application.Models
{
    public class Response
    {
        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }

    public class Response<T> : Response
    {
        public T Payload { get; set; }
    }
}
