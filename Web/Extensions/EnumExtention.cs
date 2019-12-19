using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;

namespace WeAppEip.Web.Extensions
{
    public static class EnumExtention
    {
        private static readonly ConcurrentDictionary<Enum, string> _ConcurrentDictionary = new ConcurrentDictionary<Enum, string>();

        /// <summary>
        /// 获取枚举的描述信息(Descripion)
        /// </summary>
        public static string GetDescription(this Enum @this)
        {
            return _ConcurrentDictionary.GetOrAdd(@this, (key) =>
            {
                Type type = key.GetType();
                FieldInfo field = type.GetField(key.ToString());
                return field == null ? string.Empty : GetDescription(field);
            });
        }

        private static string GetDescription(MemberInfo field)
        {
            Attribute att = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
            return att == null ? string.Empty : ((DescriptionAttribute)att).Description;
        }
    }
}
