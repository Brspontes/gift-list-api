using BrsPontes.GiftList.API.Application.Dtos;
using BrsPontes.GiftList.API.Domain.Entities;
using BrsPontes.GiftList.API.Infra.Repositories;

namespace BrsPontes.GiftList.API.Application.Services
{
    public class GiftItemService : IGiftItemService
    {
        private readonly IGiftRepository _repository;
        public GiftItemService(IGiftRepository repository)
        {
            _repository = repository;
        }

        public async Task UserSelectItem(UserSelectGiftItemDto userSelectGiftItemDto)
        {
            await _repository.SelectItemByUser(new UserSelectGiftItem(userSelectGiftItemDto.GiftId,
               new Gifter(userSelectGiftItemDto.Name, userSelectGiftItemDto.Email, userSelectGiftItemDto.Phone), true));
        }

        public async Task<List<UnselectedItemsDto>> GetUnselectedItemsAsync()
        {
            var result = await _repository.GetUnselectedItens();
            var unselectedItems = new List<UnselectedItemsDto>();

            foreach (var item in result)
            {
                unselectedItems.Add(new UnselectedItemsDto
                {
                    Id = item.Id,
                    Images = item.Images,
                    ItemDescription = item.ItemDescription
                }); ;
            }
            return unselectedItems;
        }
    }
}
