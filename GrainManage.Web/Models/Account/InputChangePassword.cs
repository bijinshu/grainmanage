
namespace GrainManage.Web.Models.Account
{
    public class InputChangePassword : BaseInput
    {
        public string OldPwd { get; set; }
        public string NewPwd { get; set; }
    }
}
