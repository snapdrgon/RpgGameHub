using System;
using System.ComponentModel;

namespace RpgGameHub.Extensions
{
    public static class EnumExtension
    {
        //example taken from http://www.pavey.me/2015/04/aspnet-c-extension-method-to-get-enum.html
        public static string EnumDesc(this Enum value)
        {
            // variables  
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // return  
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }

}