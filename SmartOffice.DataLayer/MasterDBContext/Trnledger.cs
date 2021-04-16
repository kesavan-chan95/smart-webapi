using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Trnledger
    {
        public int LedId { get; set; }
        public int Bid { get; set; }
        public int LedAcYear { get; set; }
        public DateTime LedDate { get; set; }
        public string LedVoucherType { get; set; }
        public int LedVouNo { get; set; }
        public short LedVouSno { get; set; }
        public int LedLedger1 { get; set; }
        public int LedLedger2 { get; set; }
        public decimal LedCredit { get; set; }
        public decimal LedDebit { get; set; }
        public string LedNotes { get; set; }
        public string LedRefNo { get; set; }
        public string LedDdno { get; set; }
        public string LedDddate { get; set; }
        public short LedIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
