using System;
using System.Collections.Generic;

namespace Flight.Models
{
    public partial class User
    {
        public int UsersId { get; set; }
        public string? UsersName { get; set; }
        public string? UsersEmail { get; set; }
        public string? UsersPassword { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}
