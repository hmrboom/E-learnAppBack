using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class CourseCreate
    {
        public CourseCreate()
        {
            Courses = new HashSet<Course>();
        }

        public Guid Id { get; set; }
        public DateTime? DataCreation { get; set; }
        public Guid? UserId { get; set; }

        public virtual AspNetUser User { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
