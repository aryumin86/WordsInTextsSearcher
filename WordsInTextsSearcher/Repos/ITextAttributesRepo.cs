using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public interface ITextAttributesRepo
    {
        public IEnumerable<TextAttribute> GetTextAttributes(Expression<Func<TextAttribute, bool>> predicate);
        public TextAttribute GetTextAttribute(int id);
        public TextAttribute CreateTextAttribute(TextAttribute textAttribute);
        public TextAttribute UpdateTextAttribute(TextAttribute textAttribute);
        public void DeleteTextAttribute(int id);
    }
}
