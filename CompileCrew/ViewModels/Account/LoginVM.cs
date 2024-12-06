using System.ComponentModel.DataAnnotations;

namespace CompileCrew.ViewModels.Account
{
    public class LoginVM
    {
        [MinLength(4, ErrorMessage = "Symbols in Email can't be less than 4!")]
        [MaxLength(256, ErrorMessage = "Symbols in Email can't be more than 256!")]
        public string Email { get; set; }



        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Symbols in Password can't be less than 6!")]
        public string Password { get; set; }
    }
}
