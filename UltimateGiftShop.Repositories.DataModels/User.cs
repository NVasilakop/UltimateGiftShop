using System;

namespace UltimateGiftShop.Repositories.DataModels
{
    public class User
    {
        public int UserId { get; set; }
        public string Alias { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string UserKey { get; set; }
        public int LoginAttempts { get; set; }
    }
}
