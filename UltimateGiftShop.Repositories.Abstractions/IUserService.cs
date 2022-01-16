using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateGiftShop.Repositories.DataModels;

namespace UltimateGiftShop.Repositories.Abstractions
{
    public interface IUserService
    {
        bool Create(User user);
        User Get(string key);
    }
}
