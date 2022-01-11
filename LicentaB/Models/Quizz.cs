using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class Quizz
    {
        public Guid Id { get; set; }
        public string QuestionName { get; set; }
        public string Answers { get; set; }
        public string CorrectAnswer { get; set; }
        public int? Score { get; set; }
        public Guid? ModuleId { get; set; }

        public virtual Module Module { get; set; }
    }
}
