using System;
using System.Collections.Generic;

namespace abahaBravo.Request
{
    public class AccdocEntity
    {
        public string Code { get; set; }
        public string CustomerCode { get; set; }
        public Decimal Total { get; set; }
        public Decimal TotalPayment { get; set; }
        public Decimal Discount { get; set; }
        public Decimal DiscountRatio { get; set; }
        public List<ProductEntity> OrderDetails { get; set; }
    }
}