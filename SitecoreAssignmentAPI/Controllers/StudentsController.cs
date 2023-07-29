using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SitecoreAssignmentAPI.Controllers
{
    // https://localost:portnumber/api/students
    // port number we can get from launchsetting.json
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        //GET: https://localost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudents() 
        {
            string[] studentNames = new string[] { "Shubham", "Namdeo" };
            return Ok(studentNames);   
        
        }

    }
}
