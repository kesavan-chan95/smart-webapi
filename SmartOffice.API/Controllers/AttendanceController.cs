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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceServices attendanceService;
        public AttendanceController(IAttendanceServices attendanceService)
        {
            this.attendanceService = attendanceService;
        }
        [HttpPost]
        [ActionName("AttendanceCreation")]
        public bool AttendanceCreation([FromBody] AttendanceViewModel vModel)
        {
             AttendanceModel uModel = null;
            try
            {
                if (vModel != null && vModel.budType != "D")
                {
                    uModel = new AttendanceModel();
                    uModel.AttId = vModel.AttId;
                    uModel.Bid = vModel.Bid;
                    uModel.AttDate = vModel.AttDate;
                    uModel.AttAttendance = vModel.AttAttendance;
                    uModel.AttOthour = vModel.AttOthour;
                    uModel.AttOtamount = vModel.AttOtamount;
                    uModel.AttLateFee = vModel.AttLateFee;
                    uModel.AttIsactive = 1;
                    if (vModel.AttId == 0)
                    {
                        uModel.AttDate = DateTime.UtcNow;
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
                    return attendanceService.AttendanceCreation(uModel, vModel.budType);
                }
                else { return attendanceService.AttendanceCreation(uModel, vModel.budType); }
            }
            catch (Exception ex) { return false; }
        }
        [HttpGet]
        [ActionName ("GetAttendanceById")]
        public AttendanceViewModel GetAttendanceById(int attId)
        {
            AttendanceViewModel attendanceModel = null;
            try
            {
                var model = attendanceService.GetAttendanceById(attId);
                if (model != null)
                {
                    attendanceModel = new AttendanceViewModel();
                    attendanceModel.AttId = model.AttId;
                    attendanceModel.Bid = model.Bid;
                    attendanceModel.AttDate = model.AttDate;
                    attendanceModel.AttAttendance = model.AttAttendance;
                    attendanceModel.AttOthour = model.AttOthour;
                    attendanceModel.AttOtamount = model.AttOtamount;
                    attendanceModel.AttLateFee = model.AttLateFee;
                    return attendanceModel;
                }
                else { return attendanceModel; }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        [ActionName("GetAllAttendance")]
        public List<AttendanceViewModel> GetAllAttendance()
        {
            AttendanceViewModel attendanceModel = null; 
            List<AttendanceViewModel> listModel = null;
            try
            {
                var model = attendanceService.GetAllAttendance();
                if (model != null)
                {
                    listModel = new List<AttendanceViewModel>();
                    foreach (var value in model)
                    {
                        attendanceModel = new AttendanceViewModel();
                        attendanceModel.AttId = value.AttId;
                        attendanceModel.Bid = value.Bid;
                        attendanceModel.AttDate = value.AttDate;
                        attendanceModel.AttAttendance = value.AttAttendance;
                        attendanceModel.AttOthour = value.AttOthour;
                        attendanceModel.AttOtamount = value.AttOtamount;
                        attendanceModel.AttLateFee = value.AttLateFee;
                        listModel.Add(attendanceModel);
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
