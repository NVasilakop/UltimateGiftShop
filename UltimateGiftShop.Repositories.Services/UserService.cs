using Microsoft.EntityFrameworkCore;
using System.Linq;
using UltimateGiftShop.Repositories.Abstractions;
using UltimateGiftShop.Repositories.DataModels;

namespace UltimateGiftShop.Repositories.Services
{
    public class UserService : IUserService
    {
        public UltimateGiftShopDbContext _shopDbContext;
        public UserService(UltimateGiftShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public bool Create(User user)
        {
           var added =_shopDbContext.Users.Add(user);
           _shopDbContext.SaveChanges();
           return added.State == EntityState.Added;
        
        }

        public User Get(string key)
        {
            var user = _shopDbContext.Users.Where(x => x.UserKey == key).FirstOrDefault();
            _shopDbContext.SaveChanges();
            return user;

        }
    }
}
