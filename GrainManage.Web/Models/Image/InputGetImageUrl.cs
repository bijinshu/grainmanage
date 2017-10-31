using System.Collections.Generic;

namespace GrainManage.Web.Models.Image
{
    public class InputGetImageUrl : BaseInput
    {
        public List<int> ImageIDs { get; set; }
    }
}
