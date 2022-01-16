using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateGiftShop.Repositories.DataModels;
using UltimateGiftShop.Services.DataModels;

namespace UltimateGiftShop.Repositories.DataModels.AutoMap
{
    public class UserRepositoryProfile : Profile
    {
        public UserRepositoryProfile()
        {
            CreateMap<UltimateGiftShop.Services.DataModels.User, User>(MemberList.Destination)
                  .ForMember(us => us.UserKey,
                   opt => opt.MapFrom(src => src.Password));
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }
    }
}
