using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class Module
    {
        public Module()
        {
            Lessons = new HashSet<Lesson>();
            Quizzs = new HashSet<Quizz>();
        }

        public Guid Id { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public int? LessonNumber { get; set; }
        public Guid? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Quizz> Quizzs { get; set; }
    }
}
