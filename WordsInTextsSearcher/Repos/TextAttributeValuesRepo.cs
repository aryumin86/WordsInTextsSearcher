using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public class TextAttributeValuesRepo : ITextAttributeValuesRepo
    {
        private SearcherDbContext _searcherDbContext;
        private ILogger<TextAttributeValuesRepo> _logger;

        public TextAttributeValuesRepo(SearcherDbContext searcherDbContext, 
            ILogger<TextAttributeValuesRepo> logger)
        {
            _searcherDbContext = searcherDbContext;
            _logger = logger;
        }

        public TextAttributeValue CreateTextAttributeValue(TextAttributeValue textAttributeValue)
        {
            _searcherDbContext.TextAttributeValues.Add(textAttributeValue);
            _searcherDbContext.SaveChanges();
            _logger.LogInformation($"Text attr value '{textAttributeValue.Value}' ({textAttributeValue.Id}) for text attr {textAttributeValue.TextAttributeId} created");
            return textAttributeValue;
        }

        public void DeleteTextAttributeValue(int id)
        {
            var textAttributeValue = _searcherDbContext.TextAttributeValues.Find(id);            
            _searcherDbContext.TextAttributeValues.Remove(textAttributeValue);
            _searcherDbContext.SaveChanges();
            _logger.LogInformation($"Text attr value '{textAttributeValue.Value}' ({textAttributeValue.Id}) for text attr {textAttributeValue.TextAttributeId} removed");
        }

        public TextAttributeValue GetTextAttributeValue(int id)
        {
            return _searcherDbContext.TextAttributeValues.Find(id);
        }

        public IEnumerable<TextAttributeValue> GetTextAttributeValues(Expression<Func<TextAttributeValue, bool>> predicate)
        {
            return _searcherDbContext.TextAttributeValues.Where(predicate);
        }

        public TextAttributeValue UpdateTextAttributeValue(TextAttributeValue textAttributeValue)
        {
            _searcherDbContext.TextAttributeValues.Update(textAttributeValue);
            _searcherDbContext.SaveChanges();
            _logger.LogInformation($"Text attr value '{textAttributeValue.Value}' ({textAttributeValue.Id}) for text attr {textAttributeValue.TextAttributeId} updated");
            return textAttributeValue;
        }
    }
}
