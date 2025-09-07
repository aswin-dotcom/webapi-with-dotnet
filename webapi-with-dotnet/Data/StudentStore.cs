using webapi_with_dotnet.Models.Dto;

namespace webapi_with_dotnet.Data
{
    public static class StudentStore
    {

         public static List<StudentDto> students = new List<StudentDto>
            {
                new StudentDto{ Id = 1 ,Name="Aswin Samuvel"},
                new StudentDto{ Id = 2 ,Name = "Sherin Roopa" }
            };
    }
}
