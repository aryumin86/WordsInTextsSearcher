using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordsInTextsSearcher.Entities
{
    public class TextTermsStat
    {
        public TextRecord TextRecord { get; set; }

        /// <summary>
        /// Words frequences occuerence in text. 
        /// Key is word id, key is its freq in text.
        /// </summary>
        public Dictionary<int, int> WordsCount { get; set; }
    }
}
