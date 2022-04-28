using Base.Common;
using Base.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using static base_project.Common.Enums;

namespace base_project.Common
{
    public class JsonHelper
    {
        public List<object> ListTidy(List<ProjectDTO> _p, List<EmployeeDTO> _e, TYPE type) 
        {
            if (_p.IsNull() && _e.IsNull())
                throw new Exception();
            if (!_p.IsNull() && !_e.IsNull())
                throw new Exception();

            bool is_pro = !_p.IsNull();

            List<object> list = new List<object>();
            switch(is_pro)
            {
                case true:
                    foreach (ProjectDTO p in _p)
                        list.Add(this.Tidy(p, null, type));
                    break;
                case false:
                    foreach (EmployeeDTO e in _e)
                        list.Add(this.Tidy(null, e, type));
                    break;
            }

            return list;
        }

        public object Tidy(ProjectDTO _p, EmployeeDTO _e, TYPE type)
        {
            if (_p.IsNull() && _e.IsNull())
                throw new Exception();
            if (!_p.IsNull() && !_e.IsNull())
                throw new Exception();

            bool is_pro = !_p.IsNull();

            switch (type)
            {
                case TYPE.LIST:
                    return is_pro ?
                        new
                        {
                            id = _p.Id,
                            name = !_p.name.IsNull() ? _p.name : "",
                        } :
                        new
                        {
                            id = _e.Id,
                            first_name = !_e.first_name.IsNull() ? _e.first_name : "",
                            last_name = !_e.last_name.IsNull() ? _e.last_name : ""
                        };
                case TYPE.SINGLE:
                    return is_pro ?
                        new
                        {
                            name = !_p.name.IsNull() ? _p.name : "",
                            effort = !_p.effort.IsNull() ? ListTidy(_p.effort.ToList(), EF_TYPE.PRO) : new List<object>()
                        } :
                        new
                        {
                            first_name = !_e.first_name.IsNull() ? _e.first_name : "",
                            last_name = !_e.last_name.IsNull() ? _e.last_name : "",
                            //dto.effort = !_e.effort.IsNull() ? NullHelper.Null(_e.effort.ToList()) : new List<Effort>();
                            effort = !_e.effort.IsNull() ? ListTidy(_e.effort.ToList(), EF_TYPE.EMP) : new List<object>()
                        };
                default:
                    throw new Exception();
            }
        }

        public List<object> ListTidy(List<EffortDTO> _e, EF_TYPE type)
        {
            if (_e.IsNull())
                throw new Exception();

            List<object> list = new List<object>();
            foreach (EffortDTO e in _e)
                list.Add(this.Tidy(e, type));

            return list;
        }

        public object Tidy(EffortDTO _e, EF_TYPE type)
        {
            if (_e.IsNull())
                throw new Exception();

            DateTime date = Statics.UnixTimeStampToDateTime(_e.day);

            switch (type)
            {
                case EF_TYPE.PRO:
                    return new
                    {
                        id = _e.Id,
                        date = date.Day + "/" + date.Month + "/" + date.Year,

                        note = !_e.note.IsNull() ? _e.note : "",
                        hours = _e.hours,

                        emp_name = _e.emp_name
                    };
                case EF_TYPE.EMP:
                    return new
                    {
                        id = _e.Id,
                        date = date.Day + "/" + date.Month + "/" + date.Year,

                        note = !_e.note.IsNull() ? _e.note : "",
                        hours = _e.hours,

                        pro_name = _e.pro_name
                    };
                default:
                    throw new Exception();
            }
        }
    }
}
