using base_project.Interfaces;
using System;

namespace base_project.Exceptions
{
    /*
     * when more detailed error messages are needed, they will be added here
     * */

    public class BaseNotFoundException : Exception, IException
    {
        public BaseNotFoundException(string message) : base(message)
        {

        }

        public object GetMessage()
        {
            string _s = "not found error: ";
            return new { message = _s + this.Message };
        }
    }

    public class BaseInvalidInputException : Exception, IException
    {
        public BaseInvalidInputException(string message) : base(message)
        {

        }

        public object GetMessage()
        {
            string _s = "error in input: ";
            return new { message = _s + this.Message };
        }
    }

    public class BaseFormatException : Exception, IException
    {
        public BaseFormatException(string message) : base(message)
        {

        }

        public object GetMessage()
        {
            string _s = "format error: ";
            return new { message = _s + this.Message };
        }
    }
}
