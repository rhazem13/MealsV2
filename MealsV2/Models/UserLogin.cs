using System;
using System.Collections.Generic;

namespace MealsV2.Models
{
    public partial class UserLogin
    {
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } 

        public byte[] PasswordSalt { get; set; }
        public int? UserId { get; set; }

        public virtual UserDatum? User { get; set; }
    }
}
