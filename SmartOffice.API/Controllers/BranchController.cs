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
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branchService;
        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }
        [HttpPost]
        [ActionName("BranchCreation")]
        public bool BranchCreation([FromBody] BranchViewModel vModel)
        {
            BranchModel uModel = null;
            try
            {
                if (vModel != null && vModel.cudType != "D")
                {
                    uModel = new BranchModel();
                    uModel.BrId = vModel.BrId;
                    uModel.Bid = vModel.Bid;
                    uModel.BrName = vModel.BrName;
                    uModel.BrAddressId = vModel.BrAddressId;
                    uModel.BrContactNo = vModel.BrContactNo;
                    uModel.BrEmailId = vModel.BrEmailId;
                    uModel.BrManagerId = vModel.BrManagerId;
                    uModel.BrIsactive = 1;
                    if (vModel.BrId == 0)
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
                    return branchService.BranchCreation(uModel, vModel.cudType);
                }
                else { return branchService.BranchCreation(uModel, vModel.cudType); }
            }
            catch (Exception ex) { return false; }
        }
    }
}
