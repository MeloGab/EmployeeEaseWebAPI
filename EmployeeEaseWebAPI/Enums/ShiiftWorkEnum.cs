using System.Text.Json.Serialization;

namespace EmployeesEaseWebAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShiiftWorkEnum
    {
        Morning = 0,
        Afternoon = 1,
        Night = 2
    }
}
