using LicentaB.Models;
using LicentaB.Payloads;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicentaB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly dbLicentaContext _db;
        private readonly ILogger<CourseController> _logger;
        private IConfiguration _config { get; }

        public CourseController(dbLicentaContext db, ILogger<CourseController> logger, IConfiguration configuration)
        {
            _db = db;
            _logger = logger;
            _config = configuration;
        }

        [HttpPost("subCategory")]
        public async Task<IActionResult> SubCreate([FromBody] SubCategoryPayload createPayload)
        {
            try
            {
                
                var subCategoryCreate = new SubCategory
                {
                    Id = Guid.NewGuid(),
                    SubCategoryName = createPayload.subCategory_name,
                    CategoryId = createPayload.categoryId
                };
                var foundCategory = _db.Categories
               .SingleOrDefault(u => u.Id == createPayload.categoryId);

                if (foundCategory != null)
                {
                    _db.SubCategories.Add(subCategoryCreate);
                    _db.SaveChanges();
                    return Ok(new { status = true, message = "sub Creat" });
                }
                else return BadRequest("Eror?");


            }
            catch (Exception e)
            {
                return new JsonResult(new { err = e.Message });
            }
        }
        [HttpPost("category")]
        public async Task<IActionResult> CatCreate([FromBody] CategoriesPayload createPayload)
        {
            try
            {
                var categoryCreate = new Category
                {
                    Id = Guid.NewGuid(),
                    CategoryName = createPayload.categoryName
                };
                _db.Categories.Add(categoryCreate);
                _db.SaveChanges();
                return Ok(new { status = true, message = "Categ Creat" });

            }
            catch (Exception e)
            {
                return new JsonResult(new { err = e.Message });
            }
        }
        [HttpGet("getCategories")]
        public ActionResult<List<Category>> GetCategories()
        {
            try
            {
                return _db.Categories.Include(course => course.Courses).Include(c => c.SubCategories).ToList();

            }
            catch(Exception e)
            {
                return new JsonResult(new { err = e.Message });
            }
        }
        [HttpGet("getCourses")]
        public ActionResult<List<Course>> GetCourses()
        {
            try
            {
                return _db.Courses.Include(module => module.Modules).Include(c => c.User)
                    .ToList();

            }
            catch (Exception e)
            {
                return new JsonResult(new { err = e.Message });
            }
        }
        [HttpGet("getTypeCourse")]
        public ActionResult<List<CourseType>> GetType()
        {
            try
            {
                return _db.CourseTypes.Include(c => c.Courses).ToList();

            }
            catch (Exception e)
            {
                return new JsonResult(new { err = e.Message });
            }
        }
        [HttpPost("courseCreation")]
        public async Task<IActionResult> CourseCreate([FromBody] CourseCreationPayload createPayload)
        {
            try
            {

                var CourseCreate = new Course
                {
                    Id = Guid.NewGuid(),
                    CourseName = createPayload.CourseName,
                    CourseDescription = createPayload.Description,
                    CoursePrice = createPayload.Price,
                    CourseRating = 0,
                    CourseRequirement = createPayload.Req,
                    WhatLearning = createPayload.WhatLearn,
                    CourseModulesNumber = createPayload.ModuleNumber,
                    CourseTypeId = createPayload.TypeId,
                    UserId = createPayload.UserId,
                    CategoryId = createPayload.CategoryId
                };
                var foundUser = _db.AspNetUsers
               .SingleOrDefault(u => u.Id == createPayload.UserId);

                if (foundUser != null)
                {
                    _db.Courses.Add(CourseCreate);
                    _db.SaveChanges();
                    return Ok(new { status = true, message = "Curs Creat" });
                }
                else return BadRequest("Eror?");


            }
            catch (Exception e)
            {
                return new JsonResult(new { err = e.Message });
            }
        }
        [HttpPost("module")]
        public async Task<IActionResult> ModCreate([FromBody] ModuleCreation createPayload)
        {
            try
            {
                var moduleCreate = new Module
                {
                    Id = Guid.NewGuid(),
                    ModuleName = createPayload.Module_name,
                    ModuleDescription = createPayload.Module_description,
                    LessonNumber = createPayload.Lesson_number,
                    CourseId = createPayload.CourseId

                };
                var foundCourse = _db.Courses
               .SingleOrDefault(u => u.Id == createPayload.CourseId);

                if (foundCourse != null)
                {
                    _db.Modules.Add(moduleCreate);
                    _db.SaveChanges();
                    return Ok(new { status = true, message = "Modul Creat" });
                }
                else return BadRequest("Eror?");


            }
            catch (Exception e)
            {
                return new JsonResult(new { err = e.Message });
            }
        }
        [HttpGet("getCourseById")]
        public ActionResult<Course> GetById(Guid Id)
        {
            return _db.Courses
                .Include(module => module.Modules)
                .ThenInclude(les=>les.Lessons)
                .Where(course => Id == course.Id)
                .Single();
        }
        [HttpPost("goToWishlist")]
        public async Task<IActionResult> AddToWish([FromBody] WishListPayload createPayload)
        {
            try
            {
                var wishList = new WishList
                {
                    Id = Guid.NewGuid(),
                    UserId = createPayload.UserId,
                    CourseId = createPayload.CourseId
                };
                var foundCourse = _db.WishLists
              .SingleOrDefault(u => u.CourseId == wishList.CourseId);
                if (foundCourse == null)
                {


                    _db.WishLists.Add(wishList);
                    _db.SaveChanges();
                    return Ok(new { status = true, message = "wishlist Creat" });
                }
                else return Ok(new { status = true, message = "nu mere" });
            }
            catch (Exception e)
            {
                return new JsonResult(new { err = e.Message });
            }
        }
        [HttpPost("payCourse")]
        public async Task<IActionResult> PayCourse([FromBody] EnrolmentPayload createPayload)
        {
            try
            {
                DateTime date = DateTime.UtcNow;
               
                var payment = new StudentEnrolment
                {
                    Id = Guid.NewGuid(),
                    DateEnrolment = date,
                    UserId = createPayload.UserId,
                    CourseId = createPayload.CourseId,
                    PaymentTypeId = createPayload.PaymentTypeId
                };
                var foundCourse = _db.StudentEnrolments
              .SingleOrDefault(u => u.CourseId == payment.CourseId);
                if (foundCourse == null)
                {


                    _db.StudentEnrolments.Add(payment);
                    
                   WishList course = _db.WishLists.Where(courseId => courseId.CourseId == payment.CourseId).First();
                    _db.WishLists.Remove(course);
                    _db.SaveChanges();

                    return Ok(new { status = true, message = "Student Inrolat" });
                }
                else return Ok(new { status = true, message = "nu mere" });
            }
            catch (Exception e)
            {
                return new JsonResult(new { err = e.Message });
            }
        }


    }
}
