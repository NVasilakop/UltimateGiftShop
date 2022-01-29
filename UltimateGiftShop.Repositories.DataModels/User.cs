using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

namespace UltimateGiftShop.Repositories.DataModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Alias { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string UserKey { get; set; }
        public int LoginAttempts { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Username { get; set; }
        public Guid Salt { get; set; }
    }
}
