using ODP_Studio_Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Infrastructure.CommonFunction
{
    public static class ObjectUpdator
    {
        public static void UpdateNonNullProperties (object target , object source)
        {
            if (target == null || source == null)
            {
                throw new ArgumentNullException();
            }

            var targetType = target.GetType ();
            var targetProperties = targetType.GetProperties();
            

            foreach ( var property in targetProperties )
            {
                if (!property.CanRead || !property.CanWrite)
                {
                    continue;
                }

                var sourceValue = property.GetValue(source);

                if (sourceValue == null)
                    continue;
                if(property.PropertyType == typeof(string))
                {
                    if(!string.IsNullOrEmpty((string) sourceValue))
                    {
                        property.SetValue(target, sourceValue);
                    }
                }
                
                else if (Nullable.GetUnderlyingType(property.PropertyType) != null) // Nullable types
                {
                    property.SetValue(target, sourceValue);
                }

                else if (!property.PropertyType.IsClass || property.PropertyType.IsValueType) // Primitive types types
                {
                    property.SetValue(target, sourceValue);
                }
                else
                {
                    var targetNested = property.GetValue(target);
                    if(targetNested == null)
                    {
                        property.SetValue(target, sourceValue);
                    }
                    else
                    {
                        UpdateNonNullProperties(targetNested, sourceValue);
                    }
                }

            }
        }
    }
}
