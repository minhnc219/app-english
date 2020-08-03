using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VocabularyTestController : ControllerBase
    {
        private readonly WordRepository wordRepository;
        private readonly ExampleRepository exampleRepository;
        public VocabularyTestController(WordRepository wordRepository, ExampleRepository exampleRepository)
        {
            this.wordRepository = wordRepository;
            this.exampleRepository = exampleRepository;
        }

        [HttpGet]
        [Route("[action]/{week}/{day}")]
        public IActionResult GetVocabularyTest(int week, int day)
        {
            List<Word> words = wordRepository.GetWordsByDay(week, day);
            List<DescriptionDto> descriptionDtos = new List<DescriptionDto>();
            foreach(Word word in words)
            {
                foreach(Definition definition in word.Definitions)
                {
                    foreach(Description description in definition.Descriptions)
                    {
                        descriptionDtos.Add(new DescriptionDto 
                        {
                            Word = word.Name,
                            Id = description.Id,
                            Detail = description.Detail,
                            WordType = definition.Type
                        });
                    }    
                }    
            }
            List<Example> examples = new List<Example>();
            List<VocabularyTest> vocabularies = new List<VocabularyTest>();
            Random rd = new Random();
            foreach(DescriptionDto dto in descriptionDtos)
            {
                examples = exampleRepository.GetExamples(dto.Id);
                int index = -1;
                if(examples.Count == 0)
                {
                    continue;
                }    
                else
                {
                    index = rd.Next(0, examples.Count);
                    vocabularies.Add(new VocabularyTest
                    {
                        Word = dto.Word,
                        Description = dto.Detail,
                        Type = dto.WordType,
                        Example = examples[index].Sentence,
                        Meaning = examples[index].Meaning
                    });
                    examples.Clear();
                }    
            }    
            return Ok(vocabularies);
        }
    }
}
