using AppDataModels.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateGiftShop.Services.Abstractions;
using IUserServiceRepo = UltimateGiftShop.Repositories.Abstractions.IUserService;
using RepoUser = UltimateGiftShop.Repositories.DataModels.User;

namespace UltimateGiftShop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserServiceRepo _userRepo;
        private readonly IMapper _mapper; 

        public UserService(IUserServiceRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public bool CreateUser(SubscribeUser user)
        {
            var x = _userRepo.Create(_mapper.Map<SubscribeUser,RepoUser>(user));
            return x;
        }
    }
}
