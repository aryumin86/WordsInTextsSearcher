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

        public TextAttributeValuesRepo(SearcherDbContext searcherDbContext)
        {
            _searcherDbContext = searcherDbContext;
        }

        public TextAttributeValue CreateTextAttributeValue(TextAttributeValue textAttributeValue)
        {
            _searcherDbContext.TextAttributeValues.Add(textAttributeValue);
            _searcherDbContext.SaveChanges();
            return textAttributeValue;
        }

        public void DeleteTextAttributeValue(int id)
        {
            var tav = _searcherDbContext.TextAttributeValues.Find(id);
            _searcherDbContext.SaveChanges();
            _searcherDbContext.TextAttributeValues.Remove(tav);
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
            return textAttributeValue;
        }
    }
}
