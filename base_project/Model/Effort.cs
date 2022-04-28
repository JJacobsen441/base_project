using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Model
{
    [Table("effort")]
    public class Effort
    {
        [Key]
        public long Id { get; set; }
        public string note { get; set; } 
	    public double hours { get; set; }
        public int day { get; set; }

        
        [Required]
        public long employee_id { get; set; }
        public Employee employee { get; set; }

        
        [Required]
        public long project_id { get; set; }
        public Project project { get; set; }/**/                
    }
}
/**/