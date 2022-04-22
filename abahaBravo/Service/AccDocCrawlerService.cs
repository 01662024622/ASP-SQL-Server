using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using abahaBravo.Response;
using abahaBravo.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace abahaBravo.Service
{
    public class AccDocCrawlerService : CronJobService

    {
        private const string SQL_CONNECT =
            "server=27.71.233.229,52022,52022;database=B8R2_EPlus_Technology;user id=abaha;password=123456;MultipleActiveResultSets=true";

        private const string CLIENT_SECRET = "9BE94DC179BB890F4AB1DC7EFF16F819B10C11C5";
        private const string CLIENT_ID = "2c181bb5-10a9-4063-8a94-9e89f20564f0";
        private const string URL_TOKEN = "https://id.kiotviet.vn/connect/token";
        private const string URL_API = "https://public.kiotapi.com/";
        private const string CUSTOMER = "customers";
        private const string SKU = "products";
        private const string ACCDOC = "invoices";
        private string CheckDate = "";
        private string TOKEN = "1233453567";
        private readonly ILogger _logger;

        public AccDocCrawlerService(IScheduleConfig<AccDocCrawlerService> config, ILogger<AccDocCrawlerService> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Crawl();
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            Crawl();
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 1 is stopping.");
            return base.StopAsync(cancellationToken);
        }


        private void Crawl()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd H");
            if (!today.Equals(CheckDate))
            {
                string body = BodyRequest.GetbodyAuth(CLIENT_ID, CLIENT_SECRET);
                string checkToken = ApiService.OAuth2(URL_TOKEN, body);
                if (checkToken.Equals("Bearer ")) return;
                CheckDate = today;
                TOKEN = ApiService.OAuth2(URL_TOKEN, body);
            }


            // string param =
                // "?format=json&toPurchaseDate=2022-04-20 19:00:00&fromPurchaseDate=2022-04-20 19:00:00&pageSize=100";
            string param = $"?format=json&fromPurchaseDate={CheckDate}:00:00&toPurchaseDate={CheckDate}:59:00&pageSize=100";
            // string param = $"?lastModifiedFrom=2022-04-22&includerRemoveIds=true&includeTotal=true&orderBy=modifiedDate&orderDirection=desc";


            // add customer
            // string customer = ApiService.Get(URL_API + CUSTOMER + param, TOKEN);
            // CustomerResponse result = JsonConvert.DeserializeObject<CustomerResponse>(customer);
            // for (int i = 0; i < result.Total; i++)
            // {
            //     CustomerService.CreatedResult(SQL_CONNECT, result.Data[i]);
            // }

            // add accdoc
            string AccRess = ApiService.Get(URL_API + ACCDOC + param, TOKEN);
            AccdocResponse resultAcc = JsonConvert.DeserializeObject<AccdocResponse>(AccRess);
            for (int i = 0; i < resultAcc.Total; i++)
            {
                AccDocService.CreatedResult(SQL_CONNECT, resultAcc.Data[i]);
            }
        }
    }
}