using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Model
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public long Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        [Required]
        public IEnumerable<Effort> effort { get; set; }//NOT NULL
    }
}
/**/