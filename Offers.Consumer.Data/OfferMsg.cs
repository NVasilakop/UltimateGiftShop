using System;
using Common;

namespace Offers.Consumer.Data
{
    public class OfferMsg
    {
        public CustomerType? CustomerType { get; set; }
        public double? Discount { get; set; }
        public ProductCategory? Product { get; set; }
        public long? StartDate { get; set; }
        public long? EndDate { get; set; }
    }
}