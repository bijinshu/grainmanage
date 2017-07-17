
namespace GrainManage.Web.Models.Account
{
    public class InputChangePassword : BaseInput
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
