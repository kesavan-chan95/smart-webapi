using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Masshift
    {
        public int ShId { get; set; }
        public int Bid { get; set; }
        public string ShName { get; set; }
        public TimeSpan ShStartTime { get; set; }
        public TimeSpan ShEndTime { get; set; }
        public short ShIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
