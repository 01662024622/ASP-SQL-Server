namespace abahaBravo.Vendor.Connection
{
    public interface IDatabaseSetting
    {
        public string SqlServer { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string GetConnectionInfo();
    }
}