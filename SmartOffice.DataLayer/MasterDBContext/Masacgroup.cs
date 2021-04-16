using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Masacgroup
    {
        public long AcgId { get; set; }
        public long Bid { get; set; }
        public int? AcgMainCode { get; set; }
        public string AcgGroupName { get; set; }
        public short AcgIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
