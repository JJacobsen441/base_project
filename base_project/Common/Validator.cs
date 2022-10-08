using Base.Common;
using base_project.Exceptions;
using System;
using System.Linq;
using System.Web;

namespace base_project.Common
{
    public class Validator
    {
        public static void CheckProject(ProPost _p)
        {
            /*
             * check for invalid characters will be done in apicontroller, during sanitation
             * */
            _p.n_name = HttpUtility.UrlDecode(_p.n_name);

            if (!_p.n_name.HasValue())
                throw new BaseInvalidInputException("name not valid");

            if (_p.n_name.Length > 30)
                throw new BaseInvalidInputException("name not valid");
        }

        public static void CheckProject(ProPut _p)
        {
            /*
             * check for invalid characters will be done in apicontroller, during sanitation
             * */
            _p.n_name = HttpUtility.UrlDecode(_p.n_name);

            if (!_p.n_name.HasValue())
                throw new BaseInvalidInputException("name not valid");

            if (_p.n_name.Length > 30)
                throw new BaseInvalidInputException("name not valid");
        }

        /*public static void CheckName(string name)
        {
            if (!name.HasValue())
                throw new BaseInvalidInputException("name not valid");

            if (name.Any(char.IsDigit))
                throw new BaseInvalidInputException("name not valid");

            if (name.Length > 20)
                throw new BaseInvalidInputException("name not valid");
        }*/

        public static void CheckEffort(EffPost _e)
        {
            /*
             * check for invalid characters will be done in apicontroller, during sanitation
             * */

            if (_e.note.IsNull())
                throw new Exception();

            if (!_e.e_name.HasValue())
                throw new Exception();

            if (!_e.p_name.HasValue())
                throw new Exception();

            _e.note = HttpUtility.UrlDecode(_e.note);
            _e.e_name = HttpUtility.UrlDecode(_e.e_name);
            _e.p_name = HttpUtility.UrlDecode(_e.p_name);





            if (!_e.p_name.HasValue())
                throw new BaseInvalidInputException("name not valid");

            if (_e.p_name.Length > 30)
                throw new BaseInvalidInputException("name not valid");





            if (!_e.e_name.HasValue())
                throw new BaseInvalidInputException("name not valid");
            
            if (!_e.e_name.Contains(" "))
                throw new BaseFormatException("name must contain ' ' space");

            string[] arr = _e.e_name.Split(" ").Where(x=>x.HasValue()).ToArray();
            if (arr.Length != 2)
                throw new BaseFormatException("emp_name is in the wrong format");

            if (!arr[0].HasValue())
                throw new BaseInvalidInputException("name not valid");

            if (!arr[1].HasValue())
                throw new BaseInvalidInputException("name not valid");

            if (arr[0].Length > 20)
                throw new BaseInvalidInputException("name not valid");

            if (arr[1].Length > 20)
                throw new BaseInvalidInputException("name not valid");
        }
    }
}
