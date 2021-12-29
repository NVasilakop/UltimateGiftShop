namespace UltimateGiftShop.Services.Abstractions
{
    public interface IRedisRepositoryService
    {
        bool CheckIfUserExists(int id);
        bool CheckAdminRights(int id);
    }
}