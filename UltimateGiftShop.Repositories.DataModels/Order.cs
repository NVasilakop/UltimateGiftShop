using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGiftShop.Repositories.DataModels
{
    public class Order
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Item> Items { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
