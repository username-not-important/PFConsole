using System;
using System.Collections.Generic;
using System.Reflection;
using PFConsole.Util.Diagram;

namespace PFConsole.Util
{
    internal static class AttributeHelper
    {
        private static Dictionary<Type, ConfigurableAttribute[]> ConfigurableAttributeCache;

        static AttributeHelper()
        {
            ConfigurableAttributeCache = new Dictionary<Type, ConfigurableAttribute[]>();
        }

        private static PropertyInfo[] GetProperties(object obj)
        {
            Type type = obj.GetType();

            var props = type.GetProperties();

            return props;
        }

        public static ConfigurableAttribute[] GetAttributes(object o)
        {
            var type = o.GetType();

            ConfigurableAttribute[] attribsCache;
            if (ConfigurableAttributeCache.TryGetValue(type, out attribsCache))
                return attribsCache;

            var props = GetProperties(o);

            List<ConfigurableAttribute> cols = new List<ConfigurableAttribute>();

            foreach (var info in props)
            {
                var attribs = info.GetCustomAttributes(typeof(ConfigurableAttribute), true);

                if (attribs.Length != 0)
                    cols.Add(attribs[0] as ConfigurableAttribute);
            }

            ConfigurableAttributeCache.Add(o.GetType(), cols.ToArray());

            return cols.ToArray();
        }
    }
}