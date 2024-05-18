using System.ComponentModel.DataAnnotations;

namespace Demo.pl.ViewModels
{
    public class Loginmodelview
    {
        [Required(ErrorMessage = "Email Is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Rquired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
