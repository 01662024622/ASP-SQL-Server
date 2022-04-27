using System;
using System.Collections.Generic;

namespace abahaBravo.Request
{
    public class AccdocEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long BranchId { get; set; }
        public string CustomerCode { get; set; }
        public long CustomerId { get; set; } = 12866196;
        public long Total { get; set; }
        public long Discount { get; set; }
        public string Description { get; set; } = " ";
        public string StatusValue { get; set; }
        
        public List<ProductEntity> InvoiceDetails { get; set; }
    }
}