using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsInTextsSearcher.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public DateTime WhenCreated { get; set; }
        public string Text { get; set; }
        public IEnumerable<WordForm> WordForms { get; set; }

    }
}
