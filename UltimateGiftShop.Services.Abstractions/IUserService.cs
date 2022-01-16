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
        bool CreateUser(SubscribeUser user);
    }
}
