using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class CourseType
    {
        public CourseType()
        {
            Courses = new HashSet<Course>();
        }

        public Guid Id { get; set; }
        public string CourseTypeName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
