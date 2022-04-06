using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class CategoriesPayload
    {
        [Required]
        public string categoryName { get; set; }

    }
}
