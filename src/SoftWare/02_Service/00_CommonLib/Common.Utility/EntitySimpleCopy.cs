//************************************************************************
// 用户名				新蛋
// 系统名				通用方法
// 子系统名		        实体之间赋值
// 作成者				Tom
// 改版日				2011.8.11
// 改版内容				新建
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Utility
{
    public sealed class EntitySimpleCopy
    {
        /// <summary>
        /// 两个实体的关系
        /// </summary>
        public class PropertyMapper
        {
            public PropertyInfo SourceProperty
            {
                get;
                set;
            }
            public PropertyInfo TargetProperty
            {
                get;
                set;
            }

        }

        /// <summary>
        /// 获取两个实体对应关系
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        private static IList<PropertyMapper> GetMapperProperties(Type sourceType, Type targetType)
        {
            var sourceProperties = sourceType.GetProperties();
            var targetProperties = targetType.GetProperties();
            return (from s in sourceProperties
                    from t in targetProperties
                    where s.Name == t.Name && s.CanRead && t.CanWrite && s.PropertyType == t.PropertyType
                    select new PropertyMapper
                    {
                        SourceProperty = s,
                        TargetProperty = t
                    }).ToList();
        }

        /// <summary>
        /// 两个实体赋值
        /// </summary>
        /// <param name="source">源对象</param>
        /// <param name="target">目标对象</param>
        public static void CopyProperties(object source, object target)
        {
            if (source == null || target == null) return;
            var sourceType = source.GetType();
            var targetType = target.GetType();
            var mapperProperties = GetMapperProperties(sourceType, targetType);
            if (mapperProperties == null) return;
            var count = mapperProperties.Count;
            for (var index = 0; index < count; index++)
            {
                var property = mapperProperties[index];
                var sourceValue = property.SourceProperty.GetValue(source, null);
                if (property.SourceProperty.PropertyType.IsValueType || property.SourceProperty.PropertyType == typeof(string))
                {
                    property.TargetProperty.SetValue(target, sourceValue, null);
                }
            }
        }

    }
}
