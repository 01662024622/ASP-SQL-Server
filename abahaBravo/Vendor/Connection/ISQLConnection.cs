using System.Data.SqlClient;

namespace abahaBravo.Vendor.Connection
{
    public interface ISQLConnection
    {
        public SqlConnection CreateConnection();
    }
}