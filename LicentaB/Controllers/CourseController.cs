using LicentaB.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("courseCreate")]
        [A]
        public async Task<IActionResult> Create([FromBody] CreatePayload createPayload)
        {
            try
            {

            }
            catch (Exception e)
            {

            }
        }
    }
}
