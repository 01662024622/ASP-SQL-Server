using System;
using System.Collections.Generic;

namespace abahaBravo.Request
{
    public class AccdocEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int BrandId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerId { get; set; }
        public Decimal Total { get; set; }
        public Decimal Discount { get; set; }
        public List<ProductEntity> OrderDetails { get; set; }
    }
}