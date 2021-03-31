using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Trnattendance
    {
        public int AttId { get; set; }
        public int Bid { get; set; }
        public DateTime? AttDate { get; set; }
        public string AttAttendance { get; set; }
        public decimal AttOthour { get; set; }
        public decimal AttOtamount { get; set; }
        public decimal AttLateFee { get; set; }
        public short AttIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
