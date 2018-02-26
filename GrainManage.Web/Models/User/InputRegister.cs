namespace GrainManage.Web.Models.User
{
    public class InputRegister
    {
        public bool IsShop { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string RealName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string Weixin { get; set; }
        public int Gender { get; set; }
        public string Remark { get; set; }
    }
}
