
namespace GrainManage.Web.Models.User
{
    public class InputChangePassword : BaseInput
    {
        public string OldPwd { get; set; }
        public string NewPwd { get; set; }
    }
}
