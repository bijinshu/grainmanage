namespace GrainManage.Web.Models
{
    public class InputModel : BaseInput, IPageable
    {
        public InputModel()
        {
            PageIndex = 0;
            PageSize = int.MaxValue;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
