using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public interface ITextAttrBindingsRepo
    {
        public IEnumerable<TextAttrBinding> GetTextAttrBindings(Expression<Func<TextAttrBinding, bool>> predicate);
        public TextAttrBinding GetTextAttrBinding(int id);
        public void DeleteTextAttrBinding(int id);
        public TextAttrBinding CreateTextAttrBinding(TextAttrBinding textAttrBinding);
        public TextAttrBinding UpdateTextAttrBinding(TextAttrBinding textAttrBinding);

    }
}
