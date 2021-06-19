using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class TextRecordsService
    {
        private ITextRecordsRepo _textRecordsRepo;

        public TextRecordsService(ITextRecordsRepo textRecordsRepo)
        {
            _textRecordsRepo = textRecordsRepo;
        }

        public async Task<IEnumerable<TextRecord>> GetTextRecords(int count = 100)
        {
            return await Task.FromResult(_textRecordsRepo.GetTextRecords(_ => true));
        }

        public async Task<TextRecord> CreateTextRecord(TextRecord textRecord)
        {
            return await Task.FromResult(_textRecordsRepo.CreateTextRecord(textRecord));
        }

        public async Task<TextRecord> UpdateTextRecord(TextRecord textRecord)
        {
            return await Task.FromResult(_textRecordsRepo.UpdateTextRecord(textRecord));
        }

        public async Task DeleteTextRecord(int id)
        {
            await Task.Run(() => _textRecordsRepo.DeleteTextRecord(id));
        }
    }
}
