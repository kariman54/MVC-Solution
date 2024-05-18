using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.pl.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="First Name Is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Email Is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Password Is Rquired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Confirm Password Is Rquired")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password Doesn't match")]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }



    }
}
