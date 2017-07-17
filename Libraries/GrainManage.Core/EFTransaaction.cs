using GrainManage.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrainManage.Core
{
    public class EFTransaaction : ITransaction
    {
        private readonly DbContextTransaction tran = null;
        public EFTransaaction(DbContextTransaction transaction)
        {
            tran = transaction;
        }
        public void Dispose()
        {
            if (tran != null) { tran.Dispose(); }
        }

        public void Commit()
        {
            tran.Commit();
        }

        public void Rollback()
        {
            tran.Rollback();
        }
    }
}
