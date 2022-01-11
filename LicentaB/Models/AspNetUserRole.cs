using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class AspNetUserRole
    {
        public Guid UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRole Role { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
