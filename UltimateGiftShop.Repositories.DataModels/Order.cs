using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGiftShop.Repositories.DataModels
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string Comments { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
