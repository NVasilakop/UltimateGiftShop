using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGiftShop.Repositories.DataModels
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public CategoryDiscount CategoryDiscount{ get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
