using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public interface ITextRecordsRepo
    {
        public IEnumerable<TextRecord> GetTextRecords(Expression<Func<TextRecord, bool>> predicate);
        public TextRecord GetTextRecord(int id);
        public TextRecord CreateTextRecord(TextRecord textRecord);
        public TextRecord UpdateTextRecord(TextRecord textRecord);
        public void DeleteTextRecord(int id);
    }
}
