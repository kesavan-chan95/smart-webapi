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
    public class ConfiglovController : ControllerBase
    {
        private readonly IConfiglovService configlovService;
        public ConfiglovController(IConfiglovService configlovService)
            {
                this.configlovService = configlovService;
            }
        [HttpPost]
        [ActionName("ConfigLovCreation")]
        public bool ConfigLovCreation([FromBody] ConfiglovViewModel vModel)
        {
            ConfiglovModel uModel = null;
            try
            {
                if (vModel != null && vModel.cudType != "D")
                {
                    uModel = new ConfiglovModel();

                  
                    uModel.Bid = vModel.Bid;
                    uModel.ClLovtype = vModel.ClLovtype;
                    
                    
                    uModel.ClIsactive = 1;
                    if (vModel.Bid == 0)
                    {
                        uModel.CreatedBy = 1;
                        uModel.CreatedDate = DateTime.UtcNow;
                        uModel.cudType = "I";
                    }
                    else
                    {
                        uModel.ModifiedBy = 1;
                        uModel.ModifiedDate = DateTime.UtcNow;
                        uModel.cudType = "U";

                    }
                    return configlovService.ConfigLovCreation(uModel, vModel.cudType);
                }
                else { return configlovService.ConfigLovCreation(uModel, vModel.cudType); }
            }
            catch (Exception ex) { return false; }
        
        }

        [HttpGet]
        [ActionName("GetConfigLov")]

        public ConfiglovViewModel GetConfig(int Bid)
        {
            ConfiglovViewModel configlovModel = null;
            try
            {
                var model = configlovService.GetConfigById(Bid);
                if (model != null)
                {
                    configlovModel = new ConfiglovViewModel();
                    configlovModel.Bid = model.Bid;
                    configlovModel.ClLovtype = model.ClLovtype;
                    
                   
                    return configlovModel;
                }
                else { return configlovModel; }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        [HttpGet]
        [ActionName("GetAllConfigLov")]
        public List<ConfiglovViewModel> GetAllConfigLov()
        {
            ConfiglovViewModel configModel = null; List<ConfiglovViewModel> listModel = null;
            try
            {
                var model = configlovService.GetAllConfigLov();
                if (model != null)
                {
                    listModel = new List<ConfiglovViewModel>();
                    foreach (var value in model)
                    {
                        configModel = new ConfiglovViewModel();
                        configModel.Bid = value.Bid;
                        configModel.ClLovtype = value.ClLovtype;
                       
                        listModel.Add(configModel);
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
