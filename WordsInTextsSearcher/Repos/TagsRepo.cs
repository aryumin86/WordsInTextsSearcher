using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public class TagsRepo : ITagsRepo
    {
        private SearcherDbContext _dbContext;
        private AppConf _appConf;

        public TagsRepo(SearcherDbContext ctx, AppConf appConf)
        {
            _dbContext = ctx;
            _appConf = appConf;
        }

        public Tag CreateTag(Tag tag)
        {
            _dbContext.Tags.Add(tag);
            _dbContext.SaveChanges();
            return tag;
        }

        public void DeleteTag(int id)
        {
            using var ctx = new SearcherDbContext(_appConf.MainDbConnString);
            var tag = ctx.Tags.Find(id);
            ctx.Tags.Remove(tag);
            ctx.SaveChanges();
        }

        public Tag GetTag(int id)
        {
            return _dbContext.Tags.Find(id);
        }

        public IEnumerable<Tag> GetTags(Expression<Func<Tag, bool>> predicate)
        {
            return _dbContext.Tags.Where(predicate);
        }

        public Tag UpdateTag(Tag tag)
        {
            _dbContext.Tags.Update(tag);
            _dbContext.SaveChanges();
            return tag;
        }
    }
}
