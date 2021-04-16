using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.Models.UserModel;
using System;
using System.Collections.Generic;

namespace SmartOffice.BusinessLayer.Services
{

    public interface IAttendanceServices
    {
        public bool AttendanceCreation(AttendanceModel attendanceModel, string budType);
         AttendanceModel GetAttendanceById(int attId);
         List<AttendanceModel> GetAllAttendance();
    }
    public class AttendanceService : IAttendanceServices
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
                        var userData = this.trnattendanceRepository.Get(exp => exp.AttId == attendanceModel.AttId && exp.AttIsactive == 1);
                        userData.AttId = attendanceModel.AttId;
                        userData.Bid = attendanceModel.Bid;
                        userData.AttDate = attendanceModel.AttDate;
                        userData.AttAttendance = attendanceModel.AttAttendance;
                        userData.AttOthour = attendanceModel.AttOthour;
                        userData.AttOtamount = attendanceModel.AttOtamount;
                        userData.AttLateFee = attendanceModel.AttLateFee;
                        userData.AttIsactive = attendanceModel.AttIsactive;
                        trnattendanceRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;
                    }
                }
                else
                {
                    var userData = this.trnattendanceRepository.Get(exp => exp.AttId == attendanceModel.AttId);
                    userData.AttIsactive = 0;
                    userData.ModifiedBy = attendanceModel.ModifiedBy;
                    userData.ModifiedDate = attendanceModel.ModifiedDate;
                    trnattendanceRepository.Update(userData);
                    unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        public AttendanceModel GetAttendanceById(int attId)
        {
            AttendanceModel attendanceModel = null;
            try
            {
                var model = trnattendanceRepository.Get(exp => exp.AttId == attId && exp.AttIsactive == 1);
                attendanceModel = new AttendanceModel();
                attendanceModel.AttId = model.AttId;
                attendanceModel.Bid = model.Bid;
                attendanceModel.AttDate = model.AttDate;
                attendanceModel.AttAttendance = model.AttAttendance;
                attendanceModel.AttOthour = model.AttOthour;
                attendanceModel.AttOtamount = model.AttOtamount;
                attendanceModel.AttLateFee = model.AttLateFee;
                return attendanceModel;
            }
            finally
            { attendanceModel = null; }
        }
        public List<AttendanceModel> GetAllAttendance()
        {
            List<AttendanceModel> listmodel = null;
            AttendanceModel attendanceModel = null;
            try
            {
                var model = trnattendanceRepository.GetAll();
                if (model != null)
                {
                    listmodel = new List<AttendanceModel>();
                    foreach (var value in model)
                    {
                        attendanceModel = new AttendanceModel();
                        attendanceModel.AttId = value.AttId;
                        attendanceModel.Bid = value.Bid;
                        attendanceModel.AttDate = value.AttDate;
                        attendanceModel.AttAttendance = value.AttAttendance;
                        attendanceModel.AttOthour = value.AttOthour;
                        attendanceModel.AttOtamount = value.AttOtamount;
                        attendanceModel.AttLateFee = value.AttLateFee;
                        listmodel.Add(attendanceModel);

                    }
                }
                return listmodel;
            }
            finally
            { attendanceModel = null; listmodel = null; }
        }
    }
}

