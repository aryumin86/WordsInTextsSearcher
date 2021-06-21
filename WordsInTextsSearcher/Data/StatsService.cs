using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class StatsService
    {
        private IWordsRepo _wordsRepo;
        private ITextRecordsRepo _textRecordsRepo;

        public StatsService(IWordsRepo wordsRepo, ITextRecordsRepo textRecordsRepo)
        {
            _wordsRepo = wordsRepo;
            _textRecordsRepo = textRecordsRepo;
        }

        public IEnumerable<TextTermsStat> GetTextTermsStats(IEnumerable<TextRecord> texts, 
            IEnumerable<Word> words)
        {
            var res = new List<TextTermsStat>();

            foreach(var text in texts)
            {
                var termTextStat = new TextTermsStat { 
                    TextRecord = text,
                    WordsCount = new Dictionary<int, int>()
                };

                foreach(var word in words)
                {
                    var wordPositions = new List<int>();
                    foreach(var wordForm in word.WordForms)
                    {
                        var wordFormPositions = GetSubstringOccuerencesInString(text.Text, wordForm.Text);
                        wordPositions.AddRange(wordFormPositions);
                    }
                    wordPositions = wordPositions.Distinct().ToList();
                    termTextStat.WordsCount.Add(word.Id, wordPositions.Count);
                }
                res.Add(termTextStat);
            }

            return res;
        }


        private IEnumerable<int> GetSubstringOccuerencesInString(string full, string substr)
        {
            var wordPositions = new List<int>();
            int position = 0;

            full = full.ToLowerInvariant();
            substr = substr.ToLowerInvariant();

            while(position >= 0 && substr.Length + position < full.Length)
            {
                // Исправить вот тут позицию С НАЧАЛА ПОЛНОГО ТЕКСТА НАДО
                position = full.IndexOf(substr, position); 
                if(position >= 0)
                {
                    wordPositions.Add(position);
                    position += substr.Length;
                }
            }

            return wordPositions;
        }
    }
}
