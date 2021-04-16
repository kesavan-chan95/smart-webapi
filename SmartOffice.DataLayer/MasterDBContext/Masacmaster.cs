using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Masacmaster
    {
        public long AcId { get; set; }
        public long Bid { get; set; }
        public int? AcheadCode { get; set; }
        public string AcName { get; set; }
        public short AcIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
