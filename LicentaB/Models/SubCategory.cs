using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Categories = new HashSet<Category>();
        }

        public Guid Id { get; set; }
        public string SubCategoryName { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
