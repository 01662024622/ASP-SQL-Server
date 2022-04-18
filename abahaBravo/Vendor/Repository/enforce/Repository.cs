using abahaBravo.Vendor.Connection;
using abahaBravo.Vendor.Connection.enfoce;

namespace abahaBravo.Vendor.Repository.enforce
{
    public class Repository<T>:IRepository<T> where T:EntityBase
    {
        private readonly ISQLConnection _connection;
        public Repository(ISQLConnection sqlConnection)
        {
            _connection = sqlConnection;
        }
        
        
    }
}