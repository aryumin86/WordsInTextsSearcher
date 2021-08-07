using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextsProc.LIba.Parsing.DumbStaff
{
    /// <summary>
    /// Gets n words before and after the main one.
    /// </summary>
    public class NaiveWordsContextGetter
    {
        private readonly IEnumerable<char> _delimeters = new List<char>
        {
            ' ', ',', '.', '/', '?','!','@','\"', '#', '$','%','^', '&', '*', '(', ')', '-','_',
            '=', '+', ';','[', ']', '\\', '|'
        };

        /// <summary>
        /// Extracts context words within n words around
        /// </summary>
        /// <param name="mainWord"></param>
        /// <param name="input"></param>
        /// <param name="n">n words to the left and to the right of the main one</param>
        /// <param name="predicate">predicate to filter results</param>
        /// <returns></returns>
        public IEnumerable<string> GetWords(string input, string mainWord, int n, Func<string, bool> predicate)
        {
            var res = new List<string>();
            var allWords = input.Split(_delimeters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            string currentWord = string.Empty;
            for(int i = 0; i < allWords.Length; i++)
            {
                currentWord = allWords[i];
                if (!string.Equals(currentWord, mainWord, StringComparison.InvariantCultureIgnoreCase))
                    continue;

                int paces = n + 1;
                for(var j = i; j < allWords.Length && paces > 0; j++, paces--)
                {
                    res.Add(allWords[j]);
                }

                paces = n + 1;
                for (var j = i; j >= 0 && paces > 0; j--, paces--)
                {
                    res.Add(allWords[j]);
                }
            }

            return res
                .Where(w=> !string.Equals(w, mainWord, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => x.ToLowerInvariant()).Distinct()
                .Where(w => predicate(w));
        }
    }
}
