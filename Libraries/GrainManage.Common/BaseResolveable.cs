//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GrainManage.Common
//{
//    public abstract class BaseResolveable : IResolveable
//    {
//        private Common.IResolver _resolver = null;
//        public Common.IResolver Resolver
//        {
//            get
//            {
//                if (_resolver != null)
//                {
//                    return _resolver;
//                }
//                else if (ResolverHandler != null)
//                {
//                    _resolver = ResolverHandler();
//                }
//                return _resolver;
//            }
//            set
//            {
//                _resolver = value;
//            }
//        }
//        public Func<GrainManage.Common.IResolver> ResolverHandler { get; set; }
//    }
//}
