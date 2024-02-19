using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Validation
{
    public class ValidationException(string errorMessage) : Exception(errorMessage)
    {
        public static void When(bool hasError, string errorMessage, int errorCode)
        {
            if(hasError)
            {
                ValidationException exception = new($"Error code: [{errorCode}] {errorMessage}");
                exception.Data.Add("ERROR_CODE", errorCode);
                exception.Data.Add("ERROR_MESSAGE", errorMessage);
                throw exception;
            }
        }
    }
}
