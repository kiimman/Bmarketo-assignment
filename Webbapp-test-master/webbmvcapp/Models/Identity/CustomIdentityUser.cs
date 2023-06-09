﻿using Microsoft.AspNetCore.Identity;

namespace webbmvcapp.Models.Identity
{
    public class CustomIdentityUser : IdentityUser
    {
        [ProtectedPersonalData]
        public string FirstName { get; set; } = null!;

        [ProtectedPersonalData]
        public string LastName { get; set; } = null!;


    }
}
