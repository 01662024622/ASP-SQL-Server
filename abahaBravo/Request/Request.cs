using System.Collections.Generic;

namespace abahaBravo.Request
{
    public class Request<T>
    {
        public string Id{ get; set; }
        public int Attempt{ get; set; }
        public List<Notifications<T>> Notifications { get; set; }
    }
}

