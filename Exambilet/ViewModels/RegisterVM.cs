using System.ComponentModel.DataAnnotations;

namespace Exambilet.ViewModels
{
    public class RegisterVM
    {
        [MaxLength(100)]
        [MinLength(4)]
        public string FullName { get; set; }
        [MaxLength(100)]
        [MinLength(4)]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }



    }
}
