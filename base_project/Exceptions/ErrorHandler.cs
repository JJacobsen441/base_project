using Microsoft.AspNetCore.Http;
using System;

namespace base_project.Exceptions
{
    /*
     * basically just for identifying the exception, and returning a proper statuscode
     * */

    public class ErrorHandler
    {
        public static int Handler(Exception e, out object msg)
        {
            try
            {
                throw e;
            }
            catch (BaseNotFoundException _e)
            {
                msg = _e.GetMessage();
                return StatusCodes.Status404NotFound;
            }
            catch (BaseInvalidInputException _e)
            {
                msg = _e.GetMessage();
                return StatusCodes.Status404NotFound;
            }
            catch (BaseFormatException _e)
            {
                msg = _e.GetMessage();
                return StatusCodes.Status404NotFound;
            }
            catch (Exception _e)
            {
                msg = new { error = "general error" };
                return StatusCodes.Status404NotFound;
            }            
        }
    }
}
