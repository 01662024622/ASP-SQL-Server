using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using abahaBravo.Model;
using abahaBravo.Request;

namespace abahaBravo.Service
{
    public class CustomerService
    {
        public static void CreatedResult(string sqlDataSource, CustomerEntity customer)
        {
            try
            {
                B20Customer customerModel = new B20Customer();
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand slectCommand = new SqlCommand(customerModel.SelectQuery, myCon))
                    {
                        slectCommand.Parameters.Clear();
                        slectCommand.Parameters.AddWithValue("@_Kiot_Id", customer.Id.ToString());
                        SqlDataReader reader = slectCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            Console.WriteLine("----Customer ID exist--------"+customer.Id+"------------");
                            return;
                        }
                        Console.WriteLine("----Customer ID add--------"+customer.Id+"------------");
                    }
                    using (SqlCommand myCommand = new SqlCommand(customerModel.CreatQuery, myCon))
                    {
                        myCommand.Parameters.Clear();
                        myCommand.Parameters.AddWithValue("@_Code", customer.Code);
                        myCommand.Parameters.AddWithValue("@_Kiot_Id  ", customer.Id.ToString());
                        myCommand.Parameters.AddWithValue("@_Name  ", customer.Name);
                        myCommand.Parameters.AddWithValue("@_Address  ", customer.Address);
                        myCommand.Parameters.AddWithValue("@_BillingAddress  ", customer.Address);
                        myCommand.Parameters.AddWithValue("@_Phone  ", customer.ContactNumber);
                        myCommand.ExecuteNonQuery();
                        
                    }

                    myCon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}