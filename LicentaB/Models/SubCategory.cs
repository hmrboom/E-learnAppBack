using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class SubCategory
    {
        public Guid Id { get; set; }
        public string SubCategoryName { get; set; }
        public Guid? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
