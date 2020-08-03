using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IWordRepository
    {
        bool WordExists(string wordId);
        Word GetWord(string wordId);
        List<Word> GetWordsByDay(int week, int day);
        bool IsDuplicateName(string wordId, string name);
    }
}
