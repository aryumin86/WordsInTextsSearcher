using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public class WordFormsRepo : IWordFormsRepo
    {
        private SearcherDbContext _dbContext;
        private AppConf _appConf;
        private ILogger<WordFormsRepo> _logger;
        public WordFormsRepo(SearcherDbContext dbContext, AppConf appConf,
            ILogger<WordFormsRepo> logger)
        {
            _dbContext = dbContext;
            _appConf = appConf;
            _logger = logger;
        }
        public WordForm CreateWordForm(WordForm wordForm)
        {
            _dbContext.WordForms.Add(wordForm);
            _dbContext.SaveChanges();
            _logger.LogInformation($"Word form '{wordForm.Text}' ({wordForm.Id}) for word {wordForm.WordId} added");
            return wordForm;
        }

        public void DeleteWordForm(int id)
        {
            var wordForm = _dbContext.WordForms.Find(id);
            _dbContext.Remove(wordForm);            
            _dbContext.SaveChanges();
            _logger.LogInformation($"Word form '{wordForm.Text}' ({wordForm.Id}) for word {wordForm.WordId} deleted");
        }

        public WordForm GetWordForm(int wordFormId)
        {
            return _dbContext.WordForms.Find(wordFormId);
        }

        public IEnumerable<WordForm> GetWordForms(Expression<Func<WordForm, bool>> predicate)
        {
            return _dbContext.WordForms.Where(predicate);
        }

        public WordForm UpdateWordForm(WordForm wordForm)
        {
            _dbContext.WordForms.Update(wordForm);
            _dbContext.SaveChanges();
            _logger.LogInformation($"Word form '{wordForm.Text}' ({wordForm.Id}) for word {wordForm.WordId} updated");
            return wordForm;
        }
    }
}
