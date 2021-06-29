using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordsInTextsSearcher.Entities
{
    [Table("TextAttributes")]
    public class TextAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TextAttributeValue> Values { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
