using Base.Common;
using Base.Model.DTOs;
using base_project.Common;
using base_project.Exceptions;
using base_project.Model.DataAccesLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web;

namespace base_project.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        [HttpGet("employees")]
        public JsonResult Employees()
        {
            /*
             * endpoint name and function name, does not have to match
             * */

            try
            {
                DAL dal = new DAL();
                List<EmployeeDTO> dtos = dal.GetEmployees();

                JsonHelper json = new JsonHelper();
                Response.StatusCode = StatusCodes.Status200OK;
                return new JsonResult(json.SetupEmployeeList(dtos));
            }
            catch (Exception e)
            {
                object msg;
                Response.StatusCode = ErrorHandler.Handler(e, out msg);
                return new JsonResult(msg);
            }
        }

        [HttpGet("employee/{id}")]
        public JsonResult Employee(int id)
        {
            /*
             * endpoint name and function name, does not have to match
             * */

            try
            {
                DAL dal = new DAL();
                EmployeeDTO dto = dal.GetEmployee(id);

                JsonHelper json = new JsonHelper();
                Response.StatusCode = StatusCodes.Status200OK;
                return new JsonResult(json.SetupEmployee(dto));
            }
            catch (Exception e)
            {
                object msg;
                Response.StatusCode = ErrorHandler.Handler(e, out msg);
                return new JsonResult(msg);
            }
        }

        [HttpGet("projects")]
        public JsonResult Projects()
        {
            /*
             * endpoint name and function name, does not have to match
             * */

            try
            {
                DAL dal = new DAL();
                List<ProjectDTO> dtos = dal.GetProjects();

                JsonHelper json = new JsonHelper();
                Response.StatusCode = StatusCodes.Status200OK;
                return new JsonResult(json.SetupProjectList(dtos));
            }
            catch (Exception e)
            {
                object msg;
                Response.StatusCode = ErrorHandler.Handler(e, out msg);
                return new JsonResult(msg);
            }
        }

        [HttpGet("project/{id}")]
        public JsonResult Project(int id)
        {
            /*
             * endpoint name and function name, does not have to match
             * */

            try
            {
                DAL dal = new DAL();
                ProjectDTO dto = dal.GetProject(id);

                JsonHelper json = new JsonHelper();
                Response.StatusCode = StatusCodes.Status200OK;
                return new JsonResult(json.SetupProject(dto));
            }
            catch (Exception e)
            {
                object msg;
                Response.StatusCode = ErrorHandler.Handler(e, out msg);
                return new JsonResult(msg);
            }
        }

        [HttpPost("project")]
        public JsonResult Project(ProPost _p)
        {
            /*
             * should be url encoded
             * endpoint name and function name, does not have to match
             * remember to sanitize inputs. invalid characters, html tags...
             * */

            try
            {
                if (_p.IsNull())
                    throw new Exception();

                if (!_p.n_name.HasValue())
                    throw new Exception();

                string name = _p.n_name;

                name = HttpUtility.UrlDecode(name);

                DAL dal = new DAL();
                dal.CreateProject(name);

                Response.StatusCode = StatusCodes.Status200OK;
                return new JsonResult(new { result = "ok" });
            }
            catch (Exception e)
            {
                object msg;
                Response.StatusCode = ErrorHandler.Handler(e, out msg);
                return new JsonResult(msg);
            }
        }

        [HttpPut("project")]
        public JsonResult Project(ProPut _p)
        {
            /*
             * should be url encoded
             * endpoint name and function name, does not have to match
             * remember to sanitize inputs. invalid characters, html tags...
             * */

            try
            {
                if (_p.IsNull())
                    throw new Exception();

                if (!_p.n_name.HasValue())
                    throw new Exception();

                int id = _p.id;
                string n_name = _p.n_name;

                n_name = HttpUtility.UrlDecode(n_name);

                DAL dal = new DAL();
                dal.UpdateProject(id, n_name);

                Response.StatusCode = StatusCodes.Status200OK;
                return new JsonResult(new { result = "ok" });
            }
            catch (Exception e)
            {
                object msg;
                Response.StatusCode = ErrorHandler.Handler(e, out msg);
                return new JsonResult(msg);
            }
        }

        [HttpPost("effort")]
        public JsonResult Effort(EffPost _p)
        {
            /*
             * should be url encoded
             * endpoint name and function name, does not have to match
             * remember to sanitize inputs. invalid characters, html tags...
             * */

            try
            {
                if (_p.IsNull())
                    throw new Exception();

                if (_p.note.IsNull())
                    throw new Exception();

                if (!_p.e_name.HasValue())
                    throw new Exception();

                if (!_p.p_name.HasValue())
                    throw new Exception();

                string note = _p.note;
                double hours = _p.hours;
                int day = _p.day;
                string e_name = _p.e_name;
                string p_name = _p.p_name;

                note = HttpUtility.UrlDecode(note);
                e_name = HttpUtility.UrlDecode(e_name);
                p_name = HttpUtility.UrlDecode(p_name);

                DAL dal = new DAL();
                dal.CreateEffort(note, hours, day, e_name, p_name);

                Response.StatusCode = StatusCodes.Status200OK;
                return new JsonResult(new { result = "ok" });
            }
            catch (Exception e)
            {
                object msg;
                Response.StatusCode = ErrorHandler.Handler(e, out msg);
                return new JsonResult(msg);
            }
        }
    }
}
