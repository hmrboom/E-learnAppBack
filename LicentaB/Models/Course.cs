using System;
using System.Collections.Generic;

#nullable disable

namespace LicentaB.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseCertificates = new HashSet<CourseCertificate>();
            CourseReviews = new HashSet<CourseReview>();
            Modules = new HashSet<Module>();
            StudentEnrolments = new HashSet<StudentEnrolment>();
            WishLists = new HashSet<WishList>();
        }

        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int? CoursePrice { get; set; }
        public int? CourseRating { get; set; }
        public int? CourseModulesNumber { get; set; }
        public string WhatLearning { get; set; }
        public Guid? CourseTypeId { get; set; }
        public string CourseRequirement { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual CourseCreate UserNavigation { get; set; }
        public virtual ICollection<CourseCertificate> CourseCertificates { get; set; }
        public virtual ICollection<CourseReview> CourseReviews { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<StudentEnrolment> StudentEnrolments { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
