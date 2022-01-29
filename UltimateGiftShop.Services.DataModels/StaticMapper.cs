using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace UltimateGiftShop.Services.DataModels
{
    public static class StaticMapper
    {
        public static IMapper GetServiceMapperConfiguration()
        {
            var currentAssembly = typeof(StaticMapper).Assembly;
            var config = new MapperConfiguration(
                cfg => cfg.AddMaps(currentAssembly));

            var mapper = new Mapper(config);

            return mapper;
        }
    }
}
