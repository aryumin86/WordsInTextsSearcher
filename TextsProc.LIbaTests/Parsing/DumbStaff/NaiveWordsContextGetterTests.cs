using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextsProc.LIba.Parsing.DumbStaff;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextsProc.LIba.Parsing.DumbStaff.Tests
{
    [TestClass()]
    public class NaiveWordsContextGetterTests
    {
        [TestMethod()]
        public void GetWordsTest()
        {
            var contextGetter = new NaiveWordsContextGetter();
            Func<string, bool> filter = (string word) => word.Length > 4;

            string input = "xxx xxx aaa bbbb доктрина ccc aaa bb fff";
            var words = contextGetter.GetWords(input, "доктрина", 2, filter);
            Assert.IsTrue(words.Contains("bbbb") && words.Contains("aaa") &&
                words.Contains("ccc") 
                && !words.Contains("xxx") && !words.Contains("bb") && !words.Contains("fff"));
        }
    }
}