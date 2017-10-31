using GrainManage.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Dal
{
    public class DapperTransaction : ITransaction
    {
        private IDbTransaction transaction = null;
        public DapperTransaction(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }
        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            transaction.Dispose();
            if (transaction.Connection != null)
            {
                transaction.Connection.Dispose();
            }
        }
    }
}
