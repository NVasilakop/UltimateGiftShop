using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGiftShop.Repositories.DataModels
{
    public class CategoryDiscount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryDiscountId { get; set; }
        public double Discount { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
