using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IDefinitionRepository
    {
        bool DefinitionExists(string definitionId);
        Definition GetDefinition(string definitionId);
        List<Definition> GetDefinitions(string wordId);
        bool IsDuplicatedWordType(string wordId, WordType wordType);
        bool IsDuplicateWordTypeUpdate(string wordId, string definitionId, WordType wordType);
    }
}   
