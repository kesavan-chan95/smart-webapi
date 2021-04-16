using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.Models.UserModel;
using System;
using System.Collections.Generic;

namespace SmartOffice.BusinessLayer.Services
{
    public interface IBusinessService
    {
        public bool BusinessCreation(BusinessModel businessModel, string budType);
        BusinessModel GetBusinessById(int bid);
        List<BusinessModel> GetAllBusiness();



    }
    public class BusinessService : IBusinessService
    {
        private readonly ImasbusinessRepository masbusinessRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public BusinessService(ImasbusinessRepository masbusinessRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {
            this.masbusinessRepository = masbusinessRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool BusinessCreation(BusinessModel businessModel, string budType)
        {
            Masbusiness tempUser = null;
            try
            {
                if (businessModel != null && budType != "D")
                {
                    if (businessModel.Bid == 0)
                    {
                        tempUser = new Masbusiness();
                        tempUser.UserId = businessModel.UserId;
                        tempUser.Bname = businessModel.Bname;
                        tempUser.AddId = businessModel.AddId;
                        tempUser.Bphone1 = businessModel.Bphone1;
                        tempUser.Bphone2 = businessModel.Bphone2;
                        tempUser.Bemail = businessModel.Bemail;
                        tempUser.Bwebsite = businessModel.Bwebsite;
                        tempUser.Blogo = businessModel.Blogo;
                        tempUser.BweeklyHolyday = businessModel.BweeklyHolyday;
                        tempUser.Bisactive = businessModel.Bisactive;
                        tempUser.CreatedBy = businessModel.CreatedBy;
                        tempUser.CreatedDate = businessModel.CreatedDate;
                        this.masbusinessRepository.Add(tempUser);
                        unitOfWork.Commit();
                        return true;

                    }
                    else
                    {
                        var userData = this.masbusinessRepository.Get(exp => exp.Bid == businessModel.Bid && exp.Bisactive == 1);
                        userData.Bid = businessModel.Bid;
                        userData.UserId = businessModel.UserId;
                        userData.Bname = businessModel.Bname;
                        userData.AddId = businessModel.AddId;
                        userData.Bphone1 = businessModel.Bphone1;
                        userData.Bphone2 = businessModel.Bphone2;
                        userData.Bemail = businessModel.Bemail;
                        userData.Bwebsite = businessModel.Bwebsite;
                        userData.Blogo = businessModel.Blogo;
                        userData.BweeklyHolyday = businessModel.BweeklyHolyday;
                        userData.BaccountStartDate = businessModel.BaccountStartDate;
                        userData.Bisactive = businessModel.Bisactive;
                        userData.ModifiedBy = businessModel.ModifiedBy;
                        userData.ModifiedDate = businessModel.ModifiedDate;
                        masbusinessRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;
                    }
                }
                else
                {
                    var userData = this.masbusinessRepository.Get(exp => exp.Bid == businessModel.Bid);
                    userData.Bisactive = 0;
                    userData.ModifiedBy = businessModel.ModifiedBy;
                    userData.ModifiedDate = businessModel.ModifiedDate;
                    masbusinessRepository.Update(userData);
                    unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        public BusinessModel GetBusinessById(int bid)
        {
            BusinessModel businessModel = null;
            try
            {
                var model = masbusinessRepository.Get(exp => exp.Bid == bid && exp.Bisactive == 1);
                businessModel = new BusinessModel();
                businessModel.Bid = model.Bid;
                businessModel.UserId = model.UserId;
                businessModel.Bname = model.Bname;
                businessModel.AddId = model.AddId;
                businessModel.Bphone1 = model.Bphone1;
                businessModel.Bphone2 = model.Bphone2;
                businessModel.Bemail = model.Bemail;
                businessModel.Bwebsite = model.Bwebsite;
                businessModel.Blogo = model.Blogo;
                businessModel.BweeklyHolyday = model.BweeklyHolyday;
                businessModel.BaccountStartDate = model.BaccountStartDate;
                return businessModel;

            }
            finally
            { businessModel = null; }
        }
        public List<BusinessModel> GetAllBusiness()
        {
            List<BusinessModel> listmodel = null;
            BusinessModel businessModel = null;
            try
            {
                var model = masbusinessRepository.GetAll();
                if (model != null)
                {
                    listmodel = new List<BusinessModel>();
                    foreach (var value in model)

                    {
                        businessModel = new BusinessModel();
                        businessModel.Bid = value.Bid;
                        businessModel.UserId = value.UserId;
                        businessModel.Bname = value.Bname;
                        businessModel.AddId = value.AddId;
                        businessModel.Bphone1 = value.Bphone1;
                        businessModel.Bphone2 = value.Bphone2;
                        businessModel.Bemail = value.Bemail;
                        businessModel.Bwebsite = value.Bwebsite;
                        businessModel.Blogo = value.Blogo;
                        businessModel.BweeklyHolyday = value.BweeklyHolyday;
                        businessModel.BaccountStartDate = value.BaccountStartDate;
                        listmodel.Add(businessModel);

                    }
                }
                return listmodel;

            }
            finally
            { businessModel = null; listmodel = null; }
        }
    }
}
