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

        public WordFormsRepo(SearcherDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public WordForm CreateWordForm(WordForm wordForm)
        {
            throw new NotImplementedException();
        }

        public void DeleteWordForm(int id)
        {
            throw new NotImplementedException();
        }

        public WordForm GetWordForm(int wordFormId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WordForm> GetWordForms(Expression<Func<WordForm, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public WordForm UpdateWordForm(WordForm wordForm)
        {
            throw new NotImplementedException();
        }
    }
}
