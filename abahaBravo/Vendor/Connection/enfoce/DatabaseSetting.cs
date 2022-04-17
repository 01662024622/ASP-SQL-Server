namespace abahaBravo.Vendor.Connection.enfoce
{
    public class DatabaseSetting:IDatabaseSetting
    {
        public string SqlServer { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string GetConnectionInfo()
        {
            return $"server={SqlServer};database={DatabaseName};user id={UserName};password={Password};MultipleActiveResultSets=true";
        }
    }
}