using System.Text.Json.Serialization;

namespace todoApi.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}