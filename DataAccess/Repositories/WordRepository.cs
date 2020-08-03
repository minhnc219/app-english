using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class WordRepository : RepositoryBase<Word>, IWordRepository
    {
        public WordRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
        public Word GetWord(string wordId)
        {
            return dbSet.Where(word => word.Id == wordId).FirstOrDefault();
        }

        public List<Word> GetWordsByDay(int week, int day)
        {
            return dbSet.Where(word => word.Week == week && word.Day == day)
                .Include(word => word.Definitions)
                .ToList();
        }

        public bool IsDuplicateName(string wordId, string name)
        {
            Word word = dbSet.Where(w => w.Id != wordId && w.Name.Trim().ToLower() == name.Trim().ToLower()).FirstOrDefault();
            return word == null ? false : true;
        }

        public bool WordExists(string wordId)
        {
            return dbSet.Any(word => word.Id == wordId);
        }
    }
}
