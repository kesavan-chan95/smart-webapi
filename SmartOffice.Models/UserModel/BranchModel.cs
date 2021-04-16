using System;
using System.Collections.Generic;
using System.Text;

namespace SmartOffice.Models.UserModel
{
   public class BranchModel
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
        public string cudType { get; set; }
    }
}
