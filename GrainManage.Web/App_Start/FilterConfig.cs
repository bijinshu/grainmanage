using System.Web.Mvc;

namespace GrainManage.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogExceptionAttribute());
            filters.Add(new CheckLoginAttribute());
            filters.Add(new LogActionAttribute());
        }
    }
}