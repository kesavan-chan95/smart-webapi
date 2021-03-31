using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Massalarygroup
    {
        public long SgId { get; set; }
        public int Bid { get; set; }
        public string SgName { get; set; }
        public string SgType { get; set; }
        public string SgFormula { get; set; }
        public short SgIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
