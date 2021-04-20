using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.Models.UserModel;
using System.Collections.Generic;

namespace SmartOffice.BusinessLayer.Services
{
    public interface IMasSlotService
    {
        bool MasSlotCreation(MasSlotModel masSlotModel, string type);
        MasSlotModel GetMasSlotById(int slId);
        List<MasSlotModel> GetAllMasSlot();
    }

    public class MasSlotService : IMasSlotService
    {
        private readonly ImasslotRepository masslotRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public MasSlotService(ImasslotRepository masslotRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {
            this.masslotRepository = masslotRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool MasSlotCreation(MasSlotModel masSlotModel, string type)
        {
            Masslot tempUser = null;
            try
            {
                if (masSlotModel != null && type != "D")
                {
                    if (masSlotModel.SlId == 0)
                    {
                        tempUser = new Masslot();
                        tempUser.Bid = masSlotModel.Bid;
                        tempUser.BrId = masSlotModel.BrId;
                        tempUser.SlName = masSlotModel.SlName;
                        tempUser.SlType = masSlotModel.SlType;
                        tempUser.SlFacility = masSlotModel.SlFacility;
                        tempUser.SlIsactive = masSlotModel.SlIsactive;
                        tempUser.CreatedBy = masSlotModel.CreatedBy;
                        tempUser.CreatedDate = masSlotModel.CreatedDate;
                        this.masslotRepository.Add(tempUser);
                        unitOfWork.Commit();
                        return true;
                    }
                    else
                    {
                        var userData = this.masslotRepository.Get(exp => exp.SlId == masSlotModel.SlId && exp.SlIsactive == 1);
                        userData.SlId = masSlotModel.SlId;
                        userData.Bid = masSlotModel.Bid;
                        userData.BrId = masSlotModel.BrId;
                        userData.SlName = masSlotModel.SlName;
                        userData.SlType = masSlotModel.SlType;
                        userData.SlFacility = masSlotModel.SlFacility;
                        userData.SlIsactive = masSlotModel.SlIsactive;
                        userData.ModifiedBy = masSlotModel.ModifiedBy;
                        userData.ModifiedDate = masSlotModel.ModifiedDate;
                        masslotRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;
                    }
                }
                else
                {
                    var userData = this.masslotRepository.Get(exp => exp.SlId == masSlotModel.SlId);
                    userData.SlIsactive = 0;
                    userData.ModifiedBy = masSlotModel.ModifiedBy;
                    userData.ModifiedDate = masSlotModel.ModifiedDate;
                    masslotRepository.Update(userData);
                    unitOfWork.Commit();
                    return true;
                }
            }
            finally { tempUser = null; }
        }

        public MasSlotModel GetMasSlotById(int slId)
        {
            MasSlotModel masSlotModel = null;
            try
            {
                var model = masslotRepository.Get(exp => exp.SlId == slId && exp.SlIsactive == 1);
                masSlotModel = new MasSlotModel();
                masSlotModel.SlId = model.SlId;
                masSlotModel.Bid = model.Bid;
                masSlotModel.BrId = model.BrId;
                masSlotModel.SlName = model.SlName;
                masSlotModel.SlType = model.SlType;
                masSlotModel.SlFacility = model.SlFacility;
                return masSlotModel;
            }
            finally
            { masSlotModel = null; }
        }
        public List<MasSlotModel> GetAllMasSlot()
        {
            List<MasSlotModel> listModel = null;
            MasSlotModel masSlotModel = null;
            try
            {
                var model = masslotRepository.GetAll();
                if (model != null)
                {

                    listModel = new List<MasSlotModel>();
                    foreach (var value in model)
                    {
                        masSlotModel = new MasSlotModel();
                        masSlotModel.SlId = value.SlId;
                        masSlotModel.Bid = value.Bid;
                        masSlotModel.BrId = value.BrId;
                        masSlotModel.SlName = value.SlName;
                        masSlotModel.SlType = value.SlType;
                        masSlotModel.SlFacility = value.SlFacility;
                        listModel.Add(masSlotModel);
                    }
                }
                return listModel;
            }
            finally
            { masSlotModel = null; listModel = null; }
        }

    }
}
