using System;

namespace SmartOffice.Models.UserModel
{
    public class EmployeeModel
    {
        public long? EmpId { get; set; }
        public int? Bid { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public int EmpDepartment { get; set; }
        public int EmpDesignation { get; set; }
        public string EmpContactNo { get; set; }
        public string EmpAltContactNo { get; set; }
        public string EmpEmail { get; set; }
        public long EmpPermenantAddress { get; set; }
        public long EmpTempAddress { get; set; }
        public string EmpSalaryType { get; set; }
        public decimal EmpBasicSalary { get; set; }
        public decimal EmpLeaveAllowdMonth { get; set; }
        public string EmpPanno { get; set; }
        public string EmpUid { get; set; }
        public string EmpBankAcNo { get; set; }
        public string EmpBeneficiaryName { get; set; }
        public string EmpBankName { get; set; }
        public string EmpBankBranch { get; set; }
        public string EmpIfsccode { get; set; }
        public int EmpCurShift { get; set; }
        public short EmpIsactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string cudType { get; set; }


    }


    public class KeyValueModel
    {
        public int keyId { get; set; }
        public string keyName { get; set; }
    }
}
