using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class CreateLessonPayload
    {
        public string LessonName { get; set; }
        public string pdfPath { get; set; }
        public string videoPath { get; set; }
        public Guid? ModuleId { get; set; }
        public DateTime? liveStreamDate { get; set; }
    }
}
