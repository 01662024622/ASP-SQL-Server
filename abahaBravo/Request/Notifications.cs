using System.Collections.Generic;

namespace abahaBravo.Request
{
    public class Notifications<T>
    {
        public string Action { get; set; }
        public List<T> Data { get; set; }
    }
}