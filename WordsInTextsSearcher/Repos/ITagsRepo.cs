using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public interface ITagsRepo
    {
        public IEnumerable<Tag> GetTags(Expression<Func<Tag, bool>> predicate);
        public Tag GetTag(int id);
        public Tag CreateTag(Tag tag);
        public Tag UpdateTag(Tag tag);
        public void DeleteTag(int id);
    }
}
