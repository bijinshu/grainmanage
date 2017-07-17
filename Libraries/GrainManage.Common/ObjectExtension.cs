using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 复制内存对象的指定字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="columns">列名之间用逗号分隔</param>
        /// <returns></returns>
        public static T Copy<T>(this T source, string columns) where T : class
        {
            return Copy(source, columns.TrimedValue().Split(','));
        }

        /// <summary>
        /// 复制内存对象的指定字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="columnList">列名列表</param>
        /// <returns></returns>
        public static T Copy<T>(this T source, IEnumerable<string> columnList) where T : class
        {
            var sourceType = typeof(T);
            if (sourceType.IsValueType || sourceType == typeof(string) || source == null || source == DBNull.Value)
            {
                return source;
            }
            columnList = columnList ?? new List<string>();
            columnList = columnList.Where(f => !string.IsNullOrWhiteSpace(f)).Select(s => s.Trim()).Distinct();
            if (sourceType.IsArray)
            {
                var elementType = sourceType.GetElementType();
                if (elementType.IsClass && !elementType.IsAbstract && elementType != typeof(string))
                {
                    var propertyList = elementType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(f => columnList.Contains(f.Name));
                    var sourceArray = source as Array;
                    var currentArray = Array.CreateInstance(elementType, sourceArray.Length);
                    for (int i = 0; i < sourceArray.Length; i++)
                    {
                        var sourceElement = sourceArray.GetValue(i);
                        var currentElement = Activator.CreateInstance(elementType);
                        foreach (var property in propertyList)
                        {
                            property.SetValue(currentElement, DeepClone(property.GetValue(sourceElement)));
                        }
                        currentArray.SetValue(currentElement, i);
                    }
                    return currentArray as T;
                }
                return source;
            }
            else if (sourceType.IsGenericType && source is IEnumerable)
            {
                var genericTypeDefination = typeof(List<>);
                var genericTypeParameter = sourceType.GetGenericArguments().Single();
                if (genericTypeParameter.IsClass && !genericTypeParameter.IsAbstract && !genericTypeParameter.IsInterface)
                {
                    var propertyList = genericTypeParameter.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(f => columnList.Contains(f.Name));
                    var genericType = genericTypeDefination.MakeGenericType(genericTypeParameter);
                    var sourceList = source as IEnumerable;
                    var currentList = Activator.CreateInstance(genericType) as IList;
                    foreach (var item in sourceList)
                    {
                        var currentElement = Activator.CreateInstance(genericTypeParameter);
                        foreach (var property in propertyList)
                        {
                            property.SetValue(currentElement, DeepClone(property.GetValue(item)));
                        }
                        currentList.Add(currentElement);
                    }
                    return currentList as T;
                }
            }
            else if (sourceType.IsClass && !sourceType.IsGenericType && !sourceType.IsAbstract)
            {
                var propertyList = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(f => columnList.Contains(f.Name));
                var currentInstance = Activator.CreateInstance(sourceType);
                foreach (var property in propertyList)
                {
                    property.SetValue(currentInstance, DeepClone(property.GetValue(source)));
                }
                return currentInstance as T;
            }
            return default(T);
        }

        /// <summary>
        /// 是否有非空值
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool HasValue(this string source) { return !string.IsNullOrWhiteSpace(source); }

        /// <summary>
        /// 获取去除空格的值
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string TrimedValue(this string source) { return string.IsNullOrWhiteSpace(source) ? string.Empty : source.Trim(); }
        #region 辅助方法
        /// <summary>
        /// 递归深度复制,当不能创建成员实例时,返回原引用
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static object DeepClone(object source)
        {
            if (source != null && source != DBNull.Value)
            {
                var sourceType = source.GetType();
                if (sourceType.IsValueType || sourceType == typeof(string))
                {
                    return source;
                }
                if (sourceType.IsGenericType && source is IDictionary)
                {
                    var genericTypeDefination = typeof(Dictionary<,>);
                    var genericTypeParameters = sourceType.GetGenericArguments();
                    var genericType = genericTypeDefination.MakeGenericType(genericTypeParameters);
                    var sourceDic = source as IDictionary;
                    var currentDic = Activator.CreateInstance(genericType) as IDictionary;
                    foreach (DictionaryEntry item in sourceDic)
                    {
                        currentDic[item.Key] = DeepClone(item.Value);
                    }
                    return currentDic;
                }
                else if (sourceType.IsArray)
                {
                    var elementType = sourceType.GetElementType();
                    var sourceArray = source as Array;
                    var currentArray = Array.CreateInstance(elementType, sourceArray.Length);
                    for (int i = 0; i < sourceArray.Length; i++)
                    {
                        currentArray.SetValue(DeepClone(sourceArray.GetValue(i)), i);
                    }
                    return currentArray;
                }
                else if (sourceType.IsGenericType && source is IEnumerable)
                {
                    var genericTypeDefination = typeof(List<>);
                    var genericTypeParameter = sourceType.GetGenericArguments().Single();
                    var genericType = genericTypeDefination.MakeGenericType(genericTypeParameter);
                    var sourceList = source as IEnumerable;
                    var currentList = Activator.CreateInstance(genericType) as IList;
                    foreach (var item in sourceList)
                    {
                        currentList.Add(DeepClone(item));
                    }
                    return currentList;
                }
                else if (sourceType.IsClass && !sourceType.IsGenericType && !sourceType.IsAbstract)
                {
                    var currentInstance = Activator.CreateInstance(sourceType);
                    var properties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var property in properties)
                    {
                        var currentValue = DeepClone(property.GetValue(source));
                        property.SetValue(currentInstance, currentValue);
                    }
                    return currentInstance;
                }
            }
            return source;
        }

        #endregion
    }
}
