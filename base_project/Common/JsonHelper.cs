using Base.Common;
using Base.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace base_project.Common
{
    public class JsonHelper
    {
        public class ResultProjectList1
        {
            public List<ResultProject1> list { get; set; }
        }

        public class ResultEmployeeList1
        {
            public List<ResultEmployee1> list { get; set; }
        }

        public class ResultProject1
        {
            public long id { get; set; }
            public string name { get; set; }
            public List<ResultEffort1> effort { get; set; }
        }

        public class ResultEmployee1
        {
            public long id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public List<ResultEffort1> effort { get; set; }
        }

        public class ResultEffort1 
        {
            public long id { get; set; }
            public string date { get; set; }
            public string note { get; set; }
            public double hours { get; set; }
            public string emp_name { get; set; }
            public string pro_name { get; set; }
        }

        public ResultProjectList1 SetupProjectList(List<ProjectDTO> _p)
        {
            if (_p.IsNull())
                throw new Exception();

            ResultProjectList1 res = new ResultProjectList1();
            res.list = new List<ResultProject1>();

            foreach (ProjectDTO p in _p)
            {
                ResultProject1 _r = SetupProject(p, false);
                res.list.Add(_r);
            }

            return res;
        }

        public ResultEmployeeList1 SetupEmployeeList(List<EmployeeDTO> _e)
        {
            if (_e.IsNull())
                throw new Exception();

            ResultEmployeeList1 res = new ResultEmployeeList1();
            res.list = new List<ResultEmployee1>();

            foreach (EmployeeDTO e in _e)
            {
                ResultEmployee1 _r = SetupEmployee(e, false);
                res.list.Add(_r);
            }

            return res;
        }

        public ResultProject1 SetupProject(ProjectDTO _p, bool with_effort)
        {
            if (_p.IsNull())
                throw new Exception();

            ResultProject1 res = new ResultProject1()
            {
                id = _p.Id,
                name = !_p.name.IsNull() ? _p.name : "",
                effort = with_effort ? SetupEffortList(_p.effort.ToList(), true) : null
            };

            return res;
        }

        public ResultEmployee1 SetupEmployee(EmployeeDTO _e, bool with_effort)
        {
            if (_e.IsNull())
                throw new Exception();

            ResultEmployee1 res = new ResultEmployee1()
            {
                id = _e.Id,
                first_name = !_e.first_name.IsNull() ? _e.first_name : "",
                last_name = !_e.last_name.IsNull() ? _e.last_name : "",
                effort = with_effort ? SetupEffortList(_e.effort.ToList(), false) : null
            };

            return res;
        }

        public List<ResultEffort1> SetupEffortList(List<EffortDTO> _e, bool is_pro)
        {
            if (_e.IsNull())
                throw new Exception();

            List<ResultEffort1> list = new List<ResultEffort1>();
            foreach (EffortDTO e in _e)
            {
                DateTime date = Statics.UnixTimeStampToDateTime(e.day);
                ResultEffort1 res = new ResultEffort1()
                {
                    id = e.Id,
                    date = date.Day + "/" + date.Month + "/" + date.Year,

                    note = !e.note.IsNull() ? e.note : "",
                    hours = e.hours,

                    emp_name = is_pro ? "" : e.emp_name,
                    pro_name = is_pro ? e.pro_name : ""
                };
                list.Add(res);
            }

            return list;
        }        
    }
}
