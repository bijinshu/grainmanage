
namespace GrainManage.Web.Models.Image
{
    public class InputGetImages : InputModel
    {
        public bool WithFile { get; set; }
        public DesiredSize DesiredSize { get; set; }
    }
}
