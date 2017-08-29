using System;

namespace GrainManage.Web.Models.Account
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public bool IsApproved { get; set; }
        public bool IsOnLine { get; set; }
        public bool CheckLoginIP { get; set; }
        public string NickName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public string EncryptKey { get; set; }
        public int ResetCount { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastActive { get; set; }
    }
}
