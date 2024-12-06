using System.ComponentModel.DataAnnotations;

namespace CompileCrew.ViewModels.Account
{
    public class RegisterVM
    {
        [MinLength(3, ErrorMessage = "Required minimum 3 symbols")]
        [MaxLength(25, ErrorMessage = "Maximum 25 symbols are allowed")]
        public string FirstName { get; set; }


        [MinLength(3, ErrorMessage = "Required minimum 3 symbols")]
        [MaxLength(25, ErrorMessage = "Maximum 25 symbols are allowed")]
        public string LastName { get; set; }


        [MaxLength(256, ErrorMessage = "Maximum 256 symbols are allowed")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
