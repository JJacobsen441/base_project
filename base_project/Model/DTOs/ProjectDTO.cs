using System.Collections.Generic;

namespace Base.Model.DTOs
{
    public class ProjectDTO
    {
        public long Id { get; set; }
        public string name { get; set; }

        public IEnumerable<EffortDTO> effort { get; set; }
    }
}
/**/