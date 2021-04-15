using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartOffice.BusinessLayer.Services;
using SmartOffice.Models.UserModel;
using SmartOffice.ViewModel.EmployeeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartOffice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        [ActionName("EmployeeCreation")]
        public bool EmployeeCreation([FromBody] EmployeeViewModel vModel)
        {
            EmployeeModel uModel = null;
            try
            {
                if (vModel != null && vModel.cudType != "D")
                {
                    uModel = new EmployeeModel();
                    uModel.EmpId = vModel.EmpId;
                    uModel.Bid = vModel.Bid;
                    uModel.EmpCode = vModel.EmpCode;
                    uModel.EmpName = vModel.EmpName;
                    uModel.EmpDepartment = vModel.EmpDepartment;
                    uModel.EmpDesignation = vModel.EmpDesignation;
                    uModel.EmpContactNo = vModel.EmpContactNo;
                    uModel.EmpAltContactNo = vModel.EmpAltContactNo;
                    uModel.EmpPermenantAddress = vModel.EmpPermenantAddress;
                    uModel.EmpTempAddress = vModel.EmpTempAddress;
                    uModel.EmpSalaryType = vModel.EmpSalaryType;
                    uModel.EmpBasicSalary = vModel.EmpBasicSalary;
                    uModel.EmpLeaveAllowdMonth = vModel.EmpLeaveAllowdMonth;
                    uModel.EmpPanno = vModel.EmpPanno;
                    uModel.EmpUid = vModel.EmpUid;
                    uModel.EmpBankAcNo = vModel.EmpBankAcNo;
                    uModel.EmpBeneficiaryName = vModel.EmpBeneficiaryName;
                    uModel.EmpBankName = vModel.EmpBankName;
                    uModel.EmpBankBranch = vModel.EmpBankBranch;
                    uModel.EmpIfsccode = vModel.EmpIfsccode;
                    uModel.EmpCurShift = vModel.EmpCurShift;
                    uModel.EmpEmail = vModel.EmpEmail;
                    uModel.EmpIsactive = 1;
                    if (vModel.EmpId == 0)
                    {
                        uModel.CreatedBy = 1;
                        uModel.CreatedDate = DateTime.UtcNow;
                        uModel.cudType = "I";


                    }
                    else
                    {
                        uModel.ModifiedBy = 1;
                        uModel.ModifiedDate = DateTime.UtcNow;
                        uModel.cudType = "U";

                    }


                    return employeeService.EmployeeCreation(uModel, vModel.cudType);
                }
                else { return employeeService.EmployeeCreation(uModel, vModel.cudType); }
            }
            catch (Exception ex) { return false; }
        }
        [HttpGet]
        [ActionName("GetEmployee")]
        public EmployeeViewModel GetEmployee(int empId)
        {
            EmployeeViewModel employeeModel = null;
            try
            {
                var model = employeeService.GetEmployeeById(empId);
                if (model != null)
                {
                    employeeModel = new EmployeeViewModel();
                    employeeModel.EmpId = model.EmpId;
                    employeeModel.Bid = model.Bid;
                    employeeModel.EmpCode = model.EmpCode;
                    employeeModel.EmpName = model.EmpName;
                    employeeModel.EmpDepartment = model.EmpDepartment;
                    employeeModel.EmpDesignation = model.EmpDesignation;
                    employeeModel.EmpContactNo = model.EmpContactNo;
                    employeeModel.EmpAltContactNo = model.EmpAltContactNo;
                    employeeModel.EmpPermenantAddress = model.EmpPermenantAddress;
                    employeeModel.EmpTempAddress = model.EmpTempAddress;
                    employeeModel.EmpSalaryType = model.EmpSalaryType;
                    employeeModel.EmpBasicSalary = model.EmpBasicSalary;
                    employeeModel.EmpLeaveAllowdMonth = model.EmpLeaveAllowdMonth;
                    employeeModel.EmpPanno = model.EmpPanno;
                    employeeModel.EmpUid = model.EmpUid;
                    employeeModel.EmpBankAcNo = model.EmpBankAcNo;
                    employeeModel.EmpBeneficiaryName = model.EmpBeneficiaryName;
                    employeeModel.EmpBankName = model.EmpBankName;
                    employeeModel.EmpBankBranch = model.EmpBankBranch;
                    employeeModel.EmpIfsccode = model.EmpIfsccode;
                    employeeModel.EmpCurShift = model.EmpCurShift;
                    return employeeModel;
                }
                else { return employeeModel; }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet]
        [ActionName("GetAllEmployee")]
        public List<EmployeeViewModel> GetAllEmployee()
        {
            EmployeeViewModel employeeModel = null; List<EmployeeViewModel> listModel = null;
            try
            {
                var model = employeeService.GetAllEmployee();
                if (model != null)
                {
                    listModel = new List<EmployeeViewModel>();
                    foreach (var value in model)
                    {
                        employeeModel = new EmployeeViewModel();
                        employeeModel.EmpId = value.EmpId;
                        employeeModel.Bid = (int)value.Bid;
                        employeeModel.EmpCode = value.EmpCode;
                        employeeModel.EmpName = value.EmpName;
                        employeeModel.EmpDepartment = value.EmpDepartment;
                        employeeModel.EmpDesignation = value.EmpDesignation;
                        employeeModel.EmpContactNo = value.EmpContactNo;
                        employeeModel.EmpAltContactNo = value.EmpAltContactNo;
                        employeeModel.EmpEmail = value.EmpEmail;
                        employeeModel.EmpPermenantAddress = value.EmpPermenantAddress;
                        employeeModel.EmpTempAddress = value.EmpTempAddress;
                        employeeModel.EmpSalaryType = value.EmpSalaryType;
                        employeeModel.EmpBasicSalary = value.EmpBasicSalary;
                        employeeModel.EmpLeaveAllowdMonth = value.EmpLeaveAllowdMonth;
                        employeeModel.EmpPanno = value.EmpPanno;
                        employeeModel.EmpUid = value.EmpUid;
                        employeeModel.EmpBankAcNo = value.EmpBankAcNo;
                        employeeModel.EmpBeneficiaryName = value.EmpBeneficiaryName;
                        employeeModel.EmpBankName = value.EmpBankName;
                        employeeModel.EmpBankBranch = value.EmpBankBranch;
                        employeeModel.EmpIfsccode = value.EmpIfsccode;
                        employeeModel.EmpCurShift = value.EmpCurShift;
                        listModel.Add(employeeModel);

                    }
                    return listModel;
                }
                else { return listModel; }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /*[HttpGet]
        [ActionName("GetDropdownData")]
        public DropdowData GetDropdownData()
        {
            DropdowData drpData = null;
            try
            {
                var deptModel = employeeService.GetDeparment().Select(exp => new KeyValueViewModel { keyId = exp.keyId, keyName = exp.keyName }).ToList();
                var desigModel = employeeService.GetDesignation().Select(exp => new KeyValueViewModel { keyId = exp.keyId, keyName = exp.keyName }).ToList();
                if (deptModel != null && desigModel != null)
                {
                    drpData = new DropdowData();
                    drpData.departmentList = deptModel;
                    drpData.desingationList = desigModel;
                }
                return drpData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }*/
    }
}

