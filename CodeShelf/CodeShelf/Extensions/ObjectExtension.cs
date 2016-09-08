using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAWinProV4.Infrastructure
{
    public static class ObjectExtension
    {
        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }

        public static bool IsNotNull<T>(this T obj) where T : class
        {
            return obj != null;
        }

        public static bool IsNull<T>(this T? obj) where T : struct
        {
            return !obj.HasValue;
        }

        public static bool IsNotNull<T>(this T? obj) where T : struct
        {
            return obj.HasValue;
        }

        public static bool IsAttr<T>(this PropertyInfo property) where T : Attribute
        {
            return property.CustomAttributes.Any(x => x.AttributeType == typeof(T));
        }



        public static bool IsAttr<T>(this object entry, bool ExploreTree = false) where T : Attribute
        {
            var type = entry.GetType();
            return type.IsAttr<T>(ExploreTree);
            //return type.CustomAttributes.Any(x => x.AttributeType == typeof(T));
        }


        public static bool IsAttr<T>(this Type type, bool ExploreTree = false) where T : Attribute
        {
            var result = type.CustomAttributes.Any(x => x.AttributeType == typeof(T));
            if (!result && ExploreTree)
            {
                var baseType = type.BaseType;
                if (baseType != null)
                    result = baseType.IsAttr<T>(ExploreTree);
            }
            return result;
            //return type.CustomAttributes.Any(x => x.AttributeType == typeof(T));
        }

        public static T Attr<T>(this Type type) where T : Attribute
        {
            if (type.IsAttr<T>())
            {
                return type.GetCustomAttribute<T>();
            }
            return null;
        }

        public static string ToJsonString(this object objectGraph)
        {
            if (objectGraph == null)
                return null;
            string json = JsonConvert.SerializeObject(
                  objectGraph,
                  Formatting.Indented,
                  new JsonSerializerSettings { });
            return json;
        }

        public static T JsonDeSerializer<T>(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString)) return default(T);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }


    }
}
