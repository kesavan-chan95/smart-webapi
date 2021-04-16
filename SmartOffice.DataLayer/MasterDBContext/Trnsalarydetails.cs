using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Trnsalarydetails
    {
        public long TsdId { get; set; }
        public long TsId { get; set; }
        public int SgId { get; set; }
        public decimal TsdAmount { get; set; }
        public string TsdDescription { get; set; }
        public short TsdIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
