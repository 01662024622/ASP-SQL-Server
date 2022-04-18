using System;
using System.Data;
using System.Data.SqlClient;
using abahaBravo.Model;
using abahaBravo.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace abahaBravo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public JsonResult Create(CustomerRequest request)
        {
            foreach (Notifications<CustomerEntity_Request> notification in request.Notifications)
            {
                foreach (CustomerEntity_Request data in notification.Data)
                {
                    B20Customer customer = new B20Customer();
            
                    string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
                    SqlDataReader myReader;
                    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                    {
                        myCon.Open();
                        using (SqlCommand myCommand = new SqlCommand(customer.CreatQuery, myCon))
                        {
                            myCommand.Parameters.Clear();
                            myCommand.Parameters.AddWithValue("@Code", data.Code);
                            myCommand.Parameters.AddWithValue("@Name", data.Name);
                            myCommand.Parameters.AddWithValue("@Address", data.Address);
                            myCommand.Parameters.AddWithValue("@BillingAddress", data.Address);
                            myCommand.Parameters.AddWithValue("@Phone", data.ContactNumber);
                            myCommand.Parameters.AddWithValue("@Email", data.Email);
            
                            myCommand.ExecuteReader();
                        }
            
                        myCon.Close();
                    }
                }
            }

            return new JsonResult(new Response.Response(200, "Thêm mới đối tượng thành công!"));
            // return new JsonResult("{\"status\":200,\"message\":\"Thêm mới đối tượng thành công!\"}");
        }
    }
}