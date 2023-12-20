using BrsPontes.GiftList.API.Application.Dtos;
using BrsPontes.GiftList.API.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BrsPontes.GiftList.API.Application.Controllers
{
    [Route("api/gift")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftItemService _giftItemService;

        public GiftController(IGiftItemService giftItemService)
        {
            _giftItemService = giftItemService;
        }

        [HttpPost("selectItem")]
        public async Task<ActionResult> userSelectGift([FromBody] UserSelectGiftItemDto userSelectGiftItemDto)
        {
            try
            {
                await _giftItemService.UserSelectItem(userSelectGiftItemDto);
                return Ok(Task.CompletedTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("unselectedItems")]
        public async Task<ActionResult<IEnumerable<UnselectedItemsDto>>> GetUnselectedItems()
        {
            try
            {
                return Ok(await _giftItemService.GetUnselectedItemsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
