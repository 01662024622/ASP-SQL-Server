namespace abahaBravo.Request
{
    public class CustomerEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } = "không có";
        public string ContactNumber { get; set; }= "không có";
    }
}