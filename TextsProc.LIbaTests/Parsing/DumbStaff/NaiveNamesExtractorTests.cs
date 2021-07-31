using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextsProc.LIba.Parsing.DumbStaff;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextsProc.LIba.Parsing.DumbStaff.Tests
{
    [TestClass()]
    public class NaiveNamesExtractorTests
    {
        [TestMethod()]
        public void GetNamesTest()
        {
            var naiveNamesExtractor = new NaiveNamesExtractor();

            var raw = "aaa bb  См.:КудрявцевВ.Н.,  bbb aaa";
            var res = naiveNamesExtractor.GetNames(raw);
            Assert.IsTrue(res.Contains("КудрявцевВ.Н."));

            raw = "фффф Бестужев-Лада И.В. ыуыуиыуи";
            res = naiveNamesExtractor.GetNames(raw);
            Assert.IsTrue(res.Contains("Бестужев-Лада И.В."));

            raw = "чччч   .В.А.Леванский  яамтам";
            res = naiveNamesExtractor.GetNames(raw);
            Assert.IsTrue(res.Contains("В.А.Леванский"));
        }
    }
}