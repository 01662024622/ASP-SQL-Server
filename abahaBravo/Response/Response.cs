using System;
using System.Collections.Generic;
using abahaBravo.Request;

namespace abahaBravo.Response
{
    public class Response<T>
    {
        public int Total { get; set; }
        public List<T> Data { get; set; }
    }
}