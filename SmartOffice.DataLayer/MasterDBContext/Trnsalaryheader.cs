using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Trnsalaryheader
    {
        public int TsId { get; set; }
        public int Bid { get; set; }
        public long EmpId { get; set; }
        public string TsMonthYear { get; set; }
        public DateTime TsStartDate { get; set; }
        public DateTime TsEndDate { get; set; }
        public short TsTotalWorkingDays { get; set; }
        public short TsTotalLeaveDays { get; set; }
        public short TsLop { get; set; }
        public short TsLeaveAvail { get; set; }
        public decimal TsGrossSalary { get; set; }
        public decimal TsDeduction { get; set; }
        public decimal TsNetSalary { get; set; }
        public DateTime TsPaidDate { get; set; }
        public string TsPayMode { get; set; }
        public short TsIsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
