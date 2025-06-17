using System.Text.Json;

namespace ChapeauApp.Models.Extensions
{
    public static class SessionExtentions
    {
        public static void SetObject<T>(this ISession session,string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? GetObject<T>(this ISession session, string key) 
        {
            string? value = session.GetString(key); 
            return value==null ? default : JsonSerializer.Deserialize<T>(value);
        }


    }
}
