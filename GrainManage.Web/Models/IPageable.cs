
namespace GrainManage.Web.Models
{
    public interface IPageable
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
    }
}
