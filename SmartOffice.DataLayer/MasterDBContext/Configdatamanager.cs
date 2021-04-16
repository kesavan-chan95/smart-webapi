using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Configdatamanager
    {
        public int CdId { get; set; }
        public int Bid { get; set; }
        public string CdKeyName { get; set; }
        public string CdValue { get; set; }
        public short CdIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
