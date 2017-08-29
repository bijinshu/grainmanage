
namespace GrainManage.Web.Models.Image
{
    public class InputGetImages : BaseInput
    {
        public bool WithFile { get; set; }
        public DesiredSize DesiredSize { get; set; }
    }
}
