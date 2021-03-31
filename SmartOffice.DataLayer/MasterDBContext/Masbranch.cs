using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Masbranch
    {
        public int BrId { get; set; }
        public int Bid { get; set; }
        public string BrName { get; set; }
        public long BrAddressId { get; set; }
        public string BrContactNo { get; set; }
        public string BrEmailId { get; set; }
        public long BrManagerId { get; set; }
        public short BrIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
