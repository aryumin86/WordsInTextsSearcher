using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class TextAttrBindingsService
    {
        private ITextAttrBindingsRepo _textAttrBindingsRepo;
        public TextAttrBindingsService(ITextAttrBindingsRepo textAttrBindingsRepo)
        {
            _textAttrBindingsRepo = textAttrBindingsRepo;
        }
    }
}
