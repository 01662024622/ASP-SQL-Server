using System;

namespace abahaBravo.Request
{
    public class ProductEntity
    {
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public long Discount { get; set; }
        public long SubTotal { get; set; }
    }
}