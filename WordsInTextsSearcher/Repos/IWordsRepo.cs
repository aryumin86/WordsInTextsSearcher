using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public interface IWordsRepo
    {
        public IEnumerable<Word> GetWords(Expression<Func<Word, bool>> predicate);
        public Word GetWord(int id);
        public Word CreateWord(Word word);
        public Word UpdateWord(Word word);
        public void DeleteWord(int id);

    }
}
