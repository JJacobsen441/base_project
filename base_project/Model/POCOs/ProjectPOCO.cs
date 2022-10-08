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
    public class ProjectPOCO
    {
        public long Id { get; set; }
        public string name { get; set; }

        public IEnumerable<Effort> effort { get; set; }

        public List<ProjectDTO> GetProjects()
        {
            using (BaseDB _db = new BaseDB())
            {
                IQueryable<Project> _q = _db.project;
                    //.Include(x => x.effort)
                IEnumerable<Project> _p = _q.AsEnumerable().ToList();

                if (_p.IsNull())
                    throw new Exception();

                return this.ListToDTO(_p.ToList());
            }
        }

        public ProjectDTO GetProject(int id)
        {
            using (BaseDB _db = new BaseDB())
            {
                IQueryable<Project> _q = _db.project
                    //.Include(x => x.effort)
                    //    .ThenInclude(x => x.project)
                    .Include(x => x.effort)
                        .ThenInclude(x => x.employee)
                    .Where(x => x.Id == id);
            
                Project _p = _q.AsEnumerable().FirstOrDefault();

                if (_p.IsNull())
                    throw new BaseNotFoundException("project not found");
                else
                {
                    NullHelper.ProNull(_p.effort.ToList(), false, true);
                }
                return this.ToDTO(_p);
            }
        }

        public void CreateProject(string name)
        {
            if (name.IsNull())
                throw new Exception();

            using (BaseDB _db = new BaseDB())
            {
                Project _p = new Project();
                _p.name = name;

                _db.project.Add(_p);

                _db.SaveChanges();
            }
        }

        public void UpdateProject(int id, string n_name)
        {
            if (n_name.IsNull())
                throw new Exception();

            using (BaseDB _db = new BaseDB())
            {
                Project _p = _db.project.Where(x => x.Id == id).FirstOrDefault();

                if (_p.IsNull())
                    throw new Exception();

                _p.name = n_name;

                _db.SaveChanges();
            }
        }

        public List<ProjectDTO> ListToDTO(List<Project> _p)
        {
            if (_p.IsNull())
                throw new Exception();

            List<ProjectDTO> list = new List<ProjectDTO>();
            foreach (Project p in _p)
                list.Add(this.ToDTO(p));

            return list;
        }

        public ProjectDTO ToDTO(Project _p)
        {
            if (_p.IsNull())
                throw new Exception();

            ProjectDTO dto = new ProjectDTO();
            EffortPOCO poco = new EffortPOCO();

            dto.Id = _p.Id;
            dto.name = !_p.name.IsNull() ? _p.name : "";
            //dto.effort = !_p.effort.IsNull() ? NullHelper.Null(_p.effort.ToList()) : new List<Effort>();
            dto.effort = !_p.effort.IsNull() ? poco.ListToDTO(_p.effort.ToList()) : new List<EffortDTO>();

            return dto;
        }
    }
}
/**/