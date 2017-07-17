using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Common
{
    public interface IResolver
    {
        T Get<T>(Type serviceType = null) where T : class;
    }
}
