using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace abahaBravo.Vendor.Connection.enfoce
{
    public static class QueryUtil
    {
    
        public static String GetCollectionName(Type type)
        {
            return type.Name;
        }
    }
}