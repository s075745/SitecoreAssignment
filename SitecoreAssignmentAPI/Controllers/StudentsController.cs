using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SitecoreAssignmentAPI.Controllers
{
    // https://localost:portnumber/api/students
    // port number we can get from launch setting.json
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
    }
}
