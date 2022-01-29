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

        public RepoResult<bool> Create(User user)
        {
            //user.UserId = 1;
            var returnedUser = _shopDbContext.Users.FirstOrDefault(x => x.Username == user.Username);
            if (returnedUser != null)
            {
                return new RepoResult<bool>(false, true);
            }

            var added = _shopDbContext.Users.Add(user);
            _shopDbContext.SaveChanges();
            return new RepoResult<bool>(added.State == EntityState.Added);
        }


        public RepoResult<User> Get(string username, string password)
        {
            var user = _shopDbContext.Users.FirstOrDefault(x => x.Username == username);
            bool exists = false;
            if (user != null)
            {
                exists = Common.DecryptKey(user.UserKey, user) == password;
            }

            return new RepoResult<User>(user, exists);
        }
    }
}
