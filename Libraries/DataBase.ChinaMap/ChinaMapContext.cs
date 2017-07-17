using GrainManage.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.ChinaMap
{
    public class ChinaMapContext : BaseUnitOfWork
    {
        static ChinaMapContext()
        {
            Database.SetInitializer<ChinaMapContext>(null);
        }
        public ChinaMapContext()
            : base("ChinaMapConnection")
        {
        }

        protected override void AddConfiguations(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.Configurations.AddFromAssembly(assembly);
        }
    }
}
