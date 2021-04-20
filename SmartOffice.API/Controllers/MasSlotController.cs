using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartOffice.BusinessLayer.Services;
using SmartOffice.Models.UserModel;
using SmartOffice.ViewModel.EmployeeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartOffice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MasSlotController : ControllerBase
    {
        private readonly IMasSlotService masSlotService;
        public MasSlotController(IMasSlotService masSlotService)
        {
            this.masSlotService = masSlotService;
        }
        [HttpPost]
        [ActionName("MasSlotCreation")]
        public bool MasSlotCreation([FromBody] MasSlotViewModel vModel)
        {
            MasSlotModel uModel = null;
            try
            {
                if (vModel != null && vModel.cudType != "D")
                {
                    uModel = new MasSlotModel();
                    uModel.SlId = vModel.SlId;
                    uModel.Bid = vModel.Bid;
                    uModel.BrId = vModel.BrId;
                    uModel.SlName = vModel.SlName;
                    uModel.SlType = vModel.SlType;
                    uModel.SlFacility = vModel.SlFacility;
                   
                    uModel.SlIsactive = 1;
                    if (vModel.SlIsactive == 0)
                    {
                        uModel.CreatedBy = 1;
                        uModel.CreatedDate = DateTime.UtcNow;
                    }
                    else
                    {
                        uModel.ModifiedBy = 1;
                        uModel.ModifiedDate = DateTime.UtcNow;
                    }
                    return masSlotService.MasSlotCreation(uModel, vModel.cudType);
                }

                else { return masSlotService.MasSlotCreation(uModel, vModel.cudType); }
            }
            catch (Exception ex) { return false; }
        }
        [HttpGet]
        [ActionName("GetMasSlot")]
        public MasSlotViewModel GetMasSlotById(int slId)
        {
            MasSlotViewModel masSlotModel = null;
            try
            {
                var model = masSlotService.GetMasSlotById(slId);
                if (model != null)
                {

                    masSlotModel = new MasSlotViewModel();
                    masSlotModel.SlId = model.SlId;
                    masSlotModel.Bid = model.Bid;
                    masSlotModel.BrId = model.BrId;
                    masSlotModel.SlName = model.SlName;
                    masSlotModel.SlType = model.SlType;
                    masSlotModel.SlFacility = model.SlFacility;
                    return masSlotModel;
                }
                else { return masSlotModel; }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        [HttpGet]
        [ActionName("GetAllMasSlot")]
        public List<MasSlotViewModel> GetAllMasSlot()
        {
            MasSlotViewModel masSlotModel = null; List<MasSlotViewModel> listModel = null;
            try
            {
                var model = masSlotService.GetAllMasSlot();
                if (model != null)
                {
                    listModel = new List<MasSlotViewModel>();
                    foreach (var value in model)
                    {
                        masSlotModel = new MasSlotViewModel();
                        masSlotModel.SlId = value.SlId;
                        masSlotModel.Bid = value.Bid;
                        masSlotModel.BrId = value.BrId;
                        masSlotModel.SlName = value.SlName;
                        masSlotModel.SlType = value.SlType;
                        masSlotModel.SlFacility = value.SlFacility;
                        listModel.Add(masSlotModel);
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

    }
}
