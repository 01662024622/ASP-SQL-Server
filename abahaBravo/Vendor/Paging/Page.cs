namespace abahaBravo.Vendor.Paging
{
    public class Page
    {
        public int CurenPage { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string Condition { get; set; }
    }
}