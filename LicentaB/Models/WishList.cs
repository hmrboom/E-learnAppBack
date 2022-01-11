using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class WishList
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
