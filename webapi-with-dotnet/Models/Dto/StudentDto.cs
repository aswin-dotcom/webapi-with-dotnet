using System.ComponentModel.DataAnnotations;

namespace webapi_with_dotnet.Models.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
