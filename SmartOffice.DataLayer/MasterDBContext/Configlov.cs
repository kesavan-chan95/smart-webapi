using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Configlov
    {
        public int ClId { get; set; }
        public string ClLovtype { get; set; }
        public string ClLovcode { get; set; }
        public string ClLovname { get; set; }
        public short ClIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
