using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using abahaBravo.Model;
using abahaBravo.Request;

namespace abahaBravo.Service
{
    public class AccDocService
    {
        private static Dictionary<long, long> _inventory = new Dictionary<long, long>()
        {
            {63506, 219321},
            {164049, 219201},
            {19576, 218761},
            {19578, 218841},
            {3634, 219081},
            {58187, 219001}
        };

        public static void CreatedResult(string sqlDataSource, AccdocEntity accdocEntity)
        {
            if (accdocEntity.StatusValue.Equals("Đã hủy")) return;
            try
            {
                AccDocc accDoccQr = new AccDocc();
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand slectCommand = new SqlCommand(accDoccQr.SelectQuery, myCon))
                    {
                        slectCommand.Parameters.Clear();
                        slectCommand.Parameters.AddWithValue("@_Id", accdocEntity.Id);
                        SqlDataReader reader = slectCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            Console.WriteLine(
                                "--------Accdoc ID exist---------" + accdocEntity.Id + "-----------------");
                            return;
                        }

                        Console.WriteLine("----Accdoc ID add--------" + accdocEntity.Id + "------------");
                    }

                    using (SqlCommand myCommand = new SqlCommand(accDoccQr.Query, myCon))
                    {
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@_Id", accdocEntity.Id);
                        myCommand.Parameters.AddWithValue("@_Kiot_Id  ", accdocEntity.CustomerId.ToString());
                        myCommand.Parameters.AddWithValue("@_CustomerCode", accdocEntity.CustomerCode);
                        myCommand.Parameters.AddWithValue("@_DiscountRate", accdocEntity.Discount);
                        myCommand.Parameters.AddWithValue("@_Total", accdocEntity.Total + accdocEntity.Discount);
                        myCommand.Parameters.AddWithValue("@_Payment", accdocEntity.Total);
                        myCommand.Parameters.AddWithValue("@_Description", accdocEntity.Description);
                        myCommand.ExecuteNonQuery();
                    }

                    foreach (ProductEntity accDocSale in accdocEntity.InvoiceDetails)
                    {
                        using (SqlCommand pCommand = new SqlCommand(accDoccQr.QueryAccDocSale, myCon))
                        {
                            pCommand.Parameters.Clear();
                            pCommand.Parameters.AddWithValue("@_Kiot_Id", accDocSale.ProductId.ToString());
                            pCommand.Parameters.AddWithValue("@_Quantity", accDocSale.Quantity);
                            pCommand.Parameters.AddWithValue("@_Price", accDocSale.Price);
                            pCommand.Parameters.AddWithValue("@_InventoryId", _inventory[accdocEntity.BranchId]);
                            pCommand.Parameters.AddWithValue("@_Discount", accDocSale.Discount * accDocSale.Quantity);
                            pCommand.Parameters.AddWithValue("@_Total", accDocSale.SubTotal);
                            pCommand.Parameters.AddWithValue("@_BillId", accdocEntity.Id);
                            pCommand.ExecuteNonQuery();
                        }
                    }

                    myCon.Close();
                }


                using (SqlConnection myConExec = new SqlConnection(sqlDataSource))
                {
                    myConExec.Open();
                    using (SqlCommand myCommand = new SqlCommand(accDoccQr.QueryExec, myConExec))
                    {
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@_Id", accdocEntity.Id);
                        myCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand myCommand = new SqlCommand(accDoccQr.QueryExecInventory, myConExec))
                    {
                        myCommand.Parameters.Clear();
                        myCommand.ExecuteNonQuery();
                    }

                    myConExec.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}