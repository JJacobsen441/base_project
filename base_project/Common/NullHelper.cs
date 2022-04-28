using Base.Common;
using Base.Model;
using System;
using System.Collections.Generic;

namespace base_project.Common
{
    public class NullHelper
    {
        public static List<Effort> EmpNull(List<Effort> _e, bool withproject, bool withemployee)
        {
            if (_e.IsNull())
                throw new Exception();

            foreach (Effort e in _e)
                EmpNull(e, withproject, withemployee);

            return _e;
        }

        public static Effort EmpNull(Effort _e, bool withproject, bool withemployee)
        {
            if (_e.IsNull())
                throw new Exception();

            _e.employee = !withemployee && _e.employee != null ? null : _e.employee;
            _e.project = !withproject && _e.project != null ? null : EmpNull(_e.project);

            return _e;
        }

        public static Project EmpNull(Project _p)
        {
            if (_p.IsNull())
                throw new Exception();

            if (_p.effort != null)
                _p.effort = null;

            return _p;
        }







        public static List<Effort> ProNull(List<Effort> _e, bool withproject, bool withemployee)
        {
            if (_e.IsNull())
                throw new Exception();

            foreach (Effort e in _e)
                ProNull(e, withproject, withemployee);

            return _e;
        }

        public static Effort ProNull(Effort _e, bool withproject, bool withemployee)
        {
            if (_e.IsNull())
                throw new Exception();

            _e.employee = !withemployee && _e.employee != null ? null : ProNull(_e.employee);
            _e.project = !withproject && _e.project != null ? null : _e.project;

            return _e;
        }

        public static Employee ProNull(Employee _e)
        {
            if (_e.IsNull())
                throw new Exception();

            if (_e.effort != null)
                _e.effort = null;

            return _e;
        }
    }
}
