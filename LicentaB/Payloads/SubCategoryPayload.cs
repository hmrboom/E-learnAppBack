using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class SubCategoryPayload
    {
        [Required]
        public string subCategory_name { get; set; }
        [Required]
        public Guid categoryId { get; set; }
       
    }
}
