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
        }

        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid? SubcategoryId { get; set; }

        public virtual SubCategory Subcategory { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
