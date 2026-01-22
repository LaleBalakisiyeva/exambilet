using System.ComponentModel.DataAnnotations;

namespace Exambilet.ViewModels
{
    public class LoginVM
    {
        [MaxLength(100)]
        [MinLength(4)]
        public string UserOrEmailName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPeristed { get; set; }
    }
}
