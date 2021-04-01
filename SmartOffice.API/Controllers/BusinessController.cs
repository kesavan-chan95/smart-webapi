using Microsoft.AspNetCore.Mvc;
using SmartOffice.BusinessLayer.Services;
using SmartOffice.Models.UserModel;
using SmartOffice.ViewModel.EmployeeViewModel;
using System;
using System.Collections.Generic;

namespace SmartOffice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService businessService;
        public BusinessController(IBusinessService businessService)
            {
                this.businessService = businessService;
            }
        [HttpPost]
        [ActionName("BusinessCreation")]
        public bool BusinessCreation([FromBody] BusinessViewModel vModel)
        {
            BusinessModel uModel = null;
            try
            {
                if (vModel != null && vModel.budType != "D")
                {
                    uModel = new BusinessModel();
                    uModel.Bid = vModel.Bid;
                    uModel.UserId = vModel.UserId;
                    uModel.Bname = vModel.Bname;
                    uModel.AddId = vModel.AddId;
                    uModel.Bphone1 = vModel.Bphone1;
                    uModel.Bphone2 = vModel.Bphone2;
                    uModel.Bemail = vModel.Bemail;
                    uModel.Bwebsite = vModel.Bwebsite;
                    uModel.Blogo = vModel.Blogo;
                    uModel.BweeklyHolyday = vModel.BweeklyHolyday;
                    uModel.BaccountStartDate = vModel.BaccountStartDate;
                    uModel.Bisactive = 1;
                    if (vModel.Bid == 0)
                    {
                        uModel.CreatedBy = 1;
                        uModel.CreatedDate = DateTime.UtcNow;
                        uModel.budType = "I";
                    }
                    else
                    {
                        uModel.ModifiedBy = 1;
                        uModel.ModifiedDate = DateTime.UtcNow;
                        uModel.budType = "U";

                    }
                    return businessService.BusinessCreation(uModel, vModel.budType);
                }
                else { return businessService.BusinessCreation(uModel, vModel.budType); }
            }
            catch (Exception ex) { return false; }
        
        }
        [HttpGet]
        [ActionName("GetBusiness")]
        public BusinessViewModel GetBusiness(int bid)
        {
            BusinessViewModel businessModel = null;
            try
            {
                var model = businessService.GetBusinessById(bid);
                if (model != null)
                {
                    businessModel = new BusinessViewModel();
                    businessModel.Bid = model.Bid;
                    businessModel.UserId = model.UserId;
                    businessModel.Bname = model.Bname;
                    businessModel.Bphone1 = model.Bphone1;
                    businessModel.Bphone2 = model.Bphone2;
                    businessModel.Bemail = model.Bemail;
                    businessModel.Bwebsite = model.Bwebsite;
                    businessModel.BweeklyHolyday = model.BweeklyHolyday;
                    businessModel.BaccountStartDate = model.BaccountStartDate;
                    return businessModel;
                }
                else { return businessModel; }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        [ActionName("GetAllBusiness")]
        public List<BusinessViewModel> GetAllBusiness()
        {
            BusinessViewModel businessModel = null; List<BusinessViewModel> listModel = null;
            try
            {
                var model = businessService.GetAllBusiness();
                if (model != null)
                {
                    listModel = new List<BusinessViewModel>();
                    foreach (var value in model)
                    {
                        businessModel = new BusinessViewModel();
                        businessModel.Bid = value.Bid;
                        businessModel.UserId = value.UserId;
                        businessModel.Bname = value.Bname;
                        businessModel.Bphone1 = value.Bphone1;
                        businessModel.Bphone2 = value.Bphone2;
                        businessModel.Bemail = value.Bemail;
                        businessModel.Bwebsite = value.Bwebsite;
                        businessModel.BweeklyHolyday = value.BweeklyHolyday;
                        businessModel.BaccountStartDate = value.BaccountStartDate;
                        listModel.Add(businessModel);
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
