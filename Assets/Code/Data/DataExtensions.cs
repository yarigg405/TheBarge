using UnityEngine;


namespace Assets.Code.Data
{
    public static class DataExtensions
    {
        public static string ToJson(this object data)
        {
            return JsonUtility.ToJson(data);
        }

        public static T ToDeserealized<T>(this string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}
