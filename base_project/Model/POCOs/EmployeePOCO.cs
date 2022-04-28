using Base.Common;
using Base.Model.DTOs;
using base_project.Common;
using base_project.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Base.Model
{
    public class EmployeePOCO
    {
        public long Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public IEnumerable<Effort> effort { get; set; }

        public List<EmployeeDTO> GetEmployees()
        {
            using (BaseDB _db = new BaseDB())
            {
                IQueryable<Employee> _q = _db.employee;
                    //.Include(x => x.effort)
                                
                IEnumerable<Employee> _e = _q.AsEnumerable().ToList();

                if (_e.IsNull())
                    throw new Exception();

                return this.ListToDTO(_e.ToList());
            }
        }

        public EmployeeDTO GetEmployee(int id)
        {
            using (BaseDB _db = new BaseDB())
            {
                IQueryable<Employee> _q = _db.employee
                    .Include(x => x.effort)
                        .ThenInclude(x => x.project)
                    //.Include(x => x.effort)
                    //    .ThenInclude(x => x.employee)
                    .Where(x => x.Id == id);

                string sql = _q.ToQueryString();

                Employee _e = _q.AsEnumerable().FirstOrDefault();

                if (_e.IsNull())
                    throw new BaseNotFoundException("employee not found");
                else
                {
                    /*
                     * my thought is that since ToDTO, sould just turn what it gets into DTO,
                     * then this is the place where we know about what data the result should have
                     * */

                    NullHelper.EmpNull(_e.effort.ToList(), true, false);
                }

                return this.ToDTO(_e);
            }
        }

        public List<EmployeeDTO> ListToDTO(List<Employee> _p)
        {
            if (_p.IsNull())
                throw new Exception();

            List<EmployeeDTO> list = new List<EmployeeDTO>();
            foreach (Employee p in _p)
                list.Add(this.ToDTO(p));

            return list;
        }

        public EmployeeDTO ToDTO(Employee _e)
        {
            if (_e.IsNull())
                throw new Exception();

            EmployeeDTO dto = new EmployeeDTO();
            EffortPOCO poco = new EffortPOCO();

            dto.Id = _e.Id;
            dto.first_name = !_e.first_name.IsNull() ? _e.first_name : "";
            dto.last_name = !_e.last_name.IsNull() ? _e.last_name : "";
            //dto.effort = !_e.effort.IsNull() ? NullHelper.Null(_e.effort.ToList()) : new List<Effort>();
            dto.effort = !_e.effort.IsNull() ? poco.ListToDTO(_e.effort.ToList()) : new List<EffortDTO>();

            return dto;
        }
    }
}
/**/