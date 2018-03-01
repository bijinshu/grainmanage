using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrainManage.Web.Models.Price
{
    public class InputSearch : Pageable
    {
        public string ProductName { get; set; }
        public int? PriceType { get; set; }
    }
}
