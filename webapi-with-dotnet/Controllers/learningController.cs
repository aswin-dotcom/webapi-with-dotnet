using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
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

        public ActionResult<IEnumerable<StudentDto>> GetStudentName()
        {
            return Ok(StudentStore.students);
        }

        [HttpGet("{id:int}",Name = "getStudent")]
        public ActionResult<StudentDto> getStudent(int  id)
        {
            if(id == 0)
            {
                return BadRequest();
            } 
             var student  = StudentStore.students.FirstOrDefault(item => item.Id == id);

            if(student == null)
            {
                return NotFound();
            }


            return Ok(student);

        }
            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDto> CreateStudent([FromBody]StudentDto student)
        {
            if(StudentStore.students.FirstOrDefault(u=>u.Name.ToLower() == student.Name.ToLower())!=null)
            {
                ModelState.AddModelError("Custom Error", "UserName already Exists");
                return BadRequest(ModelState);

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (student ==  null)
            {
                return BadRequest();
            }
            if(student.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            student.Id = StudentStore.students.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            StudentStore.students.Add(student);
            return CreatedAtRoute("getStudent",new { id = student.Id }, student);


        }
        [HttpDelete("{id:int}",Name = "DeleteStudent")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<StudentDto> Delete(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var student  =  StudentStore.students.FirstOrDefault(student=>student.Id == id);
            if(student == null)
            {
                return NotFound();
            }
           StudentStore.students.Remove(student);

            return NoContent();


        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentDto> UpdateStudent(int id ,[FromBody]StudentDto student)
        {
            if(id != student.Id || student == null)
            {
                return BadRequest();
            }
            var students  =  StudentStore.students.FirstOrDefault(u=>u.Id == id);
            if(students == null)
            {
                return NotFound();

            }
            students.Name = student.Name;
            return NoContent();

        }

        [HttpPatch]
        public ActionResult<StudentDto> patch( int id , JsonPatchDocument<StudentDto> patch)
        {
            if(id == 0 || patch ==  null)
            {
                return BadRequest();
            }
            var students = StudentStore.students.FirstOrDefault(student => student.Id == id);
            if(students == null)
            {
                return NotFound();
            }
            patch.ApplyTo(students);
            return NoContent();

        }

    }
}
