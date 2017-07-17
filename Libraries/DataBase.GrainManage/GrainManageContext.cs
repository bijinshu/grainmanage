using GrainManage.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.GrainManage
{
    public class GrainManageContext : BaseUnitOfWork
    {
        static GrainManageContext()
        {
            Database.SetInitializer<GrainManageContext>(null);
        }
        public GrainManageContext()
            : base("DefaultConnection")
        {
        }

        protected override void AddConfiguations(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.Configurations.AddFromAssembly(assembly);
        }
    }
}
