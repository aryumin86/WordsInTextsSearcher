using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public class WordsRepo : IWordsRepo
    {
        private SearcherDbContext _dbContext;
        public WordsRepo(SearcherDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Word CreateWord(Word word)
        {
            throw new NotImplementedException();
        }

        public void DeleteWord(int id)
        {
            throw new NotImplementedException();
        }

        public Word GetWord(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Word> GetWords(Expression<Func<Word, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Word UpdateWord(Word word)
        {
            throw new NotImplementedException();
        }
    }
}
