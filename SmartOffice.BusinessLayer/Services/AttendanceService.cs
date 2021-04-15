/*using System;
using System.Collections.Generic;
using SmartOffice.Models.UserModel;
using System.Text;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.DataLayer.MasterDBContext;

namespace SmartOffice.BusinessLayer.Services
{

    public interface IAttendanceServices
    {
        public bool AttendanceCreation(AttendanceModel attendanceModel, string budType);
        AttendanceModel GetBusinessById(int bid);
        List<AttendanceModel> GetAllBusiness();
    }
    public class AttendanceService :IAttendanceServices
    {
        private readonly ItrnattendanceRepository trnattendanceRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public AttendanceService(ItrnattendanceRepository trnattendanceRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {
            this.trnattendanceRepository = trnattendanceRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool AttendanceCreation(AttendanceModel attendanceModel, string budType)
        {
            Trnattendance tempUser = null;
            try
            {
                if (attendanceModel != null && budType != "D")
                {
                    if (attendanceModel.AttId == 0)
                    {
                        tempUser = new Trnattendance();
                        tempUser.Bid = attendanceModel.Bid;
                        tempUser.AttDate = attendanceModel.AttDate;
                        tempUser.AttAttendance = attendanceModel.AttAttendance;
                        tempUser.AttOthour = attendanceModel.AttOthour;
                        tempUser.AttOtamount = attendanceModel.AttOtamount;
                        tempUser.AttLateFee = attendanceModel.AttLateFee;
                        tempUser.AttIsactive = attendanceModel.AttIsactive;
                        tempUser.CreatedBy = attendanceModel.CreatedBy;
                        tempUser.CreatedDate = attendanceModel.CreatedDate;
                        this.trnattendanceRepository.Add(tempUser);
                        unitOfWork.Commit();
                        return true;
                    }
                    else
                    {
                        var userData = this.trnattendanceRepository.Get(exp => exp.AttId == attendanceModel.AttId && exp.Bisactive == 1);
                      
                        masbusinessRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;
                    }
                }
            }
        }
    }
}
*/