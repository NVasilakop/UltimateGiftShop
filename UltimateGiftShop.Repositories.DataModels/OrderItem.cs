using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGiftShop.Repositories.DataModels
{

  
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public int CategoryDiscountId { get; set; }
        public CategoryDiscount CategoryDiscount{ get; set; }
        
        public int ItemId { get; set; }
        public Item Item { get; set; }
    
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
