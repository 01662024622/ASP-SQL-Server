using System;
using System.Collections.Generic;
using abahaBravo.Request;

namespace abahaBravo.Response
{
    public class Response
    {
        public int Total { get; set; }
        public List<AccdocEntity> Data { get; set; }
    }
}