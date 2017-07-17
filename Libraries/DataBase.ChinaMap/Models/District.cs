using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.ChinaMap.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int UpID { get; set; }
        public virtual District Owner { get; set; }
        public virtual IList<District> Children { get; set; }
    }
}
