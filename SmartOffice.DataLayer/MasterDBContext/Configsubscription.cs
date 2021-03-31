using System;
using System.Collections.Generic;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class Configsubscription
    {
        public int CsId { get; set; }
        public string CsName { get; set; }
        public decimal CsValue { get; set; }
        public int CsValidity { get; set; }
        public int CsEmpLimit { get; set; }
        public short CsBusinessLimit { get; set; }
        public int CsTansactionLimit { get; set; }
        public string ClLovname { get; set; }
        public short CsIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
