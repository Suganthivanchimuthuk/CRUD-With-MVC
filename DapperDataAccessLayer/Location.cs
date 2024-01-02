using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
    public class Location
    {
        public static object LocationId { get; internal set; }
        public long LocationID { get; set; }
        public string LocationName { get; set; }
    }
}
