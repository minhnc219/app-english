using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class DefinitionRepository : RepositoryBase<Definition>, IDefinitionRepository
    {
        public DefinitionRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public bool DefinitionExists(string definitionId)
        {
            return dbSet.Any(definition => definition.Id == definitionId);
        }

        public Definition GetDefinition(string definitionId)
        {
            return dbSet.Where(definition => definition.Id == definitionId).FirstOrDefault();
        }

        public List<Definition> GetDefinitions(string wordId)
        {
            return dbContext.Words.Where(word => word.Id == wordId).FirstOrDefault().Definitions;
        }

        public bool IsDuplicatedWordType(string wordId, WordType wordType)
        {
            List<Definition> definitions = dbContext.Definitions.Where(definition => definition.WordId == wordId).AsNoTracking().ToList();
            for(int i = 0; i < definitions.Count; i++)
            {
                if(definitions[i].Type == wordType)
                {
                    return true;
                }    
            }
            return false;
        }
        public bool IsDuplicateWordTypeUpdate(string wordId, string definitionId, WordType wordType)
        {
            List<Definition> definitions = dbContext.Definitions.Where(definition => definition.WordId == wordId).AsNoTracking().ToList();
            for (int i = 0; i < definitions.Count; i++)
            {
                if (definitions[i].Type == wordType && definitions[i].Id != definitionId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
