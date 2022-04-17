using System.Data.SqlClient;

namespace abahaBravo.Vendor.Connection.enfoce
{
    public class SQLConnection:ISQLConnection
    {
        private readonly IDatabaseSetting _databaseSetting;
        
        public SQLConnection(IDatabaseSetting databaseSetting)
        {
            _databaseSetting = databaseSetting;
        }
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_databaseSetting.GetConnectionInfo());
           
        }
    }
}