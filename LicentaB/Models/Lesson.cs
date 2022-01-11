using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class Lesson
    {
        public Guid Id { get; set; }
        public string LessonName { get; set; }
        public string LessonVideoPath { get; set; }
        public string LessonPdf { get; set; }
        public DateTime? LessonLiveStreamDate { get; set; }
        public Guid? ModuleId { get; set; }

        public virtual Module Module { get; set; }
    }
}
