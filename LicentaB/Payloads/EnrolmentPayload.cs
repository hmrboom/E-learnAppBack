using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class EnrolmentPayload
    {
        [Required]
        public Guid? UserId { get; set; }
        [Required]
        public Guid? CourseId { get; set; }
        [Required]
        public Guid? PaymentTypeId { get; set; }
    }
}
