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
       

    }
}
