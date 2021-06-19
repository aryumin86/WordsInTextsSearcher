using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class WordFormsService
    {
        private IWordFormsRepo _wordFormsRepo;

        public WordFormsService(IWordFormsRepo wordFormsRepo)
        {
            _wordFormsRepo = wordFormsRepo;
        }
        public async Task<WordForm> CreateWordForm(WordForm wordForm)
        {
            return await Task.FromResult(_wordFormsRepo.CreateWordForm(wordForm));
        }

        public async Task<WordForm> UpdateWordForm(WordForm wordForm)
        {
            return await Task.FromResult(_wordFormsRepo.UpdateWordForm(wordForm));
        }

        public async Task<IEnumerable<WordForm>> GetWordForms(Expression<Func<WordForm, bool>> predicate)
        {
            return await Task.FromResult(_wordFormsRepo.GetWordForms(predicate));
        }

        public async Task DeleteWordForm(int id)
        {
            await Task.CompletedTask;
            _wordFormsRepo.DeleteWordForm(id);
        }
    }
}
