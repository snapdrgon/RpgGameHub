using System;
using System.ComponentModel.DataAnnotations;

namespace RpgGameHub.Extensions
{
    public static class EnumExtension
    {
        //example taken from http://www.pavey.me/2015/04/aspnet-c-extension-method-to-get-enum.html
        //reworked logic - wasn't returning the Display name, just returning the EnumType String
        public static string EnumDesc(this Enum value)
        {
            // variables  
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DisplayAttribute), false);

            // return  
            return attributes.Length == 0 ? value.ToString() : ((DisplayAttribute)attributes[0]).GetName();
        }
    }

}