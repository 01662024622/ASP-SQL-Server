﻿namespace abahaBravo.Request
{
    public class CustomerRequest
    {
        public class Create
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }
    }
}