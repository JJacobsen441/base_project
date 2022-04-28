using Base.Common;
using base_project.Exceptions;
using System.Linq;

namespace base_project.Common
{
    public class Validator
    {
        public static void CheckProjectName(string name)
        {
            /*
             * check for invalid characters will be done in apicontroller, during sanitation
             * */

            if (!name.HasValue())
                throw new BaseInvalidInputException("name not valid");

            if (name.Length > 30)
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

        public static void CheckEmployeeName(string name)
        {
            /*
             * check for invalid characters will be done in apicontroller, during sanitation
             * */

            if (!name.HasValue())
                throw new BaseInvalidInputException("name not valid");
            
            if (!name.Contains(" "))
                throw new BaseFormatException("name must contain ' ' space");

            string[] arr = name.Split(" ").Where(x=>x.HasValue()).ToArray();
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
