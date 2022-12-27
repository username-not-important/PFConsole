using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace PFModels
{
    public static class Extensions
    {
        public static string GetDescription<T>(this object enumerationValue)
            where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0 && attrs.FirstOrDefault(t => t.GetType() == typeof(DescriptionAttribute)) != null)
                {
                    //Pull out the description value
                    var attribute = (DescriptionAttribute) attrs.FirstOrDefault(t => t.GetType() == typeof(DescriptionAttribute));
                    if (attribute != null) return attribute.Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
    }
}