using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace Common.Utility
{
    public static class EnumHelper
    {
        public static string GetDisplayText(Enum enumValue)
        {
            if (enumValue == null)
            {
                throw new ArgumentNullException("enumValue");
            }
            Type enumType = enumValue.GetType();
            while (enumType.IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && enumType.GetGenericArguments() != null
                    && enumType.GetGenericArguments().Length == 1 && enumType.GetGenericArguments()[0].IsEnum)
            {
                enumType = enumType.GetGenericArguments()[0];
            }

            if (!enumType.IsEnum)
            {
                return string.Empty;
            }

            string description = enumValue.ToString();
            FieldInfo field = enumType.GetField(description);
            if (field != null)
            {
                string resKey = string.Format("{0}_{1}", enumType.Name, field.Name);
                object[] attrs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    DescriptionAttribute desc = attrs[0] as DescriptionAttribute;
                    description = desc.Description;
                }
                description = description ?? field.Name;
            }
            return description;
        }

        public static string ToDisplayText(this Enum value)
        {
            return EnumHelper.GetDisplayText(value);
        }

        public static string GetEnumDesc(Enum e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("enumValue");
            }
            Type enumType = e.GetType();
            while (enumType.IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && enumType.GetGenericArguments() != null
                    && enumType.GetGenericArguments().Length == 1 && enumType.GetGenericArguments()[0].IsEnum)
            {
                enumType = enumType.GetGenericArguments()[0];
            }
            if (!enumType.IsEnum)
            {
                return string.Empty;
            }
            var enumInfo = e.GetType().GetField(e.ToString());
            var enumAttributes = (DescriptionAttribute[])enumInfo.
                GetCustomAttributes(typeof(DescriptionAttribute), false);
            return enumAttributes.Length > 0 ? enumAttributes[0].Description : e.ToString();
        }

        public static string ToEnumDesc(this Enum value)
        {
            return EnumHelper.GetEnumDesc(value);
        }

        public static string GetDescription(Enum value)
        {
            return value == null ? null : GetDescription(value, value.GetType());
        }

        public static string GetDescription(object enumValue, Type enumType)
        {
            string description = null;
            if (enumValue != null && enumValue.ToString().Trim() != String.Empty)
            {
                Type enumValueType = enumValue.GetType();
                enumType = enumValueType.IsEnum ? enumValueType : enumType;
                if (enumType != null && enumType.IsEnum)
                {
                    object o = null;
                    if (enumValueType.IsEnum)
                    {
                        o = enumValue;
                    }
                    else
                    {
                        try
                        {
                            o = Enum.Parse(enumType, enumValue.ToString(), true);
                        }
                        catch
                        {
                            o = null;
                        }
                    }
                }
            }
            return description;
        }

        public static Dictionary<int, string> ToDictionary<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<object>()
                .ToDictionary(k => (int)k, v => ((Enum)v).ToEnumDesc());
        }
    }
}
