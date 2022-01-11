using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class CourseCertificate
    {
        public Guid Id { get; set; }
        public string CertificateName { get; set; }
        public string CertificateDescription { get; set; }
        public Guid? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
