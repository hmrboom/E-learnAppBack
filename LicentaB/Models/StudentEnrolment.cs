using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class StudentEnrolment
    {
        public Guid Id { get; set; }
        public DateTime? DateEnrolment { get; set; }
        public DateTime? DateCompletion { get; set; }
        public Guid? UserId { get; set; }
        public Guid? PaymentTypeId { get; set; }
        public Guid? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
