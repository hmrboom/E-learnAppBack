using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class CreatePayload
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseDescription { get; set; }
        public int CoursePrice { get; set; }
        [Required]
        public int CourseModulesNumber { get; set; }
        [Required]
        public string WhatLearning { get; set; }

    }
}
