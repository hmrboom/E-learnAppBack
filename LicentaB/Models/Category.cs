using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
            SubCategories = new HashSet<SubCategory>();
        }

        public Guid Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
