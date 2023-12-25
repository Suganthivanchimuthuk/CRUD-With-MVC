using System;

namespace DapperDataAccessLayer
{
    public class VehicleInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long VehicleNumber { get; set; }
        public string RCNumber { get; set; }
        public long OwnerPhNo { get; set; }
        public DateTime PurchaseDate { get; set; }
    }    

}
