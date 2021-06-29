using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordsInTextsSearcher.Entities
{
    [Table("TextAttributeValues")]
    public class TextAttributeValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int TextAttributeId { get; set; }
        public TextAttribute TextAttribute { get; set; }
    }
}
