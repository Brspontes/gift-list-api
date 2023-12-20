using BrsPontes.GiftList.API.Application.Dtos;

namespace BrsPontes.GiftList.API.Application.Services
{
    public interface IGiftItemService
    {
        Task UserSelectItem(UserSelectGiftItemDto userSelectGiftItemDto);
        Task<List<UnselectedItemsDto>> GetUnselectedItemsAsync();
    }
}
