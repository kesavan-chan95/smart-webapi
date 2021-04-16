using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartOffice.BusinessLayer.Services
{
    public interface IEmployeeService
    {
        public bool EmployeeCreation(EmployeeModel employeeModel, string cudType);
        EmployeeModel GetEmployeeById(int empId);
        List<EmployeeModel> GetAllEmployee();

     //   List<KeyValueModel> GetDeparment();

      //  List<KeyValueModel> GetDesignation();

    }
    public class EmployeeService : IEmployeeService
    {
        private readonly ImasemployeeRepository masemployeeRepository;
        private readonly IconfiglovRepository configlovRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public EmployeeService(IconfiglovRepository configlovRepository, ImasemployeeRepository masemployeeRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {
            this.masemployeeRepository = masemployeeRepository;
            this.configlovRepository = configlovRepository;
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
                        tempUser.EmpDepartment = Convert.ToInt32(employeeModel.EmpDepartment);
                        tempUser.EmpDesignation = Convert.ToInt32(employeeModel.EmpDesignation);
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
                        userData.EmpDepartment = Convert.ToInt32(employeeModel.EmpDepartment);
                        userData.EmpDesignation = Convert.ToInt32(employeeModel.EmpDesignation);
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
                employeeModel.EmpDepartment = Convert.ToString(model.EmpDepartment);
                employeeModel.EmpDesignation = Convert.ToString(model.EmpDesignation);
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
            try
            {
                listmodel = new List<EmployeeModel>();
                listmodel = (from emp in masemployeeRepository.GetAll().ToList()
                             join config1 in configlovRepository.GetAll().Where(exp => exp.ClLovtype == "Department") on emp.EmpDepartment equals config1.Bid
                             /*join config2 in configlovRepository.GetAll().Where(exp => exp.ClLovtype == "") on emp.EmpDesignation equals config2.ClId*/
                             select new EmployeeModel
                             {
                                 EmpId = emp.EmpId,
                                 Bid = (int)emp.Bid,
                                 EmpCode = emp.EmpCode,
                                 EmpName = emp.EmpName,
                                 EmpDepartment = config1.ClLovname,
                                 EmpDesignation = "",
                                 EmpContactNo = emp.EmpContactNo,
                                 EmpAltContactNo = emp.EmpAltContactNo,
                                 EmpEmail = emp.EmpEmail,
                                 EmpPermenantAddress = emp.EmpPermenantAddress,
                                 EmpTempAddress = emp.EmpTempAddress,
                                 EmpSalaryType = emp.EmpSalaryType,
                                 EmpBasicSalary = emp.EmpBasicSalary,
                                 EmpLeaveAllowdMonth = emp.EmpLeaveAllowdMonth,
                                 EmpPanno = emp.EmpPanno,
                                 EmpUid = emp.EmpUid,
                                 EmpBankAcNo = emp.EmpBankAcNo,
                                 EmpBeneficiaryName = emp.EmpBeneficiaryName,
                                 EmpBankName = emp.EmpBankName,
                                 EmpBankBranch = emp.EmpBankBranch,
                                 EmpIfsccode = emp.EmpIfsccode,
                                 EmpCurShift = emp.EmpCurShift,
                                 CreatedBy = emp.CreatedBy,
                                 CreatedDate = emp.CreatedDate,
                                 EmpIsactive = emp.EmpIsactive,
                                 
            }).ToList();
                return listmodel;

            }
            finally
            { listmodel = null; }

        }

     /*   public List<KeyValueModel> GetDeparment()
        {
            return configlovRepository.GetAll().Where(exp => exp.ClLovtype == "dept").Select(exp => new KeyValueModel { keyId = exp.Bid, keyName = exp.ClLovname }).ToList();
        }

        public List<KeyValueModel> GetDesignation()
        {
            return configlovRepository.GetAll().Where(exp => exp.ClLovtype == "desig").Select(exp => new KeyValueModel { keyId = exp.Bid, keyName = exp.ClLovname }).ToList();
        }*/
    }

}

