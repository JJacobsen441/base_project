using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace base_project.Common
{
    public class ProPost
    {
        public string name { get; set; }
    }

    public class ProPut
    {
        public int id { get; set; }
        public string n_name { get; set; }
    }

    public class EffPost
    {
        public string note { get; set; }
        public double hours { get; set; }
        public int day { get; set; }
        public string e_name { get; set; }
        public string p_name { get; set; }
    }
}
