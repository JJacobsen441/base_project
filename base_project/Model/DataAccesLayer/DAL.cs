using Base.Model;
using Base.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace base_project.Model.DataAccesLayer
{
    public class DAL
    {
        public List<EmployeeDTO> GetEmployees()
        {
            EmployeePOCO poco = new EmployeePOCO();

            return poco.GetEmployees();
        }

        public EmployeeDTO GetEmployee(int id)
        {
            EmployeePOCO poco = new EmployeePOCO();

            return poco.GetEmployee(id);
        }

        public List<ProjectDTO> GetProjects()
        {
            ProjectPOCO poco = new ProjectPOCO();

            return poco.GetProjects();
        }

        public ProjectDTO GetProject(int id)
        {
            ProjectPOCO poco = new ProjectPOCO();

            return poco.GetProject(id);
        }

        public void CreateProject(string name)
        {
            ProjectPOCO poco = new ProjectPOCO();

            poco.CreateProject(name);
        }

        public void UpdateProject(int id, string n_name)
        {
            ProjectPOCO poco = new ProjectPOCO();

            poco.UpdateProject(id, n_name);
        }

        public void CreateEffort(string note, double hours, int day, string e_name, string p_name)
        {
            EffortPOCO poco = new EffortPOCO();

            poco.CreateEffort(note, hours, day, e_name, p_name);
        }
    }
}
