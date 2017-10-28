using GrainManage.Common;
using System;
using System.Data;

namespace GrainManage.Core
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 是否允许延迟提交
        /// </summary>
        bool LazyCommitEnabled { get; set; }
        /// <summary>
        /// 开启事务
        /// </summary>
        /// <param name="isolationLevel">事务隔离级别</param>
        /// <returns></returns>
        ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.RepeatableRead);
        /// <summary>
        /// 提交更改
        /// </summary>
        void SaveChanges(bool forceSave = false);
    }
}
