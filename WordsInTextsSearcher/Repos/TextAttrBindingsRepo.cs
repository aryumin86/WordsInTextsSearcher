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
    public class TextAttrBindingsRepo : ITextAttrBindingsRepo
    {
        private SearcherDbContext _searcherDbContext;
        private ILogger<TextAttrBindingsRepo> _logger;

        public TextAttrBindingsRepo(SearcherDbContext searcherDbContext, ILogger<TextAttrBindingsRepo> logger)
        {
            _searcherDbContext = searcherDbContext;
            _logger = logger;
        }

        public TextAttrBinding CreateTextAttrBinding(TextAttrBinding textAttrBinding)
        {
            _searcherDbContext.TextAttrBindings.Add(textAttrBinding);
            _searcherDbContext.SaveChanges();
            return textAttrBinding;
        }

        public void DeleteTextAttrBinding(int id)
        {
            var tab = _searcherDbContext.TextAttrBindings.Find(id);
            _searcherDbContext.TextAttrBindings.Remove(tab);
            _searcherDbContext.SaveChanges();
        }

        public TextAttrBinding GetTextAttrBinding(int id)
        {
            return _searcherDbContext.TextAttrBindings.Find(id);
        }

        public IEnumerable<TextAttrBinding> GetTextAttrBindings(Expression<Func<TextAttrBinding, bool>> predicate)
        {
            return  _searcherDbContext.TextAttrBindings
                .Include(x => x.TextAttribute)
                .Include(x => x.TextAttributeValue)
                .Include(x => x.TextRecord)
                .Where(predicate);
        }

        public TextAttrBinding UpdateTextAttrBinding(TextAttrBinding textAttrBinding)
        {
            _searcherDbContext.TextAttrBindings.Update(textAttrBinding);
            _searcherDbContext.SaveChanges();
            return textAttrBinding;
        }
    }
}
