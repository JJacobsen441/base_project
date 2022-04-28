namespace Base.Model.DTOs
{
    public class EffortDTO
    {
        public long Id { get; set; }
        public string note { get; set; } 
	    public double hours { get; set; }
        public int day { get; set; }

        public string emp_name { get; set; }
        public EmployeeDTO employee { get; set; }

        public string pro_name { get; set; }
        public ProjectDTO project { get; set; }
    }
}
/**/