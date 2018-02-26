using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.GrainManage.Models.BM
{
    public class Company
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
