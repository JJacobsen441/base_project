using Base.Common;
using Base.Model.DTOs;
using base_project.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Base.Model
{
    public class EffortPOCO
    {
        public long Id { get; set; }
        public string note { get; set; } 
	    public double hours { get; set; }
        public int day { get; set; }

        
        public long employee_id { get; set; }
        public  Employee employee { get; set; }

        
        public long project_id { get; set; }
        public Project project { get; set; }/**/

        public void CreateEffort(string note, double hours, int day, string e_name, string p_name)
        {
            if (note.IsNull())
                throw new Exception();

            if (e_name.IsNull())
                throw new Exception();

            if (p_name.IsNull())
                throw new Exception();

            using (BaseDB _db = new BaseDB())
            {
                string f_name = e_name.ToUpper().Trim().Split(" ")[0];
                string l_name = e_name.ToUpper().Trim().Split(" ")[1];
                string pr_name = p_name.ToUpper().Trim();

                IQueryable<Employee> _q1 = _db.employee.Where(x => x.first_name.ToUpper().Contains(f_name) && x.last_name.ToUpper().Contains(l_name));
                Employee _em = _q1.AsEnumerable().FirstOrDefault();

                string sql = _q1.ToQueryString();

                if (_em.IsNull())
                    throw new Exception();

                IQueryable<Project> _q2 = _db.project.Where(x => x.name.ToUpper().Contains(pr_name));
                Project _pr = _q2.AsEnumerable().FirstOrDefault();

                if (_pr.IsNull())
                    throw new Exception();

                Effort _e = new Effort();
                _e.note = note;
                _e.hours = hours;
                _e.day = day;
                _e.employee_id = _em.Id;
                _e.project_id = _pr.Id;

                _db.effort.Add(_e);

                _db.SaveChanges();
            }
        }

        public List<EffortDTO> ListToDTO(List<Effort> _e)
        {
            if (_e.IsNull())
                throw new Exception();

            List<EffortDTO> list = new List<EffortDTO>();
            foreach (Effort e in _e)
                list.Add(this.ToDTO(e));

            return list;
        }

        public EffortDTO ToDTO(Effort _e)
        {
            if (_e.IsNull())
                throw new Exception();

            //if (_e.employee.IsNull())
            //    throw new Exception();

            //if (_e.project.IsNull())
            //    throw new Exception();

            EffortDTO dto = new EffortDTO();

            ProjectPOCO pro_poco = new ProjectPOCO();
            EmployeePOCO emp_poco = new EmployeePOCO();

            dto.Id = _e.Id;
            dto.day = _e.day;

            dto.note = !_e.note.IsNull() ? _e.note : "";
            dto.hours = _e.hours;

            dto.emp_name = !_e.employee.IsNull() ? _e.employee.first_name + " " + _e.employee.last_name: "";
            dto.pro_name = !_e.project.IsNull() ? _e.project.name : null;

            dto.employee = !_e.employee.IsNull() ? emp_poco.ToDTO(_e.employee) : null;
            dto.project = !_e.project.IsNull() ? pro_poco.ToDTO(_e.project) : null;

            return dto;
        }        
    }
}
/**/