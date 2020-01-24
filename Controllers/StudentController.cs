using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using quantum_it.Controllers.Resources;
using quantum_it.Core.Services;

namespace quantum_it.Controllers
{
    [Route("/api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly ILogger<StudentController> logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            this.logger = logger;
            this.studentService = studentService;
        }

        [HttpGet("{classId}")]
        public async Task<IActionResult> GetStudents(int classId)
        {
            var classes = await studentService.GetStudentsByClassId(classId);
            return Ok(classes);
        }

        [HttpGet("{classId}/{studentId}")]
        public async Task<IActionResult> GetStudent(int classId, int studentId)
        {
            var classes = await studentService.GetStudent(studentId);
            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody]StudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await studentService.CreateStudent(resource);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(1003, ex, ex.Message);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(int id, [FromBody]StudentResource resource)
        {
            if (id == 0 && !ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await studentService.UpdateStudent(id, resource);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await studentService.DeleteStudent(id);
            return Ok();
        }
    }
}