using Microsoft.AspNetCore.Mvc;
using SmartOffice.BusinessLayer.Services;
using SmartOffice.ViewModel.EmployeeViewModel;
using SmartOffice.Models.UserModel;
using System;
using System.Collections.Generic;

namespace SmartOffice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
     
    public class LoginController : ControllerBase
    {

        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        [ActionName("LoginValidate")]
        public GetViewModel LoginValidate([FromBody] LoginViewModel vModel)
        {
            GetViewModel getViewModel = null;

            try 
            { 
                var model= loginService.UserAuthentication(vModel.LoginName, vModel.LoginPassword); 
                if (model != null)
                {
                    getViewModel = new GetViewModel();
                    getViewModel.UserId = model.UserId;
                    getViewModel.UserName = model.UserName;
                    getViewModel.Emproll = model.Emproll;
                    return getViewModel;
                }
                else { return getViewModel; }
            }
            catch (Exception ex) { return null; }
        }

        [HttpPost]
        [ActionName("UserCreation")]
        public bool UserCreation([FromBody] UserViewModel vModel)
        {
            UserModel uModel = null;
            try
            {
                if (vModel != null && vModel.type != "D")
                {
                    uModel = new UserModel();
                    uModel.UserId = vModel.UserId;
                    uModel.UserName = vModel.UserName;
                    uModel.UserMobile = vModel.MobileNo;
                    uModel.UserEmailId = vModel.EmailId;
                    uModel.UserLoginId = vModel.LoginName;
                    uModel.UserPassword = vModel.LoginPassword;
                    uModel.UserSubscription = 1;
                    uModel.UserIsactive = 1;
                    if (vModel.UserId == 0)
                    {
                        uModel.CreatedBy = 1;
                        uModel.CreatedDate = DateTime.UtcNow;
                    }
                    else
                    {
                        uModel.ModifiedBy = 1;
                        uModel.ModifiedDate = DateTime.UtcNow;
                    }
                    return loginService.UserCreation(uModel, vModel.type);
                }
                else { return loginService.UserCreation(uModel, vModel.type); }
            }
            catch (Exception ex) { return false; }
        }

        [HttpGet]
        [ActionName("GetUser")]
        public UserViewModel GetUser(int userId)
        {
            UserViewModel userModel = null;
            try
            {
                var model = loginService.GetUserById(userId);
                if (model != null)
                {
                    userModel = new UserViewModel();
                    userModel.UserId = model.UserId;
                    userModel.UserName = model.UserName;
                    userModel.MobileNo = model.UserMobile;
                    userModel.EmailId = model.UserEmailId;
                    userModel.LoginName = model.UserLoginId;
                    userModel.LoginPassword = model.UserPassword;
                    return userModel;
                }
                else { return userModel; }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        [HttpGet]
        [ActionName("GetAllUser")]
        public List<UserViewModel> GetAllUser()
        {
            UserViewModel userModel = null;List<UserViewModel> listModel = null;
            try
            {
                var model = loginService.GetAllUser();
                if (model != null)
                {
                    listModel = new List<UserViewModel>();
                    foreach (var value in model)
                    {
                        userModel = new UserViewModel();
                        userModel.UserId = value.UserId;
                        userModel.UserName = value.UserName;
                        userModel.MobileNo = value.UserMobile;
                        userModel.EmailId = value.UserEmailId;
                        userModel.LoginName = value.UserLoginId;
                        userModel.LoginPassword = value.UserPassword;
                        listModel.Add(userModel);
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
