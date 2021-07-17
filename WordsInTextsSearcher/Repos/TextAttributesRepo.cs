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
    public class TextAttributesRepo : ITextAttributesRepo
    {
        private SearcherDbContext _searcherDbContext;
        private ILogger<TextAttributesRepo> _logger;

        public TextAttributesRepo(SearcherDbContext searcherDbContext, 
            ILogger<TextAttributesRepo> logger)
        {
            _searcherDbContext = searcherDbContext;
            _logger = logger;
        }
        public TextAttribute CreateTextAttribute(TextAttribute textAttribute)
        {
            _searcherDbContext.TextAttributes.Add(textAttribute);
            _searcherDbContext.SaveChanges();
            _logger.LogInformation($"Text attr '{textAttribute.Name}' ({textAttribute.Id}) created");
            return textAttribute;
        }

        public void DeleteTextAttribute(int id)
        {
            var bindinds = _searcherDbContext.TextAttrBindings.Where(x => x.AttributeId == id);
            _searcherDbContext.TextAttrBindings.RemoveRange(bindinds);
            var taVals = _searcherDbContext.TextAttributeValues.Where(x => x.TextAttributeId == id);
            _searcherDbContext.TextAttributeValues.RemoveRange(taVals);
            var textAttribute = _searcherDbContext.TextAttributes.Find(id);
            _searcherDbContext.TextAttributes.Remove(textAttribute);

            _logger.LogInformation($"Text attr '{textAttribute.Name}' ({textAttribute.Id}) deleted");
            _searcherDbContext.SaveChanges();
        }

        public TextAttribute GetTextAttribute(int id)
        {
            return _searcherDbContext.TextAttributes.Find(id);
        }

        public IEnumerable<TextAttribute> GetTextAttributes(Expression<Func<TextAttribute, bool>> predicate)
        {
            return _searcherDbContext.TextAttributes.Include(x => x.Values).Where(predicate);
        }

        public TextAttribute UpdateTextAttribute(TextAttribute textAttribute)
        {
            _searcherDbContext.TextAttributes.Update(textAttribute);
            _searcherDbContext.SaveChanges();
            _logger.LogInformation($"Text attr '{textAttribute.Name}' ({textAttribute.Id}) updated");
            return textAttribute;
        }
    }
}
