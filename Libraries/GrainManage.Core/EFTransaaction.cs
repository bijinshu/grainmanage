using GrainManage.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace GrainManage.Core
{
    public class EFTransaaction : ITransaction
    {
        private readonly IDbContextTransaction tran = null;
        public EFTransaaction(IDbContextTransaction transaction)
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
