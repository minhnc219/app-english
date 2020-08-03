using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ExampleRepository exampleRepository;
        public ExampleController(ExampleRepository exampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Example exampleToCreate)
        {
            if(exampleToCreate == null)
            {
                return BadRequest(ModelState);
            }    
            if(exampleRepository.ExampleExists(exampleToCreate.Id) == true)
            {
                ModelState.AddModelError("", $"{exampleToCreate.Id} already exists");
                return StatusCode(422);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!exampleRepository.Create(exampleToCreate))
            {
                ModelState.AddModelError("", $"Create Error");
                return StatusCode(500);
            }

            return Ok("Create Success");
        }

        [HttpPost]
        [Route("[action]/{exampleId}")]
        public IActionResult Update(string exampleId, Example exampleToUpdate)
        {
            if (exampleToUpdate == null)
            {
                return BadRequest(ModelState);
            }
            if (exampleId != exampleToUpdate.Id)
            {
                return BadRequest(ModelState);
            }
            if (!exampleRepository.ExampleExists(exampleId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!exampleRepository.Update(exampleToUpdate))
            {
                ModelState.AddModelError("", "Update Error");
                return StatusCode(500);
            }
            return Ok("Update Success");
        }

        [HttpDelete]
        [Route("[action]/{exampleId}")]
        public IActionResult Delete(string exampleId)
        {
            if (!exampleRepository.ExampleExists(exampleId))
            {
                return NotFound();
            }
            Example example = exampleRepository.GetExample(exampleId);
            if (!exampleRepository.Delete(example))
            {
                ModelState.AddModelError("", "Delete Error");
                return StatusCode(500);
            }
            return Ok("Delete Success");
        }
    }
}
