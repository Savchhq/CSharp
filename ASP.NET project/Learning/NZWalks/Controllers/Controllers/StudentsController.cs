using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentsName = new string[] {"Vlad", "Sasha", "Danya", "Dima"};
            return Ok(studentsName);
        }
    }
}
