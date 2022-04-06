using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class ModuleCreation
    {
        public string Module_name { get; set; }
        public string Module_description { get; set; }
        public int Lesson_number { get; set; }
        public Guid? CourseId { get; set; }
    }
}
