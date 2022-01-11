using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            StudentEnrolments = new HashSet<StudentEnrolment>();
        }

        public Guid Id { get; set; }
        public string PaymentType1 { get; set; }

        public virtual ICollection<StudentEnrolment> StudentEnrolments { get; set; }
    }
}
