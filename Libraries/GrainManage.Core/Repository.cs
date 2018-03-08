using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace GrainManage.Core
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        #region 私有变量及构造函数
        private IUnitOfWorkContext context;
        public Repository(IContextFactory factory)
        {
            context = factory.Get<T>();
        }
        #endregion

        #region 事件
        /// <summary>
        /// 添加数据前执行动作
        /// </summary>
        public event Action<T> OnAdding;
        /// <summary>
        /// 更新数据前执行动作
        /// </summary>
        public event Action<T> OnUpdating;
        /// <summary>
        /// 删除数据前执行动作
        /// </summary>
        //public event Action<T> OnDeleting;
        #endregion

        #region 增删改函数

        public T Add(T item)
        {
            if (OnAdding != null) { OnAdding(item); }
            var result = context.Add(item);
            context.SaveChanges();
            return result;
        }
        public IEnumerable<T> Add(IEnumerable<T> items)
        {
            if (OnAdding != null)
            {
                foreach (var item in items)
                {
                    OnAdding(item);
                }
            }
            var result = context.Add(items);
            context.SaveChanges();
            return result;
        }
        public void Update(T item)
        {
            if (OnUpdating != null) { OnUpdating(item); }
            context.Update(item);
            context.SaveChanges();
        }
        public void Update(IEnumerable<T> items)
        {
            if (OnUpdating != null)
            {
                foreach (var item in items)
                {
                    OnUpdating(item);
                }
            }
            context.Update(items);
            context.SaveChanges();
        }
        public T Delete(T item)
        {
            var result = default(T);
            if (item != null)
            {
                result = context.Remove(item);
                context.SaveChanges();
            }
            return result;
        }
        public IEnumerable<T> Delete(IEnumerable<T> items)
        {
            IEnumerable<T> result = default(IEnumerable<T>);
            if (items != null && items.Any())
            {
                result = context.Remove(items);
                context.SaveChanges();
            }
            return result;
        }
        public int Delete(IEnumerable<string> ids)
        {
            int effected = 0;
            if (ids != null && ids.Any())
            {
                var sqlBuilder = new StringBuilder();
                sqlBuilder.AppendFormat("DELETE FROM {0} WHERE Id IN ", typeof(T).Name);
                sqlBuilder.Append(" ( ");
                var list = ids.ToList();
                var parameters = new SqlParameter[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    var paraName = string.Format("@Param{0},", i);
                    sqlBuilder.Append(paraName);
                    parameters[i] = new SqlParameter(paraName.Trim(','), list[i]);
                }
                sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
                sqlBuilder.Append(" ) ");
                var s = sqlBuilder.ToString();
                effected = context.ExecuteNonQuery(sqlBuilder.ToString(), parameters);
            }
            return effected;
        }
        public int DeleteAll()
        {
            var sql = string.Format("DELETE FROM {0}", typeof(T).Name);
            var effected = context.ExecuteNonQuery(sql, null);
            return effected;
        }
        #endregion

        public T Get(object existingId)
        {
            return Entities.Find(existingId);
        }
        public IQueryable<T> GetFiltered(Expression<Func<T, bool>> filter, bool hasTracking = false, Expression<Func<T, Object>> orderByExpression = null, bool asc = true)
        {
            var dic = ConvertOrder(orderByExpression, asc);
            return GetFiltered(filter, hasTracking, dic, null);
        }
        public IQueryable<T> GetFiltered(Expression<Func<T, bool>> filter, bool hasTracking, IDictionary<Expression<Func<T, Object>>, OrderEnum> orderBy, params Expression<Func<T, Object>>[] pathList)
        {
            var dic = ConvertOrder(orderBy);
            return GetFiltered(filter, hasTracking, dic, pathList);
        }
        public IEnumerable<T> GetPaged(out int total, int pageIndex, int pageSize, Expression<Func<T, bool>> filter = null, Expression<Func<T, Object>> orderByExpression = null, bool asc = true)
        {
            var dic = ConvertOrder(orderByExpression, asc);
            return GetPaged(out total, pageIndex, pageSize, dic, filter, null);
        }
        public IEnumerable<T> GetPaged(out int total, int pageIndex, int pageSize, Expression<Func<T, bool>> filter, IDictionary<Expression<Func<T, Object>>, OrderEnum> orderBy, params Expression<Func<T, Object>>[] pathList)
        {
            var dic = ConvertOrder(orderBy);
            return GetPaged(out total, pageIndex, pageSize, dic, filter, pathList);
        }
        public IQueryable<T> QueryNoTracking
        {
            get { return Entities.AsNoTracking(); }
        }
        public int ExecuteCommand(string sql, params object[] parameters)
        {
            return context.ExecuteNonQuery(sql, parameters);
        }
        public IUnitOfWork UnitOfWork
        {
            get { return context; }
        }
        public Dictionary<Expression<Func<T, object>>, OrderEnum> SortDictionary
        {
            get { return new Dictionary<Expression<Func<T, Object>>, OrderEnum>(); }
        }
        #region 辅助函数
        private DbSet<T> Entities
        {
            get { return context.Entities<T>(); }
        }
        private IQueryable<T> GetFiltered(Expression<Func<T, bool>> filter, bool hasTracking, IDictionary<string, OrderEnum> orderBy, IEnumerable<Expression<Func<T, Object>>> pathList)
        {
            IQueryable<T> query = hasTracking ? Entities : QueryNoTracking;
            if (pathList != null) { foreach (var path in pathList) { query = query.Include(path); } }
            if (filter != null) { query = query.Where(filter); }
            query = BuildSortableQuery(query, orderBy, false);
            return query;
        }
        private List<T> GetPaged(out int total, int pageIndex, int pageSize, IDictionary<string, OrderEnum> orderBy, Expression<Func<T, bool>> filter, IEnumerable<Expression<Func<T, Object>>> pathList)
        {
            IQueryable<T> query = QueryNoTracking;
            if (filter != null) { query = query.Where(filter); }
            total = query.Count();
            if (pageSize <= 0) { return new List<T>(); }
            if (pathList != null) { foreach (var path in pathList) { query = query.Include(path); } }
            query = BuildSortableQuery(query, orderBy, true);
            if (pageIndex > 0) { query = query.Skip(pageIndex * pageSize); }
            if (pageSize < int.MaxValue) { query = query.Take(pageSize); }
            return query.ToList();
        }
        private static Dictionary<string, OrderEnum> ConvertOrder(IDictionary<Expression<Func<T, Object>>, OrderEnum> orderBy)
        {
            Dictionary<string, OrderEnum> dic = null;
            if (orderBy != null && orderBy.Count > 0)
            {
                dic = new Dictionary<string, OrderEnum>();
                foreach (var item in orderBy)
                {
                    var memberName = item.Key.Body.ToString();
                    memberName = Regex.Replace(memberName, @"\w*\(+", string.Empty);
                    memberName = Regex.Replace(memberName, @"\)+\w*", string.Empty);
                    memberName = Regex.Replace(memberName, @"\s*\w*\s*\.+\s*", string.Empty);
                    memberName = memberName.Trim().Split(',')[0];
                    dic[memberName] = item.Value;
                }
            }
            return dic;
        }
        private static Dictionary<string, OrderEnum> ConvertOrder(Expression<Func<T, Object>> orderByExpression, bool asc)
        {
            Dictionary<string, OrderEnum> dic = null;
            if (orderByExpression != null)
            {
                var toConvertDic = new Dictionary<Expression<Func<T, Object>>, OrderEnum>();
                toConvertDic[orderByExpression] = asc ? OrderEnum.Asc : OrderEnum.Desc;
                dic = ConvertOrder(toConvertDic);
            }
            return dic;
        }
        private static IQueryable<T> BuildSortableQuery(IQueryable<T> query, IDictionary<string, OrderEnum> orderBy, bool forceSort)
        {
            if (forceSort && (orderBy == null || orderBy.Count == 0))
            {
                orderBy = new Dictionary<string, OrderEnum>();
                var property = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).First();
                orderBy.Add(property.Name, OrderEnum.Asc);
            }
            if (orderBy != null && orderBy.Count > 0)
            {
                var modelType = typeof(T);
                var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
                bool hasOrdered = false;
                var parameter = Expression.Parameter(modelType, "p");
                foreach (var item in orderBy)
                {
                    var property = modelType.GetProperty(item.Key, bindingFlags);
                    if (property != null)
                    {
                        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                        var orderByExp = Expression.Lambda(propertyAccess, parameter);
                        var orderMethodName = string.Empty;
                        if (hasOrdered)
                        {
                            orderMethodName = item.Value == OrderEnum.Desc ? "ThenByDescending" : "ThenBy";
                        }
                        else
                        {
                            hasOrdered = true;
                            orderMethodName = item.Value == OrderEnum.Desc ? "OrderByDescending" : "OrderBy";
                        }
                        var resultExp = Expression.Call(typeof(Queryable), orderMethodName, new Type[] { modelType, property.PropertyType }, query.Expression, Expression.Quote(orderByExp));
                        query = query.Provider.CreateQuery<T>(resultExp);
                    }
                }
            }
            return query;
        }
        #endregion

    }
}
