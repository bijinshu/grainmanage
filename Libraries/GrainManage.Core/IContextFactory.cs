using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Core
{
    public interface IContextFactory : IDisposable
    {
        IUnitOfWorkContext Get<T>() where T : class;
    }
}
