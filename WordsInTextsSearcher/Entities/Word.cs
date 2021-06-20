using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordsInTextsSearcher.Entities
{
    public class Word
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime WhenCreated { get; set; }
        public string Text { get; set; }
        public ICollection<WordForm> WordForms { get; set; }

    }
}
