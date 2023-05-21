using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace webbmvcapp.Models.Identity
{
    public class CustomIdentityUser : IdentityUser
    {
        [ProtectedPersonalData]
        public string FirstName { get; set; } = null!;

        [ProtectedPersonalData]
        public string LastName { get; set; } = null!;
        [NotMapped]
        public string RoleName { get; set; } = null!;

    }
}
