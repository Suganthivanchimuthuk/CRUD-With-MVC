using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
   public interface IVehicleInfoRepository
    {

        public VehicleInfo InsertSP(VehicleInfo VehicleInfo);
        public IEnumerable<VehicleInfo> GetVehicleInfoSP();
        public VehicleInfo UpdateVehicleInfoSP(long Id, VehicleInfo P);
        public VehicleInfo ReadVehicleInfoByNumber(long id);
        public void DeleteVehicleInfoSP(long id);

    }
}
