using System.Collections.Generic;

namespace SmartOffice.ViewModel.EmployeeViewModel
{
    public class EmployeeViewModel
    {
        public long? EmpId { get; set; }
        public int? Bid { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string EmpDepartment { get; set; }
        public string EmpDesignation { get; set; }
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
        public string cudType { get; set; }


    }

    public class KeyValueViewModel
    {
        public int keyId { get; set; }
        public string keyName { get; set; }
    }

    public class DropdowData
    {
        public List<KeyValueViewModel> departmentList { get; set; }
        public List<KeyValueViewModel> desingationList { get; set; }

    }
}


