using System.ComponentModel.DataAnnotations;

namespace labtopy.DTO
{
    public class ApplicationUserDTO
    {

        [Required]
        public string FirstName { get; set; }
        [Required]

        public string  LastName{ get; set; }
        [Required]
        public string  UserName{ get; set; }


        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}
