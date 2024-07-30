using UnityEngine;

namespace YGameTemplate
{
    public static class DataExtension
    {
        public static Vector3Data AsVectorData(this Vector3 vector)
        {
            return new Vector3Data(vector.x, vector.y, vector.z);
        }

        public static Vector3 AsUnityVector(this Vector3Data vector3Data) =>
            new Vector3(vector3Data.x, vector3Data.y, vector3Data.z);


        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) => JsonUtility.ToJson(obj);
    }
}