namespace abahaBravo.Model
{
    public class AccDocc
    {
        public readonly string Query =
            @"INSERT INTO AbahaAccdoc (Id,Kiot_Id,CustomerCode,DiscountRate,Total,Payment,Description)
                    VALUES (@_Id,@_Kiot_Id,@_CustomerCode,@_DiscountRate,@_Total,@_Payment,@_Description)";
        
        public string SelectQuery = @"SELECT * FROM AbahaAccdoc WHERE Id = @_Id";
        
        public readonly string QueryAccDocSale =
            @"INSERT INTO AbahaAccdocSale (Kiot_Id,Quantity,Price,InventoryId,Discount,Total,BillId)
                    VALUES (@_Kiot_Id,@_Quantity,@_Price,@_InventoryId,@_Discount,@_Total,@_BillId)";

        public readonly string QueryExec = @"EXEC uspAbahaConvertHDBravo @Id  = @_Id";
        public readonly string QueryExecInventory = @"EXEC usp_Connect_ton_Api_auto";
    }
}