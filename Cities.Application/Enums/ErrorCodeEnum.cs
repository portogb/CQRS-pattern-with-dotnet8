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
        CityAlreadyExist = 10001,
        [Description("Error creating city")]
        ErrorCreatingCity = 10002,
        [Description("Empty city request")]
        EmptyCityRequest = 10003,
        [Description("Invalid city id")]
        InvalidCityId = 10004,
        [Description("City not deleted")]
        CityNotDeleted = 10005
    }
}
