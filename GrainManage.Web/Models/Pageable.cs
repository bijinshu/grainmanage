
namespace GrainManage.Web.Models
{
    public class Pageable : IPageable
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
