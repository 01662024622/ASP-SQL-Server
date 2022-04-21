using System;
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
    
    public class AccDocController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccDocController> _logger;
        public AccDocController(IConfiguration configuration,ILoggerFactory logger)
        {
            _configuration = configuration; 
            _logger = logger.CreateLogger<AccDocController>();
        }

        [HttpPost("/api/acc/doc/89f256yD95ruj3.yrt789_7h5f89Z3y56-908234rf3905fny1489g5h234")]
        public JsonResult Create(AccDocRequest request)
        {
            try
            {
                _logger.LogInformation(request.ToString());
                AccDocc accDoccQr = new AccDocc();
                string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    foreach (Notifications<AccdocEntity> notification in request.Notifications)
                    {
                        foreach (AccdocEntity accDoc in notification.Data)
                        {
                            using (SqlCommand myCommand = new SqlCommand(accDoccQr.Query, myCon))
                            {
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@_Id", accDoc.Id);
                                myCommand.Parameters.AddWithValue("@_Kiot_Id  ", accDoc.Code);
                                myCommand.Parameters.AddWithValue("@_CustomerCode", accDoc.CustomerCode);
                                myCommand.Parameters.AddWithValue("@_DiscountRate", accDoc.Discount);
                                myCommand.Parameters.AddWithValue("@_Total", accDoc.Total+accDoc.Discount);
                                myCommand.Parameters.AddWithValue("@_Payment", accDoc.Total);
                                myCommand.ExecuteReader();
                            }

                            foreach (ProductEntity accDocSale in accDoc.InvoiceDetails)
                            {
                                using (SqlCommand pCommand = new SqlCommand(accDoccQr.QueryAccDocSale, myCon))
                                {
                                    pCommand.Parameters.Clear();
                                    pCommand.Parameters.AddWithValue("@_Id", accDocSale.ProductId);
                                    pCommand.Parameters.AddWithValue("@_Quantity", accDocSale.Quantity);
                                    pCommand.Parameters.AddWithValue("@_Price", accDocSale.Price);
                                    pCommand.Parameters.AddWithValue("@_Discount", accDocSale.Discount);
                                    pCommand.Parameters.AddWithValue("@_Total", accDocSale.SubTotal);
                                    pCommand.Parameters.AddWithValue("@_BillId", accDoc.Id);
                                    pCommand.ExecuteNonQuery();
                                }
                            }

                            using (SqlCommand myCommand = new SqlCommand(accDoccQr.QueryExec, myCon))
                            {
                                myCommand.Parameters.Clear();
                                myCommand.Parameters.AddWithValue("@_Id", accDoc.Id);
                                myCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    myCon.Close();
                }
                return new JsonResult(200,"success");
            }catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                _logger.LogInformation($"Something went wrong: {ex}");
                return new JsonResult(500, "Lỗi!");
            }
        }
    }
}