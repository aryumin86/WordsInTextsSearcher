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

        public WordFormsRepo(SearcherDbContext dbContext, AppConf appConf)
        {
            _dbContext = dbContext;
            _appConf = appConf;
        }
        public WordForm CreateWordForm(WordForm wordForm)
        {
            //using var ctx = new SearcherDbContext(_appConf.MainDbConnString);
            _dbContext.WordForms.Add(wordForm);
            _dbContext.SaveChanges();
            return wordForm;
        }

        public void DeleteWordForm(int id)
        {
            //using var ctx = new SearcherDbContext(_appConf.MainDbConnString);
            var wordForm = _dbContext.WordForms.Find(id);
            _dbContext.Remove(wordForm);
            _dbContext.SaveChanges();
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
            return wordForm;
        }
    }
}
