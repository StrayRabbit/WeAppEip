using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeAppEip.Web.Extensions
{
    /// <summary>
    /// json序列化帮助类
    /// </summary>
    public class JsonSerHelper
    {
        public static T ToObject<T>(string jsonstring) where T : class
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstring);
        }

        public static string ToJson<T>(T source) where T : class
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(source);
        }

        /// <summary>
        /// 序列化驼峰命名格式，即首字母小写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToCamelJson<T>(T source) where T : class
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(source);
        }
    }
}
