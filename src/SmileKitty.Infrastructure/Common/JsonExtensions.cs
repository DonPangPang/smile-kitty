using Newtonsoft.Json;

namespace SmileKitty.Infrastructure.Common;

public static class JsonExtensions
{
    public static string ToJson(this object? obj)
    {
        try
        {
            return obj is null ? string.Empty : JsonConvert.SerializeObject(obj);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public static T? ToObject<T>(this string? json)
    {
        try
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception)
        {
            return default;
        }
    }
}