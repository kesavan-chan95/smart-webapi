using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Masbusiness
    {
        public int Bid { get; set; }
        public int UserId { get; set; }
        public string Bname { get; set; }
        public int AddId { get; set; }
        public string Bphone1 { get; set; }
        public string Bphone2 { get; set; }
        public string Bemail { get; set; }
        public string Bwebsite { get; set; }
        public string Blogo { get; set; }
        public string BweeklyHolyday { get; set; }
        public DateTime? BaccountStartDate { get; set; }
        public short Bisactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
