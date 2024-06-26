﻿using System.Text.Json.Serialization;

namespace EmployeesEaseWebAPI.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartureEnum
    {
        HR = 0,
        Procurement = 1,
        Finance = 2,
        CustomerService = 3,
        Treasury = 4
    }
}
