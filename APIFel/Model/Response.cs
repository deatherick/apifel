using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFel.Model
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Object { get; set; }
    }
}