using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.Models.UserModel;
using System;
using System.Collections.Generic;

namespace SmartOffice.BusinessLayer.Services
{
    public interface ITrnSlotService
    {

      
        bool TrnSlotCreation(TrnSlotModel trnSlotModel, string type);
        bool ValidateDate(DateTime SbStartDate, DateTime SbEndDate);
        TrnSlotModel GetTrnSlotById(int sbId);
        List<TrnSlotModel> GetAllTrnSlot();
    }

    public class TrnSlotService : ITrnSlotService
    {
        private readonly ItrnslotbookingRepository trnslotbookingRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public TrnSlotService(ItrnslotbookingRepository trnslotbookingRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {
            this.trnslotbookingRepository = trnslotbookingRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool ValidateDate(DateTime SbStartDate, DateTime SbEndDate)
        {
            var validateDate = trnslotbookingRepository.Get(exp => exp.SbIsactive == 1 && exp.SbStartDate <= SbStartDate && exp.SbEndDate >= SbEndDate);
            if (validateDate != null) { return true; } else { return false; };
        }

       

        public bool TrnSlotCreation(TrnSlotModel trnSlotModel, string type)
        {
            Trnslotbooking tempUser = null;
            try
            {
                if (trnSlotModel != null && type != "D")
                {
                    if (trnSlotModel.SbId == 0)
                    {
                        tempUser = new Trnslotbooking();
                        tempUser.Bid = trnSlotModel.Bid;
                        tempUser.BrId = trnSlotModel.BrId;
                        tempUser.SlId = trnSlotModel.SlId;
                        tempUser.EmpId = trnSlotModel.EmpId;
                        tempUser.ShId = trnSlotModel.ShId;
                        tempUser.SbStartDate = trnSlotModel.SbStartDate;
                        tempUser.SbEndDate = trnSlotModel.SbEndDate;
                        tempUser.SbDate = trnSlotModel.SbDate;
                        tempUser.SbExtraFacility = trnSlotModel.SbExtraFacility;
                        tempUser.SbIsactive = trnSlotModel.SbIsactive;
                        tempUser.CreatedBy = trnSlotModel.CreatedBy;
                        tempUser.CreatedDate = trnSlotModel.CreatedDate;
                        this.trnslotbookingRepository.Add(tempUser);
                        unitOfWork.Commit();
                        return true;
                    }
                    else
                    {
                        var userData = this.trnslotbookingRepository.Get(exp => exp.SbId == trnSlotModel.SbId && exp.SbIsactive == 1);
                        userData.SbId = trnSlotModel.SbId;
                        userData.Bid = trnSlotModel.Bid;
                        userData.BrId = trnSlotModel.BrId;
                        userData.SlId = trnSlotModel.SlId;
                        userData.EmpId = trnSlotModel.EmpId;
                        userData.ShId = trnSlotModel.ShId;
                        userData.SbStartDate = trnSlotModel.SbStartDate;
                        userData.SbEndDate = trnSlotModel.SbEndDate;
                        userData.SbDate = trnSlotModel.SbDate;
                        userData.SbExtraFacility = trnSlotModel.SbExtraFacility;
                        userData.SbIsactive = trnSlotModel.SbIsactive;
                        userData.ModifiedBy = trnSlotModel.ModifiedBy;
                        userData.ModifiedDate = trnSlotModel.ModifiedDate;
                        trnslotbookingRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;
                    }
                }
                else
                {
                    var userData = this.trnslotbookingRepository.Get(exp => exp.SbId == trnSlotModel.SbId);
                    userData.SbIsactive = 0;
                    userData.ModifiedBy = trnSlotModel.ModifiedBy;
                    userData.ModifiedDate = trnSlotModel.ModifiedDate;
                    trnslotbookingRepository.Update(userData);
                    unitOfWork.Commit();
                    return true;
                }
            }
            finally { tempUser = null; }
        }

        public TrnSlotModel GetTrnSlotById(int sbId)
        {
            TrnSlotModel trnSlotModel = null;
            try
            {
                var model = trnslotbookingRepository.Get(exp => exp.SbId == sbId && exp.SbIsactive == 1);
                trnSlotModel = new TrnSlotModel();
                model.SbId = trnSlotModel.SbId;
                model.Bid = trnSlotModel.Bid;
                model.BrId = trnSlotModel.BrId;
                model.SlId = trnSlotModel.SlId;
                model.EmpId = trnSlotModel.EmpId;
                model.ShId = trnSlotModel.ShId;
                model.SbStartDate = trnSlotModel.SbStartDate;
                model.SbEndDate = trnSlotModel.SbEndDate;
                model.SbDate = trnSlotModel.SbDate;
                model.SbExtraFacility = trnSlotModel.SbExtraFacility;
                return trnSlotModel;
            }
            finally
            { trnSlotModel = null; }
        }
        public List<TrnSlotModel> GetAllTrnSlot()
        {
            List<TrnSlotModel> listModel = null;
            TrnSlotModel trnSlotModel = null;
            try
            {
                var model = trnslotbookingRepository.GetAll();
                if (model != null)
                {

                    listModel = new List<TrnSlotModel>();
                    foreach (var value in model)
                    {
                        trnSlotModel = new TrnSlotModel();
                        value.SbId = trnSlotModel.SbId;
                        value.Bid = trnSlotModel.Bid;
                        value.BrId = trnSlotModel.BrId;
                        value.SlId = trnSlotModel.SlId;
                        value.EmpId = trnSlotModel.EmpId;
                        value.ShId = trnSlotModel.ShId;
                        value.SbStartDate = trnSlotModel.SbStartDate;
                        value.SbEndDate = trnSlotModel.SbEndDate;
                        value.SbDate = trnSlotModel.SbDate;
                        value.SbExtraFacility = trnSlotModel.SbExtraFacility;

                        listModel.Add(trnSlotModel);
                    }
                }
                return listModel;
            }
            finally
            { trnSlotModel = null; listModel = null; }
        }

    }
}
