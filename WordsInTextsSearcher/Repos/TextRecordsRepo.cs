﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public class TextRecordsRepo : ITextRecordsRepo
    {
        private SearcherDbContext _dbContext;
        private AppConf _appConf;

        public TextRecordsRepo(SearcherDbContext dbContext, AppConf appConf)
        {
            _dbContext = dbContext;
            _appConf = appConf;
        }
        public TextRecord CreateTextRecord(TextRecord textRecord)
        {
            _dbContext.TextRecords.Add(textRecord);
            _dbContext.SaveChanges();
            return textRecord;
        }

        public void DeleteTextRecord(int id)
        {
            using var ctx = new SearcherDbContext(_appConf.MainDbConnString);
            var textRecord = ctx.TextRecords.Find(id);
            ctx.TextRecords.Remove(textRecord);
            ctx.SaveChanges();
        }

        public TextRecord GetTextRecord(int id)
        {
            return _dbContext.TextRecords.Find(id);
        }

        public IEnumerable<TextRecord> GetTextRecords(Expression<Func<TextRecord, bool>> predicate)
        {
            return _dbContext.TextRecords.Where(predicate);
        }

        public TextRecord UpdateTextRecord(TextRecord textRecord)
        {
            _dbContext.TextRecords.Update(textRecord);
            _dbContext.SaveChanges();
            return textRecord;
        }
    }
}
