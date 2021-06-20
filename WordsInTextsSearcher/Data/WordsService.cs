using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class WordsService
    {
        private IWordsRepo _wordsRepo;
        private IWordFormsRepo _wordFormsRepo;
        public WordsService(IWordsRepo wordsRepo, IWordFormsRepo wordFormsRepo)
        {
            _wordsRepo = wordsRepo;
            _wordFormsRepo = wordFormsRepo;
        }
        public async Task<IEnumerable<Word>> GetWords(Expression<Func<Word, bool>> predicate)
        {
            return await Task.FromResult(_wordsRepo.GetWords(predicate));
        }

        public async Task<Word> CreateWord(Word word)
        {
            _wordsRepo.CreateWord(word);

            var defaultWordForm = new WordForm
            {
                WhenCreated = DateTime.Now,
                Text = word.Text,
                WordId = word.Id,
                Word = word
            };
            word.WordForms = new List<WordForm> { defaultWordForm };
            _wordFormsRepo.CreateWordForm(defaultWordForm);

            return await Task.FromResult(word);
        }

        public async Task<Word> UpdateWord(Word word)
        {
            return await Task.FromResult(_wordsRepo.UpdateWord(word));
        }

        public async Task DeleteWord(int id)
        {
            await Task.CompletedTask;
            _wordsRepo.DeleteWord(id);
        }
    }
}
