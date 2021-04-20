using System;
using System.Collections.Generic;
using System.Text;

namespace SmartOffice.ViewModel.EmployeeViewModel
{
   public class AddressViewModel
    {
        public long AddId { get; set; }
        public long AddUserId { get; set; }
        public int AddUserTypeId { get; set; }
        public int AddAddressType { get; set; }
        public string AddDoorNo { get; set; }
        public string AddStreetName { get; set; }
        public string AddArea { get; set; }
        public string AddCity { get; set; }
        public string AddLandmark { get; set; }
        public string AddPin { get; set; }
        public float? AddLatitude { get; set; }
        public float? AddLongitude { get; set; }
        public short? AddIsPrimary { get; set; }
        public short AddIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string cudType { get; set; }
    }
}
