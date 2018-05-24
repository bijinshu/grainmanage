using GrainManage.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;

namespace GrainManage.Core
{
    public abstract class BaseUnitOfWork : DbContext, IUnitOfWorkContext
    {
        #region 初始化
        private List<IDbContextTransaction> transList = null;
        private readonly string ConnectionString = null;
        public BaseUnitOfWork(string connectionName = "DefaultConnection")
        {
            ConnectionString = AppConfig.GetConnectionString(connectionName);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddConfiguations(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString);
            AddInterception(optionsBuilder);
        }
        protected abstract void AddConfiguations(ModelBuilder modelBuilder);

        [System.Diagnostics.Conditional("DEBUG")]
        protected static void AddInterception(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
        #endregion

        #region 增删改

        public new T Add<T>(T item) where T : class
        {
            if (item != default(T))
            {
                var entry = base.Entry<T>(item);
                if (entry.State == EntityState.Detached)
                {
                    return base.Set<T>().Add(item)?.Entity;
                }
            }
            return default(T);
        }
        public new void Update<T>(T item) where T : class
        {
            base.Update(item);
        }
        public new T Remove<T>(T item) where T : class
        {
            if (item != default(T))
            {
                var entry = base.Entry<T>(item);
                if (entry.State == EntityState.Detached)
                {
                    base.Set<T>().Attach(item);
                }
                return base.Set<T>().Remove(item)?.Entity;
            }
            return default(T);
        }
        public IEnumerable<T> Add<T>(IEnumerable<T> items) where T : class
        {
            var list = new List<T>();
            try
            {
                foreach (var item in items)
                {
                    var model = base.Add(item)?.Entity;
                    if (model != default(T))
                    {
                        list.Add(model);
                    }
                }
            }
            finally
            {

            }
            return list;
        }
        public void Update<T>(IEnumerable<T> items) where T : class
        {
            base.UpdateRange(items);
        }
        public IEnumerable<T> Remove<T>(IEnumerable<T> items) where T : class
        {
            var list = new List<T>();
            try
            {
                foreach (var item in items)
                {
                    var model = Remove(item);
                    if (model != default(T))
                    {
                        list.Add(model);
                    }
                }
            }
            finally
            {
            }
            return list;
        }
        #endregion

        #region 查询
        public DbSet<T> Entities<T>() where T : class
        {
            return base.Set<T>();
        }
        public int ExecuteNonQuery(string sql, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sql, parameters);
        }
        #endregion


        public new void SaveChanges(bool forceSave = false)
        {
            if (!LazyCommitEnabled || forceSave)
            {
                base.SaveChanges();
            }
        }

        public ITransaction BeginTransaction(System.Data.IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
        {
            var tran = base.Database.BeginTransaction();
            if (transList == null) { transList = new List<IDbContextTransaction>(); }
            transList.Add(tran);
            return new EFTransaaction(tran);
        }

        public bool LazyCommitEnabled { get; set; }

        public new void Dispose()
        {
            base.Dispose();
            if (transList != null)
            {
                foreach (var tran in transList)
                {
                    try { if (tran != null) tran.Dispose(); }
                    catch { }
                }
                transList.Clear();
                transList = null;
            }
        }

    }
}
