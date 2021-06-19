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
        public WordsService(IWordsRepo wordsRepo)
        {
            _wordsRepo = wordsRepo;
        }
        public async Task<IEnumerable<Word>> GetWords(Expression<Func<Word, bool>> predicate)
        {
            return await Task.FromResult(_wordsRepo.GetWords(predicate));
        }

        public async Task<Word> CreateWord(Word word)
        {
            return await Task.FromResult(_wordsRepo.CreateWord(word));
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
