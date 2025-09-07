using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_with_dotnet.Data;
using webapi_with_dotnet.Models;
using webapi_with_dotnet.Models.Dto;

namespace webapi_with_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class learningController : ControllerBase
    {
        [HttpGet]

        public IEnumerable<StudentDto> GetStudentName()
        {
            return StudentStore.students;
        }

        [HttpGet("{id:int}")]
        public StudentDto  getStudent(int  id)
        {
            return StudentStore.students.FirstOrDefault(item=>item.Id == id);   

        }
    }
}
