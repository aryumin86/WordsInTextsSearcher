using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextsProc.LIba.Parsing.DumbStaff
{
    public class NaiveNamesExtractor
    {
        private readonly IEnumerable<Regex> _namesRegexes = new List<Regex>()
        {
            new Regex(@"([А-Я][а-яё]?(\s)*[.,](\s)*)?(([А-Я][а-яё]?(\s)*[.,])|фон)(\s)*[А-Я][а-яёА-Я]+(-[А-Я][а-яёА-Я]+)?"),
            //new Regex(@"[А-Я][а-яёА-Я]+(-[А-Я][а-яёА-Я]+)?(\s)*([А-Я][а-яё]?(\s)*[.,](\s)*)?(([А-Я][а-яё]?(\s)*[.,]))")
        };
        public IEnumerable<string> GetNames(string input)
        {
            return _namesRegexes.SelectMany(r => r.Matches(input).Select(x => x.ToString())).Distinct();
        }
    }
}
