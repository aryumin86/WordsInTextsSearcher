using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private ILogger<WordsRepo> _logger;

        public WordsRepo(SearcherDbContext dbContext, ILogger<WordsRepo> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public Word CreateWord(Word word)
        {
            _dbContext.Words.Add(word);
            _dbContext.SaveChanges();
            _logger.LogInformation($"Word '{word.Text}' ({word.Id}) created");
            return word;
        }

        public void DeleteWord(int id)
        {
            var word = _dbContext.Words.Find(id);
            _dbContext.Remove(word);            
            _dbContext.SaveChanges();
            _logger.LogInformation($"Word '{word.Text}' ({word.Id}) removed");
        }

        public Word GetWord(int id)
        {
            return _dbContext.Words.Find(id);
        }

        public IEnumerable<Word> GetWords(Expression<Func<Word, bool>> predicate)
        {
            return _dbContext.Words.Include(w => w.WordForms).Where(predicate);
        }

        public Word UpdateWord(Word word)
        {
            _dbContext.Words.Update(word);
            _dbContext.SaveChanges();
            _logger.LogInformation($"Word '{word.Text}' ({word.Id}) updated");
            return word;
        }
    }
}
