namespace abahaBravo.Model
{
    public class AccDocc
    {
        public readonly string Query =
            @"INSERT INTO AbahaAccdoc (Id,Code,CustomerCode,DiscountRate,Total,Payment)
                    VALUES (@_Id,@_Code,@_CustomerCode,@_DiscountRate,@_Total,@_Payment)";

        public readonly string QueryAccDocSale =
            @"INSERT INTO AbahaAccdocSale (Code,Quantity,Price,Discount,Total,BillId)
                    VALUES (@_Code,@_Quantity,@_Price,@_Discount,@_Total,@_BillId)";

        public readonly string QueryExec = @"EXEC uspAbahaConvertHDBravo @Id  = @_Id";
    }
}