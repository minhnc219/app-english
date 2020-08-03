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
    public class DescriptionController : ControllerBase
    {
        private readonly DescriptionRepository descriptionRepository;
        public DescriptionController(DescriptionRepository descriptionRepository)
        {
            this.descriptionRepository = descriptionRepository;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Description descriptionToCreate)
        {
            if(descriptionToCreate == null)
            {
                return BadRequest(ModelState);
            }    
            if(descriptionRepository.DescriptionExists(descriptionToCreate.Id) == true)
            {
                ModelState.AddModelError("", $"{descriptionToCreate.Id} already exists");
                return StatusCode(422);
            }    
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    
            if(!descriptionRepository.Create(descriptionToCreate))
            {
                ModelState.AddModelError("", $"Create Error");
                return StatusCode(500);
            }    
            return Ok("Create Success");
        }

        [HttpPost]
        [Route("[action]/{descriptionId}")]
        public IActionResult Update(string descriptionId, Description descriptionToUpdate)
        {
            if(descriptionToUpdate == null)
            {
                return BadRequest(ModelState);
            }    
            if(descriptionToUpdate.Id != descriptionId)
            {
                return BadRequest(ModelState);
            }
            if (!descriptionRepository.DescriptionExists(descriptionId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!descriptionRepository.Update(descriptionToUpdate))
            {
                ModelState.AddModelError("", "Update Error");
                return StatusCode(500);
            }
            return Ok("Update Success");
        }

        [HttpDelete]
        [Route("[action]/{descriptionId}")]
        public IActionResult Delete(string descriptionId)
        {
            if(!descriptionRepository.DescriptionExists(descriptionId))
            {
                return NotFound();
            }
            Description description = descriptionRepository.GetDescription(descriptionId);
            if (!descriptionRepository.Delete(description))
            {
                ModelState.AddModelError("", "Delete Error");
                return StatusCode(500);
            }
            return Ok("Delete Success");
        }
    }
}
