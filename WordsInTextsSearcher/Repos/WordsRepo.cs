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
            _dbContext.Words.Add(word);
            _dbContext.SaveChanges();
            return word;
        }

        public void DeleteWord(int id)
        {
            var word = _dbContext.Words.Find(id);
            _dbContext.Remove(word);
            _dbContext.SaveChanges();
        }

        public Word GetWord(int id)
        {
            return _dbContext.Words.Find(id);
        }

        public IEnumerable<Word> GetWords(Expression<Func<Word, bool>> predicate)
        {
            return _dbContext.Words.Where(predicate);
        }

        public Word UpdateWord(Word word)
        {
            _dbContext.Words.Update(word);
            _dbContext.SaveChanges();
            return word;
        }
    }
}
