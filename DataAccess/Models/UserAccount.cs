using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models1
{
    public partial class UserAccount
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public int? Role { get; set; }
    }
}
