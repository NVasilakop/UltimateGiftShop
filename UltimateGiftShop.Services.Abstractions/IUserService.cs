using AppDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGiftShop.Services.Abstractions
{
    public interface IUserService
    {
        ServiceResult<bool> CreateUser(SubscribeUser user);
        ServiceResult<LoginUser> LoginUser(LoginUser user);
    }
}
