using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.Models.UserModel;
using System;
using System.Collections.Generic;

namespace SmartOffice.BusinessLayer.Services
{

    public interface IConfiglovService
    {
        public bool ConfigLovCreation(ConfiglovModel configlovModel, string cudType);
      

    }
    public class ConfiglovService : IConfiglovService
    {

        private readonly IconfiglovRepository lovRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public ConfiglovService(IconfiglovRepository lovRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {

            this.lovRepository = lovRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool ConfigLovCreation(ConfiglovModel configlovModel, string cudType)
        {
            Configlov tempUser = null;
            try
            {
                if (configlovModel != null && cudType != "D")
                {
                    if (configlovModel.Bid == 0)
                    {
                        tempUser = new Configlov();
                       
                       
                        tempUser.ClLovtype = configlovModel.ClLovtype;
                       
                        tempUser.ClIsactive = configlovModel.ClIsactive;
                        tempUser.CreatedBy = configlovModel.CreatedBy;
                        tempUser.CreatedDate = configlovModel.CreatedDate;
                        this.lovRepository.Add(tempUser);
                        unitOfWork.Commit();
                        return true;
                    }
                    else
                    {
                        var userData = this.lovRepository.Get(exp => exp.Bid == configlovModel.Bid && exp.ClIsactive == 1);
                        
                        userData.Bid = configlovModel.Bid;
                        userData.ClLovtype = configlovModel.ClLovtype;
                        
                        userData.ClIsactive = configlovModel.ClIsactive;
                        userData.ModifiedBy = configlovModel.ModifiedBy;
                        userData.ModifiedDate = configlovModel.ModifiedDate;
                        lovRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;

                    }

                }
                else
                {
                    var userData = this.lovRepository.Get(exp => exp.Bid == configlovModel.Bid);
                    userData.ClIsactive = 0;
                    userData.ModifiedBy = configlovModel.ModifiedBy;
                    userData.ModifiedDate = configlovModel.ModifiedDate;
                    lovRepository.Update(userData);
                    unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }

       
       
    }
}