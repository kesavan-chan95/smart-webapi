using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Masuser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmailId { get; set; }
        public string UserMobile { get; set; }
        public string UserLoginId { get; set; }
        public string UserPassword { get; set; }
        public short UserSubscription { get; set; }
        public short UserIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
