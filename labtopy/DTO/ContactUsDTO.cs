using System.ComponentModel.DataAnnotations;

namespace labtopy.DTO
{
    public class ContactUsDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;
    }
}
