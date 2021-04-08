
using SmartOffice.DataLayer.Repositories;
using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Text;
using SmartOffice.Infrastructure.Infrastructure;

namespace SmartOffice.BusinessLayer.Services
{

    public interface ILoginService
    {
        GetModel UserAuthentication(string loginName, string loginPassword);
        bool UserCreation(UserModel userModel, string type);

        UserModel GetUserById(int userId);

        List<UserModel> GetAllUser();


    }
    public class LoginService : ILoginService
    {
        private readonly ImasuserRepository masuserRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public LoginService(ImasuserRepository masuserRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {
            this.masuserRepository = masuserRepository;
            this.unitOfWork = unitOfWork;
        }

        public GetModel UserAuthentication(string loginName, string loginPassword)
        {
          GetModel getmodel = null;
            try 
            {
                var userList = masuserRepository.Get(exp => exp.UserLoginId == loginName && exp.UserPassword == loginPassword);
                getmodel = new GetModel();
                getmodel.UserId = userList.UserId;
                getmodel.UserName = userList.UserName;
                getmodel.Emproll = "Admin";
                return getmodel;
            }
            finally
            { getmodel = null; }
    }
        public bool UserCreation(UserModel userModel, string type)
        {
            Masuser tempUser = null;
            try
            {
                if (userModel != null && type != "D")
                {
                    if (userModel.UserId == 0)
                    {
                        tempUser = new Masuser();
                        tempUser.UserName = userModel.UserName;
                        tempUser.UserMobile = userModel.UserMobile;
                        tempUser.UserEmailId = userModel.UserEmailId;
                        tempUser.UserLoginId = userModel.UserLoginId;
                        tempUser.UserPassword = userModel.UserPassword;
                        tempUser.UserSubscription = userModel.UserSubscription;
                        tempUser.UserIsactive = userModel.UserIsactive;
                        tempUser.CreatedBy = userModel.CreatedBy;
                        tempUser.CreatedDate = userModel.CreatedDate;
                        this.masuserRepository.Add(tempUser);
                        unitOfWork.Commit();
                        return true;
                    }
                    else
                    {
                        var userData = this.masuserRepository.Get(exp => exp.UserId == userModel.UserId && exp.UserIsactive == 1);
                        userData.UserName = userModel.UserName;
                        userData.UserMobile = userModel.UserMobile;
                        userData.UserEmailId = userModel.UserEmailId;
                        userData.UserLoginId = userModel.UserLoginId;
                        userData.UserPassword = userModel.UserPassword;
                        userData.UserSubscription = userModel.UserSubscription;
                        userData.ModifiedBy = userModel.ModifiedBy;
                        userData.ModifiedDate = userModel.ModifiedDate;
                        masuserRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;
                    }
                }
                else
                {
                    var userData = this.masuserRepository.Get(exp => exp.UserId == userModel.UserId);
                    userData.UserIsactive = 0;
                    userData.ModifiedBy = userModel.ModifiedBy;
                    userData.ModifiedDate = userModel.ModifiedDate;
                    masuserRepository.Update(userData);
                    unitOfWork.Commit();
                    return true;
                }
            }
            finally { tempUser = null; }
        }

        public UserModel GetUserById(int userId)
        {
            UserModel userModel = null;
            try
            {
                var model = masuserRepository.Get(exp => exp.UserId == userId && exp.UserIsactive == 1);
                userModel = new UserModel();
                userModel.UserId = model.UserId;
                userModel.UserId = model.UserId;
                userModel.UserName = model.UserName;
                userModel.UserMobile = model.UserMobile;
                userModel.UserEmailId = model.UserEmailId;
                userModel.UserLoginId = model.UserLoginId;
                userModel.UserPassword = model.UserPassword;
                userModel.UserSubscription = 1;
                return userModel;
            }
            finally
            { userModel = null; }
        }

        public List<UserModel> GetAllUser()
        {
            List<UserModel> listModel = null;
            UserModel userModel = null;
            try
            {
                var model = masuserRepository.GetAll();
                if (model != null)
                {
                    listModel = new List<UserModel>();
                    foreach (var value in model)
                    {
                        userModel = new UserModel();
                        userModel.UserId = value.UserId;
                        userModel.UserName = value.UserName;
                        userModel.UserMobile = value.UserMobile;
                        userModel.UserEmailId = value.UserEmailId;
                        userModel.UserLoginId = value.UserLoginId;
                        userModel.UserPassword = value.UserPassword;
                        userModel.UserSubscription = 1;
                        listModel.Add(userModel);
                    }
                }
                return listModel;
            }
            finally
            { userModel = null; listModel = null; }
        }
    }
}