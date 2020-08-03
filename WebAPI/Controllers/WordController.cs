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
    public class WordController : ControllerBase
    {
        private readonly WordRepository wordRepository;
        public WordController(WordRepository wordRepository)
        {
            this.wordRepository = wordRepository;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] Word wordToCreate)
        {
            if(wordToCreate == null)
            {
                return BadRequest(ModelState);
            }    
            if(wordRepository.WordExists(wordToCreate.Id) == true)
            {
                ModelState.AddModelError("", $"{wordToCreate.Name} already exists");
                return StatusCode(422);
            }    
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }    
            if(!wordRepository.Create(wordToCreate))
            {
                ModelState.AddModelError("", $"Create Error");
                return StatusCode(500);
            }
            return Ok("Create Success");
        }

        [HttpPost]
        [Route("[action]/{wordId}")]
        public IActionResult Update(string wordId, [FromBody] Word wordToUpdate)
        {
            if(wordToUpdate == null)
            {
                return BadRequest(ModelState);
            }    
            if(wordId != wordToUpdate.Id)
            {
                return BadRequest(ModelState);
            }    
            if(!wordRepository.WordExists(wordId))
            {
                return NotFound();
            }    
            if(wordRepository.IsDuplicateName(wordId, wordToUpdate.Name))
            {
                ModelState.AddModelError("", $"{wordToUpdate.Name} already exists");
                return StatusCode(422);
            }    
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    
            if(!wordRepository.Update(wordToUpdate))
            {
                ModelState.AddModelError("", "Update Error");
                return StatusCode(500);
            }
            return Ok("Update Success");

        }

        [HttpDelete]
        [Route("[action]/{wordId}")]
        public IActionResult Delete(string wordId)
        {
            if(!wordRepository.WordExists(wordId))
            {
                return NotFound();
            }
            Word word = wordRepository.GetWord(wordId);
            if(!wordRepository.Delete(word))
            {
                ModelState.AddModelError("", "Delete Error");
                return StatusCode(500);
            }    
            return Ok("Delete Success");
        }
    }
}
