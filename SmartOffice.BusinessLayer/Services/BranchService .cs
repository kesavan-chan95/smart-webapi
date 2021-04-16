using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.Models.UserModel;
using System;
using System.Collections.Generic;

namespace SmartOffice.BusinessLayer.Services
{
    public interface IBranchService
    {
        public bool BranchCreation(BranchModel branchModel, string cudType);
    }
      public  class BranchService :IBranchService
    {
        private readonly ImasbranchRepository masbranchRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public BranchService(ImasbranchRepository masbranchRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {
            this.masbranchRepository = masbranchRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool BranchCreation(BranchModel branchModel, string cudType)
        {
            Masbranch tempUser = null;
            try
            {
                if (branchModel != null && cudType != "D")
                {
                    if (branchModel.BrId == 0)
                    {
                        tempUser = new Masbranch();
                        tempUser.Bid = branchModel.Bid;
                        tempUser.BrName = branchModel.BrName;
                        tempUser.BrAddressId = branchModel.BrAddressId;
                        tempUser.BrContactNo = branchModel.BrContactNo;
                        tempUser.BrEmailId = branchModel.BrEmailId;
                        tempUser.BrManagerId = branchModel.BrManagerId;
                        tempUser.BrIsactive = branchModel.BrIsactive;
                        tempUser.CreatedDate = branchModel.CreatedDate;
                        tempUser.CreatedBy = branchModel.CreatedBy;
                        this.masbranchRepository.Add(tempUser);
                        unitOfWork.Commit();
                        return true;

                    }
                    else
                    {
                        var userData = this.masbranchRepository.Get(exp => exp.BrId == branchModel.BrId && exp.BrIsactive == 1);
                        userData.BrId = branchModel.BrId;
                        userData.Bid = branchModel.Bid;
                        userData.BrName = branchModel.BrName;
                        userData.BrAddressId = branchModel.BrAddressId;
                        userData.BrContactNo = branchModel.BrContactNo;
                        userData.BrEmailId = branchModel.BrEmailId;
                        userData.BrManagerId = branchModel.BrManagerId;
                        userData.BrIsactive = branchModel.BrIsactive;
                        userData.ModifiedDate = branchModel.ModifiedDate;
                        userData.ModifiedBy = branchModel.ModifiedBy;
                        masbranchRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;
                    }
                }
                else
                {
                    var userData = this.masbranchRepository.Get(exp => exp.Bid == branchModel.Bid);
                    userData.BrIsactive = 0;
                    userData.ModifiedBy = branchModel.ModifiedBy;
                    userData.ModifiedDate = branchModel.ModifiedDate;
                    masbranchRepository.Update(userData);
                    unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
