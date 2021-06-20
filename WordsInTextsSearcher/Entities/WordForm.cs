using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordsInTextsSearcher.Entities
{
    public class WordForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
        public DateTime WhenCreated { get; set; }
        public string Text { get; set; }
    }
}
