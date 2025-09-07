using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_with_dotnet.Models;

namespace webapi_with_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class learningController : ControllerBase
    {
        [HttpGet]

        public IEnumerable<Student> GetStudentName()
        {
            return new List<Student>
            {
                new Student{ Id = 1 ,Name="Aswin Samuvel"},
                new Student{ Id = 2 ,Name = "Sherin Roopa" }
            };
        }

    }
}
