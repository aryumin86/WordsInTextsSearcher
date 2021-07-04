using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordsInTextsSearcher.Entities
{
    [Table("TextAttrBindings")]
    public class TextAttrBinding
    {
        public int Id { get; set; }

        public int AttributeId { get; set; }
        [ForeignKey("AttributeId")]
        public TextAttribute TextAttribute { get; set; }

        public int AttributeValueId { get; set; }
        [ForeignKey("AttributeValueId")]
        public TextAttributeValue TextAttributeValue { get; set; }

        public int TextRecordId { get; set; }
        [ForeignKey("TextRecordId")]
        public TextRecord TextRecord { get; set; }
    }
}
