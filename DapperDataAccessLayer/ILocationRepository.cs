using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
    public interface ILocationRepository
    {
        public IEnumerable<Location> GetAllLocations();
    }
}
