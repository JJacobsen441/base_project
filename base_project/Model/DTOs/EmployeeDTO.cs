using System.Collections.Generic;

namespace Base.Model.DTOs
{
    public class EmployeeDTO
    {
        public long Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public IEnumerable<EffortDTO> effort { get; set; }
    }
}
/**/