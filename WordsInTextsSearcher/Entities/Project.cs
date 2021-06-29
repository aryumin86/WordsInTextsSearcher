using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordsInTextsSearcher.Entities
{
    [Table("Projects")]
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime WhenCreated { get; set; }
    }
}
