using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Model
{
    [Table("project")]
    public class Project
    {
        [Key]
        public long Id { get; set; }
        public string name { get; set; }

        [Required]
        public IEnumerable<Effort> effort { get; set; }//NOT NULL
    }
}
/**/