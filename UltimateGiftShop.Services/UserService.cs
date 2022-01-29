using AppDataModels.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateGiftShop.Services.Abstractions;
using IUserServiceRepo = UltimateGiftShop.Repositories.Abstractions.IUserService;
using User = UltimateGiftShop.Repositories.DataModels.User;

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

        public ServiceResult<bool> CreateUser(SubscribeUser user)
        {
            var repoResult = _userRepo.Create(_mapper.Map<SubscribeUser, UltimateGiftShop.Repositories.DataModels.User>(user));
            return new ServiceResult<bool>(repoResult.Data,repoResult.Exists,repoResult.HasError,repoResult.ErrorMessage);
        }

        public ServiceResult<LoginUser> LoginUser(LoginUser user)
        {
            var repoResult = _userRepo.Get(user.UserName, user.Password);

            return new ServiceResult<LoginUser>(_mapper.Map<UltimateGiftShop.Repositories.DataModels.User, LoginUser>
                (repoResult.Data), repoResult.Exists, repoResult.HasError, repoResult.ErrorMessage);
        }
    }
}
