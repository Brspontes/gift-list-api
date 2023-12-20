using BrsPontes.GiftList.API.Domain.Entities;

namespace BrsPontes.GiftList.API.Infra.Repositories
{
    public interface IGiftRepository
    {
        Task SelectItemByUser(UserSelectGiftItem userSelectGiftItem);
        Task<List<UserSelectGiftItem>> GetUnselectedItens();
    }
}
