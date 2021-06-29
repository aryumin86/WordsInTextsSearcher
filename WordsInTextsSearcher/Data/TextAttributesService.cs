using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class TextAttributesService
    {
        private ITextAttributesRepo _textAttributesRepo;
        private ITextAttributeValuesRepo _textAttributeValuesRepo;

        public TextAttributesService(ITextAttributesRepo textAttributesRepo, 
            ITextAttributeValuesRepo textAttributeValuesRepo)
        {
            _textAttributesRepo = textAttributesRepo;
            _textAttributeValuesRepo = textAttributeValuesRepo;
        }

        public async Task<TextAttribute> GetTextAttribute(int id)
        {
            return await Task.FromResult(_textAttributesRepo.GetTextAttribute(id));
        }

        public async Task<IEnumerable<TextAttribute>> GetTextAttributesAsync(Expression<Func<TextAttribute, bool>> predicate)
        {
            return await Task.FromResult(_textAttributesRepo.GetTextAttributes(predicate));
        }

        public async Task<TextAttribute> CreateTextAttribute(TextAttribute textAttribute)
        {
            return await Task.FromResult(_textAttributesRepo.CreateTextAttribute(textAttribute));
        }

        public async Task<TextAttribute> UpdateTextAttribute(TextAttribute textAttribute)
        {
            return await Task.FromResult(_textAttributesRepo.UpdateTextAttribute(textAttribute));
        }

        public async Task DeleteTextAttribute(int id)
        {
            await Task.CompletedTask;
            _textAttributesRepo.DeleteTextAttribute(id);
        }

        public async Task<TextAttributeValue> GetTextAttributeValue(int id)
        {
            return await Task.FromResult(_textAttributeValuesRepo.GetTextAttributeValue(id));
        }

        public async Task<IEnumerable<TextAttributeValue>> GetTextAttributeValues(Expression<Func<TextAttributeValue, bool>> predicate)
        {
            return await Task.FromResult(_textAttributeValuesRepo.GetTextAttributeValues(predicate));
        }

        public async Task<TextAttributeValue> CreateTextAttributeValue(TextAttributeValue textAttributeValue)
        {
            return await Task.FromResult(_textAttributeValuesRepo.CreateTextAttributeValue(textAttributeValue));
        }

        public async Task<TextAttributeValue> UpdateTextAttributeValue(TextAttributeValue textAttributeValue)
        {
            return await Task.FromResult(_textAttributeValuesRepo.UpdateTextAttributeValue(textAttributeValue));
        }
        public async Task DeleteTextAttributeValue(int id)
        {
            await Task.CompletedTask;
            _textAttributeValuesRepo.DeleteTextAttributeValue(id);
        }
    }
}
