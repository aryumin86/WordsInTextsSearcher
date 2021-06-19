using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public interface IWordFormsRepo
    {
        public IEnumerable<WordForm> GetWordForms(Expression<Func<WordForm, bool>> predicate);
        public WordForm GetWordForm(int wordFormId);
        public WordForm CreateWordForm(WordForm wordForm);
        public WordForm UpdateWordForm(WordForm wordForm);
        public void DeleteWordForm(int id);
    }
}
