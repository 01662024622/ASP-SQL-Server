using System;

namespace abahaBravo.Request
{
    public class ProductEntity
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public Decimal Price { get; set; }
        public Decimal Discount { get; set; }
        public double DiscountRatio { get; set; }
    }
}