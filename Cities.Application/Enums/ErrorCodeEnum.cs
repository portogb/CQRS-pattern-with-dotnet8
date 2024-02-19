using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Application.Enums
{
    public enum ErrorCodeEnum
    {
        [Description("City not exist")]
        CityDoesNotExist = 10000,
        [Description("City already exist")]
        CityAlreadyExist = 10001
    }
}
