using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace GarageLogic.Extensions
{
    public static class ToStringExtensionMethods
    {
        public static string ToString(this object i_Obj, Type i_ObjectType)
        {
            string stringRepresentation = string.Empty;
            foreach (PropertyInfo propertyInfo in i_ObjectType.GetProperties())
            {
                if (propertyInfo.CanRead && Attribute.IsDefined(propertyInfo, typeof(DisplayAttribute)))
                {
                    object propertyDisplayValue = ((DisplayAttribute)propertyInfo.GetCustomAttribute(typeof(DisplayAttribute))).Name;
                    object propertyValue = propertyInfo.GetValue(i_Obj, null);
                    //handle a collectiion property case
                    if (propertyInfo.PropertyType.FindInterfaces(myInterfaceFilter, typeof(IList<>).FullName).Length > 0) 
                    {
                        stringRepresentation += string.Format("\n" + propertyDisplayValue + " : \n");
                        ICollection collection = propertyValue as ICollection;
                        if(collection != null)
                        {
                            stringRepresentation = collection.Cast<object>().
                                        Aggregate(stringRepresentation, (i_Current, i_O) => i_Current + i_O.ToString(i_O.GetType()));
                        }
                    }
                    else //regular property
                    {
                        stringRepresentation += string.Format(propertyDisplayValue + " : " + propertyValue + "\n");
                    }
                }
            }
            return stringRepresentation;
        }

        private static bool myInterfaceFilter(Type i_Type, object i_FilterCriteria)
        {
            if(i_Type == typeof(ICollection))
                return true;

            return false;
        }
    }
}
