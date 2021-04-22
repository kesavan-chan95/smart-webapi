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
    public class TrnSlotController : ControllerBase
    {
        private readonly ITrnSlotService trnSlotService;
        public TrnSlotController(ITrnSlotService trnSlotService)
        {
            this.trnSlotService = trnSlotService;
        }
        [HttpPost]
        [ActionName("TrnSlotCreation")]
        
        public string TrnSlotCreation([FromBody] TrnSlotViewModel vModel)
        {
            TrnSlotModel uModel = null;
            try
            {
                var validate = trnSlotService.ValidateDate(vModel.SbStartDate, vModel.SbEndDate);
                if (validate == true) { return "Alreadydateexist"; } //else { return ""; }
                else
                {
                    if (vModel != null && vModel.cudType != "D")
                    {
                        uModel = new TrnSlotModel();
                        uModel.SbId = vModel.SbId;
                        uModel.Bid = vModel.Bid;
                        uModel.BrId = vModel.BrId;
                        uModel.SlId = vModel.SlId;
                        uModel.EmpId = vModel.EmpId;
                        uModel.ShId = vModel.ShId;
                        uModel.SbStartDate = vModel.SbStartDate;
                        uModel.SbEndDate = vModel.SbEndDate;
                        uModel.SbDate = vModel.SbDate;
                        uModel.SbExtraFacility = vModel.SbExtraFacility;
                        uModel.SbIsactive = 1;
                        if (vModel.SbIsactive == 0)
                        {
                            uModel.CreatedBy = 1;
                            uModel.CreatedDate = DateTime.UtcNow;
                        }
                        else
                        {
                            uModel.ModifiedBy = 1;
                            uModel.ModifiedDate = DateTime.UtcNow;
                        }
                        return (trnSlotService.TrnSlotCreation(uModel, vModel.cudType) == true ? "InsertedSuccessfully" : "Failed");
                    }
                    else { return (trnSlotService.TrnSlotCreation(uModel, vModel.cudType) == true ? "UpdatedSuccessfully" : "Failed"); }
                }
            }
            catch (Exception ex) { return "Failed"; }
        }
        [HttpGet]
        [ActionName("GetMasSlot")]
        public TrnSlotViewModel GetTrnSlotById(int sbId)
        {
            TrnSlotViewModel trnSlotModel = null;
            try
            {
                var model = trnSlotService.GetTrnSlotById(sbId);
                if (model != null)
                {

                    trnSlotModel = new TrnSlotViewModel();
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
                else { return trnSlotModel; }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        [HttpGet]
        [ActionName("GetAllTrnSlot")]
        public List<TrnSlotViewModel> GetAllTrnSlot()
        {
            TrnSlotViewModel trnSlotModel = null; List<TrnSlotViewModel> listModel = null;
            try
            {
                var model = trnSlotService.GetAllTrnSlot();
                if (model != null)
                {
                    listModel = new List<TrnSlotViewModel>();
                    foreach (var value in model)
                    {
                        trnSlotModel = new TrnSlotViewModel();
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
