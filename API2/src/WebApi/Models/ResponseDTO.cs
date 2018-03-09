using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
    }

    public class ResponseDTO<T>
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
    }
}