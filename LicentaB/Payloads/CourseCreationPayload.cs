using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Payloads
{
    public class CourseCreationPayload
    {
        
        public string CourseName { get; set; }
        public string WhatLearn { get; set; }
        public string Description { get; set; }
        public string Req { get; set; }
        public int Price { get; set; }
        public int ModuleNumber { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? UserId { get; set; }

    }
}
