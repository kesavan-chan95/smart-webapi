using System;
using System.Collections.Generic;
using System.Text;

namespace SmartOffice.ViewModel.EmployeeViewModel
{
  public  class MasSlotViewModel
    {
        public long SlId { get; set; }
        public int Bid { get; set; }
        public int BrId { get; set; }
        public string SlName { get; set; }
        public int SlType { get; set; }
        public string SlFacility { get; set; }
        public short SlIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string cudType { get; set; }
    }
}
