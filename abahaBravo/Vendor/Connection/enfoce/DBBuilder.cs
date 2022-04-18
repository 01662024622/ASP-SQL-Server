namespace abahaBravo.Vendor.Connection.enfoce
{
    public static class DBBuilder<T> where T:EntityBase
    {
        public static int Limit { get; set; }
        public static int Offset { get; set; }
        public static string Condition { get; set; }
        public static string TableName{get; set; }
        public static string Select { get; set; } = "*";
    
    }
}