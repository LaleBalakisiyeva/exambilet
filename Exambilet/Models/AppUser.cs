using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Exambilet.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(30)]
        [MinLength(4)]
        public string FullName { get; set; }

    }
}
