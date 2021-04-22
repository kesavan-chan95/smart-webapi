using System;
using System.Collections.Generic;
using System.Text;

namespace SmartOffice.ViewModel.EmployeeViewModel
{
   public class TrnSlotViewModel
    {
        public int SbId { get; set; }
        public int Bid { get; set; }
        public int BrId { get; set; }
        public int SlId { get; set; }
        public long EmpId { get; set; }
        public int ShId { get; set; }
        public DateTime SbStartDate { get; set; }
        public DateTime SbEndDate { get; set; }
        public DateTime SbDate { get; set; }
        public string SbExtraFacility { get; set; }
        public short SbIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string cudType { get; set; }

    }
}
