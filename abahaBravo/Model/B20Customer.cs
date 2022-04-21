namespace abahaBravo.Model
{
    public class B20Customer
    {
        public string SelectQuery = @"SELECT * FROM B20Customer WHERE Kiot_Id = @_Id";
        public string CreatQuery =
            @"INSERT INTO B20Customer (ParentId,IsGroup,BranchCode,Code,Name,Address,BillingAddress,PersonTel,CustomerType,Kiot_Id,KiotLog)
                    VALUES ('402281',0,'A01',@_Code,@_Name,@_Address,@_BillingAddress,@_Phone,1,@_Kiot_Id,'kiot tranfer')";
    }
}