using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGiftShop.Repositories.DataModels
{
    public class CategoryDiscount
    {
        public int Id { get; set; }
        public double Discount { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
