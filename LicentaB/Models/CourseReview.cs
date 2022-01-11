using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class CourseReview
    {
        public Guid Id { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set; }
        public int? ReviewRating { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
