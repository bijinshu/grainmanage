using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class ExpandEnumerable
    {
        /// <summary>
        /// 按列名进行投影,列名间用逗号分割
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="columns">列名</param>
        /// <returns></returns>
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source, string columns) where TSource : new()
        {
            return ToList(source, columns.TrimedValue().Split(','));
        }

        /// <summary>
        /// 按列名进行投影
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="columnList">列名列表</param>
        /// <returns></returns>
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source, IEnumerable<string> columnList) where TSource : new()
        {
            if (source is IQueryable<TSource>)
            {
                source = source.ToList();
            }
            return source.Copy(columnList) as List<TSource>;
        }
    }
}
