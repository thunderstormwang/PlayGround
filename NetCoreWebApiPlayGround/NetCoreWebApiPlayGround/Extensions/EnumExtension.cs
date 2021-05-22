using System.ComponentModel;
using System.Reflection;

namespace NetCoreWebApiPlayGround.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// GetEnumDescription
        /// </summary>
        /// <typeparam name="TEnum">Enum</typeparam>
        /// <param name="type">type</param>
        /// <returns>string</returns>
        public static string GetEnumDescription<TEnum>(this TEnum type)
        {
            var fieldInfo = type.GetType().GetField(type.ToString());

            if (fieldInfo?.GetCustomAttribute(typeof(DescriptionAttribute),
                false) is DescriptionAttribute attributes)
            {
                return attributes.Description;
            }

            return type.ToString();
        }
    }
}