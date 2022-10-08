using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace COMMON.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EmployeeType
    {
        FullTime = 0,
        PartTime = 1
    }
}