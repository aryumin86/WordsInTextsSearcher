using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordsInTextsSearcher.Entities
{
    public class TextRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime WhenCreated { get; set; }
        public string Text { get; set; }
        public Tag Tag { get; set; }
        public int? TagId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
