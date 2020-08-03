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
    public class DefinitionController : ControllerBase
    {
        private readonly DefinitionRepository definitionRepository;
        public DefinitionController(DefinitionRepository definitionRepository)
        {
            this.definitionRepository = definitionRepository;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Definition definitionToCreate)
        {
            if (definitionToCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (definitionRepository.DefinitionExists(definitionToCreate.Id) == true)
            {
                ModelState.AddModelError("", $"{definitionToCreate.Id} already exists");
                return StatusCode(422);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (definitionRepository.IsDuplicatedWordType(definitionToCreate.WordId, definitionToCreate.Type))
            {
                ModelState.AddModelError("", $"{definitionToCreate.Type} already exists");
                return StatusCode(422);
            }
            if (!definitionRepository.Create(definitionToCreate))
            {
                ModelState.AddModelError("", $"Create Error");
                return StatusCode(500);
            }
 
            return Ok("Create Success");
        }

        [HttpPost]
        [Route("[action]/{definitionId}")]
        public IActionResult Update(string definitionId, Definition definitionToUpdate)
        {
            if (definitionToUpdate == null)
            {
                return BadRequest(ModelState);
            }
            if (definitionId != definitionToUpdate.Id)
            {
                return BadRequest(ModelState);
            }
            if (!definitionRepository.DefinitionExists(definitionId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(definitionRepository.IsDuplicateWordTypeUpdate(definitionToUpdate.WordId, definitionId, definitionToUpdate.Type))
            {
                ModelState.AddModelError("", $"{definitionToUpdate.Type} already exists");
                return StatusCode(422);
            }    
            if (!definitionRepository.Update(definitionToUpdate))
            {
                ModelState.AddModelError("", "Update Error");
                return StatusCode(500);
            }
            return Ok("Update Success");
        }

        [HttpDelete]
        [Route("[action]/{definitionId}")]
        public IActionResult Delete(string definitionId)
        {
            if (!definitionRepository.DefinitionExists(definitionId))
            {
                return NotFound();
            }
            Definition definition = definitionRepository.GetDefinition(definitionId);
            if (!definitionRepository.Delete(definition))
            {
                ModelState.AddModelError("", "Delete Error");
                return StatusCode(500);
            }
            return Ok("Delete Success");
        }
    }
}
