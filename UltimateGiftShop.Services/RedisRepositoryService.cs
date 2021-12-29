using Common;
using StackExchange.Redis;
using UltimateGiftShop.Services.Abstractions;

namespace UltimateGiftShop.Services
{
    public class RedisRepositoryService : IRedisRepositoryService
    {
        private readonly IConnectionMultiplexer _connection;

        public RedisRepositoryService(IConnectionMultiplexer conn)
        {
            _connection = conn;
        }
        
        public bool CheckIfUserExists(int id)
        {
            var result = _connection.GetDatabase().StringGet(id.ToString()+RedisKeys.CustomerTypeSuffix);
            return !result.IsNull;
        }
        
        public bool CheckAdminRights(int id)
        {
            var result = _connection.GetDatabase().StringGet(RedisKeys.AdminKey);
            return !result.IsNull;
        }
    }
}