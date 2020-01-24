using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using quantum_it.Controllers.Resources;
using quantum_it.Core.Models;
using quantum_it.Core.Services;

namespace quantum_it.Controllers
{
    [Route("/api/classes")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService classService;
        private readonly ILogger<ClassController> logger;

        public ClassController(IClassService classService, ILogger<ClassController> logger)
        {
            this.classService = classService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            var classes = await classService.GetClassess();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClass(int id)
        {
            var classes = await classService.GetClass(id);
            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody]ClassResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await classService.CreateClass(resource);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(1003, ex, ex.Message);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditClass(int id, [FromBody]ClassResource resource)
        {
            if (id == 0 && !ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await classService.UpdateClass(id, resource);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            await classService.DeleteClass(id);
            return Ok();
        }
    }
}