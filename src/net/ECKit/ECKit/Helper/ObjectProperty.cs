using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace com.eoncoder.ECKit.Common
{
    public class ObjectProperty
    {

        public static IEnumerable<PropertyInfo> EnumerablePropertiesWithObject(object obj)
        {
            return obj.GetType().GetProperties();
        }

        public static IEnumerable<PropertyInfo> EnumerableAttributesByClass<ATTRIBUTE>(object obj)
            where ATTRIBUTE : System.Attribute
        {
            return EnumerablePropertiesWithObject(obj).Where(x => x.GetCustomAttribute(typeof(ATTRIBUTE), true) != null);
        }

        public static IEnumerable<ATTRIBUTE> EnumerableAttributesByType<ATTRIBUTE>(Type typeIn)
            where ATTRIBUTE : System.Attribute
        {
            ATTRIBUTE v_attribute = typeIn.GetTypeInfo().GetCustomAttribute<ATTRIBUTE>();
            List<ATTRIBUTE> v_return = new List<ATTRIBUTE>();
            if ( v_attribute != null )
            {
                v_return.Add(v_attribute);
            }

            return v_return;

            /* .NET 
            object[] v_objectAttributes = typeIn.GetTypeInfo().GetCustomAttributes(typeof(Attribute), true);
            List<ATTRIBUTE> v_list = new List<ATTRIBUTE>();

            foreach (object item in v_objectAttributes)
            {
                if (item.GetType() == typeof(ATTRIBUTE))
                {
                    v_list.Add((ATTRIBUTE)item);
                }
            }

            return v_list;
            */
        }

        /*
        public static IEnumerable<ATTRIBUTE> EnumerableAttributesByObject<ATTRIBUTE>(object obj)
            where ATTRIBUTE : System.Attribute
        {
            return EnumerableAttributesByType<ATTRIBUTE>(obj.GetType());
        }

        
        
       
        public static ATTRIBUTE AttributeWithObject<ATTRIBUTE>(object obj)
            where ATTRIBUTE : System.Attribute
        {
            return EnumerableAttributesByObject<ATTRIBUTE>(obj).FirstOrDefault();
        }
         */
        public static ATTRIBUTE AttributeWithPropertyInfo<ATTRIBUTE>(PropertyInfo property)
            where ATTRIBUTE : System.Attribute
        {
            return property.GetCustomAttribute<ATTRIBUTE>();
        }

        public static IEnumerable<PropertyInfo> EnumerablePropertiesWithType(Type type)
        {
            List<PropertyInfo> v_return = new List<PropertyInfo>();

            Dictionary<Type, List<PropertyInfo>> v_properties = new Dictionary<Type, List<PropertyInfo>>();
            Type v_BaseType = type;
            do
            {
                List<PropertyInfo> v_propertiesBase = v_BaseType.GetProperties().ToList();
                v_properties.Add(v_BaseType, v_propertiesBase);
                v_BaseType = v_BaseType.GetTypeInfo().BaseType;
            }
            while (v_BaseType.Equals(typeof(object)) == false );

            // Ordered By Last Class
            var v_reverse = v_properties.Reverse();
            var v_Last = v_reverse.Last().Value;
            
            foreach (var item in v_reverse)
            {
                foreach (var property in item.Value)
                {
                    if (v_return.Exists(x => x.Name.Equals(property.Name)) == false)
                    {
                        v_return.Add(v_Last.Find(x => x.Name.Equals(property.Name)));
                    }                    
                }
                
            }

            return v_return;
        }

        public static IEnumerable<PropertyInfo> EnumerablePropertiesByAncestorsWithType(Type type)
        {
            List<PropertyInfo> v_return = new List<PropertyInfo>();
            List<PropertyInfo> v_temporal = new List<PropertyInfo>();

            Type v_typeBase = type.GetTypeInfo().BaseType;
            if ( v_typeBase != null 
                && v_typeBase != typeof(object))
            {
                IEnumerable<PropertyInfo> v_base = EnumerablePropertiesByAncestorsWithType(v_typeBase);
                v_temporal.AddRange(v_base);
            }
            else if (v_typeBase == typeof(object))
            {
                v_return.AddRange(EnumerablePropertiesWithType(type));
                return v_return;
            }
            IEnumerable<PropertyInfo> v_new = EnumerablePropertiesWithType(type);

            v_new.Except(v_temporal).ToList().ForEach(x => v_return.Add(x));

            return v_return;
        }
    }
}
