using System.ComponentModel.DataAnnotations;

namespace BrsPontes.GiftList.API.Application.Dtos
{
    public class UserSelectGiftItemDto
    {
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string GiftId { get; set; }
    }
}
