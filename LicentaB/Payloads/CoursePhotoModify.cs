using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class CoursePhotoModify
    {
        public Guid? Id { get; set; }
        public string CoursePhoto { get; set; }
    }
}
