using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data;
using System.Threading;
using GrainManage.Common;

namespace GrainManage.Core
{
    public abstract class BaseUnitOfWork : DbContext, IUnitOfWorkContext
    {
        #region 初始化
        static BaseUnitOfWork() { AddInterception(); }
        private List<DbContextTransaction> transList = null;
        public BaseUnitOfWork(string connectionName = "DefaultConnection")
            : base(string.Format("name={0}", connectionName))
        {
            base.Configuration.ProxyCreationEnabled = true;
            base.Configuration.LazyLoadingEnabled = true;
            base.Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            AddConfiguations(modelBuilder);
        }
        protected abstract void AddConfiguations(DbModelBuilder modelBuilder);

        [System.Diagnostics.Conditional("DEBUG")]
        protected static void AddInterception()
        {
            var logger = new EFIntercepterLogging();
            System.Data.Entity.Infrastructure.Interception.DbInterception.Add(logger);
        }

        #endregion

        #region 增删改

        public T Add<T>(T item) where T : class
        {
            if (item != default(T))
            {
                var entry = base.Entry<T>(item);
                if (entry.State == EntityState.Detached)
                {
                    return base.Set<T>().Add(item);
                }
            }
            return default(T);
        }
        public void Update<T>(T item) where T : class
        {
            if (item != default(T))
            {
                var entry = base.Entry<T>(item);
                if (entry.State == EntityState.Detached)
                {
                    base.Set<T>().Attach(item);
                }
                entry.State = EntityState.Modified;
            }
        }
        public void AddOrUpdate<T>(T item) where T : class
        {
            if (item != default(T))
            {
                var entry = base.Entry<T>(item);
                if (entry.State == EntityState.Detached)
                {
                    base.Set<T>().AddOrUpdate(item);
                }
            }
        }
        public T Remove<T>(T item) where T : class
        {
            if (item != default(T))
            {
                var entry = base.Entry<T>(item);
                if (entry.State == EntityState.Detached)
                {
                    base.Set<T>().Attach(item);
                }
                //entry.State = EntityState.Deleted;
                return base.Set<T>().Remove(item);
            }
            return default(T);
        }
        public IEnumerable<T> Add<T>(IEnumerable<T> items) where T : class
        {
            var list = new List<T>();
            try
            {
                base.Configuration.AutoDetectChangesEnabled = false;
                foreach (var item in items)
                {
                    var model = Add(item);
                    if (model != default(T))
                    {
                        list.Add(model);
                    }
                }
            }
            finally
            {
                base.Configuration.AutoDetectChangesEnabled = true;
            }
            return list;
        }
        public void Update<T>(IEnumerable<T> items) where T : class
        {
            try
            {
                base.Configuration.AutoDetectChangesEnabled = false;
                foreach (var item in items)
                {
                    Update(item);
                }
            }
            finally
            {
                base.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        public void AddOrUpdate<T>(IEnumerable<T> items) where T : class
        {
            try
            {
                base.Configuration.AutoDetectChangesEnabled = false;
                foreach (var item in items)
                {
                    AddOrUpdate(item);
                }
            }
            finally
            {
                base.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        public IEnumerable<T> Remove<T>(IEnumerable<T> items) where T : class
        {
            var list = new List<T>();
            try
            {
                base.Configuration.AutoDetectChangesEnabled = false;
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
                base.Configuration.AutoDetectChangesEnabled = true;
            }
            return list;
        }
        #endregion

        #region 查询
        public IDbSet<T> Entities<T>() where T : class
        {
            return base.Set<T>();
        }
        public IEnumerable<T> ExecuteQuery<T>(string sql, params object[] parameters)
        {
            return base.Database.SqlQuery<T>(sql, parameters);
        }
        public int ExecuteNonQuery(string sql, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sql, parameters);
        }
        #endregion


        public void SaveChanges(bool forceSave = false)
        {
            if (!LazyCommitEnabled || forceSave)
            {
                base.SaveChanges();
            }
        }

        public ITransaction BeginTransaction(System.Data.IsolationLevel isolationLevel = IsolationLevel.RepeatableRead)
        {
            var tran = base.Database.BeginTransaction(isolationLevel);
            if (transList == null) { transList = new List<DbContextTransaction>(); }
            transList.Add(tran);
            return new EFTransaaction(tran);
        }

        public bool LazyLoadingEnabled
        {
            get { return base.Configuration.LazyLoadingEnabled; }
            set { base.Configuration.LazyLoadingEnabled = value; }
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
