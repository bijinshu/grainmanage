using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Core
{
    public interface IRepository<T> where T : class,new()
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Add(T item);
        IEnumerable<T> Add(IEnumerable<T> items);
        /// <summary>
        /// 更改数据
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
        void Update(IEnumerable<T> items);
        void AddOrUpdate(T item);
        void AddOrUpdate(IEnumerable<T> items);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        T Delete(T item);
        IEnumerable<T> Delete(IEnumerable<T> items);
        int Delete(IEnumerable<string> ids);
        int DeleteAll();
        /// <summary>
        /// 根据主键获取数据
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        T Get(object primaryKey);
        /// <summary>
        /// 筛选数据
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <param name="hasTracking">是否进行状态跟踪</param>
        /// <param name="pathList">需要同时加载的路径</param>
        /// <returns></returns>
        IQueryable<T> GetFiltered(Expression<Func<T, bool>> filter, bool hasTracking = false, Expression<Func<T, Object>> orderByExpression = null, bool asc = true);
        IQueryable<T> GetFiltered(Expression<Func<T, bool>> filter, bool hasTracking, IDictionary<Expression<Func<T, Object>>, OrderEnum> orderBy, params Expression<Func<T, Object>>[] pathList);
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="total">记录总数</param>
        /// <param name="pageIndex">页数索引（从0开始）</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="pathList">需要同时加载的路径</param>
        /// <returns></returns>
        IEnumerable<T> GetPaged(out int total, int pageIndex, int pageSize, Expression<Func<T, bool>> filter, IDictionary<Expression<Func<T, Object>>, OrderEnum> orderBy, params Expression<Func<T, Object>>[] pathList);
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="total">记录总数</param>
        /// <param name="pageIndex">页数索引（从0开始）</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="filter"></param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="isAsc">是否正序排序</param>
        /// <returns></returns>
        IEnumerable<T> GetPaged(out int total, int pageIndex, int pageSize, Expression<Func<T, bool>> filter = null, Expression<Func<T, Object>> orderByExpression = null, bool isAsc = true);
        IUnitOfWork UnitOfWork { get; }

        System.Collections.Generic.Dictionary<Expression<Func<T, Object>>, OrderEnum> SortDictionary { get; }

        IEnumerable<P> ExecuteQuery<P>(string sql, params object[] parameters);
        int ExecuteCommand(string sql, params object[] parameters);

    }

    public enum OrderEnum
    {
        Desc,//倒序排序
        Asc//正序排序
    }
}
