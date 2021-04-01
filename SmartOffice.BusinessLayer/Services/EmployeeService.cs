using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.Models.UserModel;
using System;
using System.Collections.Generic;

namespace SmartOffice.BusinessLayer.Services
{
    public interface IEmployeeService
    {
        public bool EmployeeCreation(EmployeeModel employeeModel, string cudType);
        EmployeeModel GetEmployeeById(int empId);
        List<EmployeeModel> GetAllEmployee();
      

    }
    public class EmployeeService : IEmployeeService
    {
        private readonly ImasemployeeRepository masemployeeRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public EmployeeService(ImasemployeeRepository masemployeeRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {
            this.masemployeeRepository = masemployeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool EmployeeCreation(EmployeeModel employeeModel, string cudType)
        {
            Masemployee tempUser = null;
            try
            {
                if (employeeModel != null && cudType != "D")
                {
                    if (employeeModel.EmpId == 0)
                    {
                        tempUser = new Masemployee();
                        tempUser.Bid = (int)employeeModel.Bid;
                        tempUser.EmpCode = employeeModel.EmpCode;
                        tempUser.EmpName = employeeModel.EmpName;
                        tempUser.EmpDepartment = employeeModel.EmpDepartment;
                        tempUser.EmpDesignation = employeeModel.EmpDesignation;
                        tempUser.EmpContactNo = employeeModel.EmpContactNo;
                        tempUser.EmpAltContactNo = employeeModel.EmpAltContactNo;
                        tempUser.EmpPermenantAddress = employeeModel.EmpPermenantAddress;
                        tempUser.EmpTempAddress = employeeModel.EmpTempAddress;
                        tempUser.EmpSalaryType = employeeModel.EmpSalaryType;
                        tempUser.EmpBasicSalary = employeeModel.EmpBasicSalary;
                        tempUser.EmpLeaveAllowdMonth = employeeModel.EmpLeaveAllowdMonth;
                        tempUser.EmpPanno = employeeModel.EmpPanno;
                        tempUser.EmpUid = employeeModel.EmpUid;
                        tempUser.EmpEmail = employeeModel.EmpEmail;
                        tempUser.EmpBankAcNo = employeeModel.EmpBankAcNo;
                        tempUser.EmpBeneficiaryName = employeeModel.EmpBeneficiaryName;
                        tempUser.EmpBankName = employeeModel.EmpBankName;
                        tempUser.EmpBankBranch = employeeModel.EmpBankBranch;
                        tempUser.EmpIfsccode = employeeModel.EmpIfsccode;
                        tempUser.EmpCurShift = employeeModel.EmpCurShift;
                        tempUser.EmpIsactive = employeeModel.EmpIsactive;
                        tempUser.CreatedBy = (int)employeeModel.CreatedBy;
                        tempUser.CreatedDate = employeeModel.CreatedDate;
                        this.masemployeeRepository.Add(tempUser);
                        unitOfWork.Commit();
                        return true;
                    }

                    else
                    {
                        var userData = this.masemployeeRepository.Get(exp => exp.EmpId == employeeModel.EmpId && exp.EmpIsactive == 1);
                        userData.EmpId = (long)employeeModel.EmpId;
                        userData.Bid = (int)employeeModel.Bid;
                        userData.EmpCode = employeeModel.EmpCode;
                        userData.EmpName = employeeModel.EmpName;
                        userData.EmpDepartment = employeeModel.EmpDepartment;
                        userData.EmpDesignation = employeeModel.EmpDesignation;
                        userData.EmpContactNo = employeeModel.EmpContactNo;
                        userData.EmpAltContactNo = employeeModel.EmpAltContactNo;
                        userData.EmpPermenantAddress = employeeModel.EmpPermenantAddress;
                        userData.EmpTempAddress = employeeModel.EmpTempAddress;
                        userData.EmpSalaryType = employeeModel.EmpSalaryType;
                        userData.EmpBasicSalary = employeeModel.EmpBasicSalary;
                        userData.EmpLeaveAllowdMonth = employeeModel.EmpLeaveAllowdMonth;
                        userData.EmpPanno = employeeModel.EmpPanno;
                        userData.EmpUid = employeeModel.EmpUid;
                        userData.EmpBankAcNo = employeeModel.EmpBankAcNo;
                        userData.EmpBeneficiaryName = employeeModel.EmpBeneficiaryName;
                        userData.EmpBankName = employeeModel.EmpBankName;
                        userData.EmpBankBranch = employeeModel.EmpBankBranch;
                        userData.EmpCurShift = employeeModel.EmpCurShift;
                        userData.ModifiedBy = employeeModel.ModifiedBy;
                        userData.ModifiedDate = employeeModel.ModifiedDate;
                        masemployeeRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;
                    }

                }
                else
                {
                    var userData = this.masemployeeRepository.Get(exp => exp.EmpId == employeeModel.EmpId);
                    userData.EmpIsactive = 0;
                    userData.ModifiedBy = employeeModel.ModifiedBy;
                    userData.ModifiedDate = employeeModel.ModifiedDate;
                    masemployeeRepository.Update(userData);
                    unitOfWork.Commit();
                    return true;
                }
  }
           
            catch (Exception ex) { return false; }
            // finally { tempUser = null; }//
        }
        public EmployeeModel GetEmployeeById(int empId)
        {
            EmployeeModel employeeModel = null;
            try
            {
                var model = masemployeeRepository.Get(exp => exp.EmpId == empId && exp.EmpIsactive == 1);
                employeeModel = new EmployeeModel();
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
                employeeModel.EmpCurShift = model.EmpCurShift;
                return employeeModel;
            }


            finally
            { employeeModel = null; }
        }

       

        public List<EmployeeModel> GetAllEmployee()
        {
            List<EmployeeModel> listmodel = null;
            EmployeeModel employeeModel = null;
            try
            {
                var model = masemployeeRepository.GetAll();
                if (model != null)
                {
                    listmodel = new List<EmployeeModel>();
                    foreach (var value in model)
                    {
                        employeeModel = new EmployeeModel();
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
                        employeeModel.CreatedBy = value.CreatedBy;
                        employeeModel.CreatedDate = value.CreatedDate;
                        employeeModel.EmpIsactive = value.EmpIsactive;
                        listmodel.Add(employeeModel);
                    }
                }
                return listmodel;

            }
            finally
            { employeeModel = null; listmodel = null; }

        }
    }

}

