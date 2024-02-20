using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Enums
{
    public enum StatusCodeEnum
    {
        Validation = 422,
        Success = 200,
        BadRequest = 400,
        InternalServerError = 500
    }
}
