using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class TextAttrBindingsService
    {
        private ITextAttrBindingsRepo _textAttrBindingsRepo;
        public TextAttrBindingsService(ITextAttrBindingsRepo textAttrBindingsRepo)
        {
            _textAttrBindingsRepo = textAttrBindingsRepo;
        }

        public async Task<TextAttrBinding> CreateTextAttrBinding(TextAttrBinding textAttrBinding)
        {
            return await Task.FromResult(_textAttrBindingsRepo.CreateTextAttrBinding(textAttrBinding));
        }

        public async Task DeleteTextAttrBinding(int id)
        {
            await Task.CompletedTask;
            _textAttrBindingsRepo.DeleteTextAttrBinding(id);
        }

        public async Task<TextAttrBinding> GetTextAttrBinding(int id)
        {
            return await Task.FromResult(_textAttrBindingsRepo.GetTextAttrBinding(id));
        }

        public async Task<IEnumerable<TextAttrBinding>> GetTextAttrBindings(Expression<Func<TextAttrBinding, bool>> predicate)
        {
            return await Task.FromResult(_textAttrBindingsRepo.GetTextAttrBindings(predicate));
        }

        public async Task<TextAttrBinding> UpdateTextAttrBinding(TextAttrBinding textAttrBinding)
        {
            return await Task.FromResult(_textAttrBindingsRepo.UpdateTextAttrBinding(textAttrBinding));
        }
    }
}
