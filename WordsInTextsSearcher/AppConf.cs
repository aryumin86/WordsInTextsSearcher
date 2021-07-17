using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher
{
    public class AppConf
    {
        public string MainDbConnString { get; set; }
        public IEnumerable<User> Users { get; set; }
        public string LogsFile { get; set; }
    }
}
