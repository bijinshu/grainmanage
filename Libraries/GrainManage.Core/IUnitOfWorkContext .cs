using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GrainManage.Core
{
    public interface IUnitOfWorkContext : IUnitOfWork
    {
        /// <summary>
        /// 标记为待添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        T Add<T>(T item) where T : class;
        IEnumerable<T> Add<T>(IEnumerable<T> items) where T : class;
        /// <summary>
        /// 标记为待修改数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        void Update<T>(T item) where T : class;
        void Update<T>(IEnumerable<T> items) where T : class;
        /// <summary>
        /// 标记为待删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        T Remove<T>(T item) where T : class;
        IEnumerable<T> Remove<T>(IEnumerable<T> items) where T : class;

        int ExecuteNonQuery(string sql, params object[] parameters);

        /// <summary>
        /// 数据集合（有状态）
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        DbSet<T> Entities<T>() where T : class;
    }
}
