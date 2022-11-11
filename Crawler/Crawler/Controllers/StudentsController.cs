using Microsoft.AspNetCore.Mvc;

using Crawler.Models;
using Crawler.Services;

namespace Crawler.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentsService.GetStudents();
            return Ok(students);
        }

        [HttpGet("{index}")]
        public IActionResult GetStudent(string index)
        {
            var student = _studentsService.GetStudent(index);
            return Ok(student);
        }

        [HttpPut("{index}")]
        public IActionResult UpdateStudent(string index, Student student)
        {
            var updatedStudent = _studentsService.UpdateStudent(index, student);
            return Ok(updatedStudent);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            var newStudent = _studentsService.CreateStudent(student);
            return Ok(newStudent);
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteStudent(string index)
        {
            var deletedStudent = _studentsService.DeleteStudent(index);
            return Ok(deletedStudent);
        }
    }
}
