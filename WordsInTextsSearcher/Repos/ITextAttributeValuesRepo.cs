using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public interface ITextAttributeValuesRepo
    {
        public IEnumerable<TextAttributeValue> GetTextAttributeValues(Expression<Func<TextAttributeValue, bool>> predicate);
        public TextAttributeValue GetTextAttributeValue(int id);
        public TextAttributeValue CreateTextAttributeValue(TextAttributeValue textAttributeValue);
        public TextAttributeValue UpdateTextAttributeValue(TextAttributeValue textAttributeValue);
        public void DeleteTextAttributeValue(int id);
    }
}
