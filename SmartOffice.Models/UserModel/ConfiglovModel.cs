using System;
using System.Collections.Generic;
using System.Text;

namespace SmartOffice.Models.UserModel
{
    public class ConfiglovModel
    {
        public int ClId { get; set; }
        public int Bid { get; set; }
        public string ClLovtype { get; set; }
        public string ClLovcode { get; set; }
        public string ClLovname { get; set; }
        public short ClIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string cudType { get; set; }
    }
}
