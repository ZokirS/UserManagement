using System;
using Microsoft.AspNetCore.Identity;
using UserManagement.Constants;

namespace UserManagement.Entities
{
    public class User : IdentityUser
    {
        public DateTime LastSignInDate { get; set; }

        public DateTime SignUpDate { get; set; }

        public UserStatuses Status { get; set; }
    }
}
