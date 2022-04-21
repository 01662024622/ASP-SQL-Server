using System;
using System.Data;
using System.Data.SqlClient;
using abahaBravo.Model;
using abahaBravo.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace abahaBravo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IConfiguration configuration, ILoggerFactory logger)
        {
            _configuration = configuration;
            _logger = logger.CreateLogger<CustomerController>();
        }

        [HttpGet]
        public JsonResult Index()
        {
            return new JsonResult(200, "Khởi tạo thành công!");
        }

        [HttpPost("/api/customer/49f25S6yD95ru2j3.yrt78T_7h5f89Z3y56-9084rf3905fny14I9J5h234")]
        public JsonResult Create(CustomerRequest request)
        {
            try
            {
                foreach (Notifications<CustomerEntity_Request> notification in request.Notifications)
                {
                    foreach (CustomerEntity_Request data in notification.Data)
                    {
                        B20Customer customer = new B20Customer();

                        string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
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
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                _logger.LogInformation($"Something went wrong: {ex}");
                return new JsonResult(500, "Lỗi!");
            }

            return new JsonResult(200, "Thêm mới đối tượng thành công!");
            // return new JsonResult("{\"status\":200,\"message\":\"Thêm mới đối tượng thành công!\"}");
        }

        [HttpPut("/api/customer/49f25S6yD95ru2j3.yrt78T_7h5f89Z3y56-9084rf3905fny14I9J5h234")]
        public JsonResult Update(CustomerRequest request)
        {
            try
            {
                foreach (Notifications<CustomerEntity_Request> notification in request.Notifications)
                {
                    foreach (CustomerEntity_Request data in notification.Data)
                    {
                        B20Customer customer = new B20Customer();

                        string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
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
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                _logger.LogInformation($"Something went wrong: {ex}");
                return new JsonResult(500, "Lỗi!");
            }

            return new JsonResult(200, "Thêm mới đối tượng thành công!");
            // return new JsonResult("{\"status\":200,\"message\":\"Thêm mới đối tượng thành công!\"}");
        }
    }
}