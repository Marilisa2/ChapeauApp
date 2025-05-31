using System.Text.Json;

namespace mvc_whatsup.Models.Extentions
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
            return value==null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }


    }
}
