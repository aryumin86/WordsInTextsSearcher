using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class TagsService
    {
        private ITagsRepo _tagsRepo;

        public TagsService(ITagsRepo tagsRepo)
        {
            _tagsRepo = tagsRepo;
        }

        public async Task<IEnumerable<Tag>> GetTags(Expression<Func<Tag, bool>> predicate)
        {
            return await Task.FromResult(_tagsRepo.GetTags(predicate));
        }

        public async Task<Tag> GetTag(int id)
        {
            return await Task.FromResult(_tagsRepo.GetTag(id));
        }

        public async Task<Tag> CreateTag(Tag tag)
        {
            return await Task.FromResult(_tagsRepo.CreateTag(tag));
        }

        public async Task<Tag> UpdateTag(Tag tag)
        {
            return await Task.FromResult(_tagsRepo.UpdateTag(tag));
        }

        public async Task DeleteTag(int id)
        {
            await Task.CompletedTask;
            _tagsRepo.DeleteTag(id);
        }
    }
}
