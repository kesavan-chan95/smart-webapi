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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;
        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpPost]
        [ActionName("AddressCreation")]
        public bool AddressCreation([FromBody] AddressViewModel vModel)
        {
            AddressModel uModel = null;
            try
            {
                if (vModel != null && vModel.cudType != "D")
                {
                    uModel = new AddressModel();
                    uModel.AddId = vModel.AddId;
                    uModel.AddUserId = vModel.AddUserId;
                    uModel.AddUserTypeId = vModel.AddUserTypeId;
                    uModel.AddAddressType = vModel.AddAddressType;
                    uModel.AddDoorNo = vModel.AddDoorNo;
                    uModel.AddStreetName = vModel.AddStreetName;
                    uModel.AddArea = vModel.AddArea;
                    uModel.AddCity = vModel.AddCity;
                    uModel.AddLandmark = vModel.AddLandmark;
                    uModel.AddPin = vModel.AddPin;
                    uModel.AddLatitude = vModel.AddLatitude;
                    uModel.AddLongitude = vModel.AddLongitude;
                    uModel.AddIsactive = 1;
                    if (vModel.AddId == 0)
                    {
                        uModel.CreatedBy = 1;
                        uModel.CreatedDate = DateTime.UtcNow;
                    }
                    else
                    {
                        uModel.ModifiedBy = 1;
                        uModel.ModifiedDate = DateTime.UtcNow;
                    }
                    return addressService.AddressCreation(uModel, vModel.cudType);

                }
                else { return addressService.AddressCreation(uModel, vModel.cudType); }
                
            }
            catch (Exception ex) { return false; }
        }
        [HttpGet]
        [ActionName("GetUser")]
        public AddressViewModel GetAddressById(int addUserId, int addUserTypeId)
        {
            AddressViewModel addressModel = null;
            try
            {
                var model = addressService.GetAddressById(addUserId,  addUserTypeId);
                if (model != null)
                {
                    
                    addressModel = new AddressViewModel();
                    addressModel.AddId = model.AddId;
                    addressModel.AddUserId = model.AddUserId;
                    addressModel.AddUserTypeId = model.AddUserTypeId;
                    addressModel.AddAddressType = model.AddAddressType;
                    addressModel.AddDoorNo = model.AddDoorNo;
                    addressModel.AddStreetName = model.AddStreetName;
                    addressModel.AddArea = model.AddArea;
                    addressModel.AddCity = model.AddCity;
                    addressModel.AddLandmark = model.AddLandmark;
                    addressModel.AddPin = model.AddPin;
                    addressModel.AddLatitude = model.AddLatitude;
                    addressModel.AddLongitude = model.AddLongitude;
                    return addressModel;
                }
                else { return addressModel; }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        /*[HttpGet]
        [ActionName("GetAllAddress")]
        public List<AddressViewModel> GetAllAddress()
        {
            AddressViewModel addressModel = null; List<AddressViewModel> listModel = null;
            try
            {
                var model = addressService.GetAllAddress();
                if (model != null)
                {
                    listModel = new List<AddressViewModel>();
                    foreach (var value in model)
                    {
                        addressModel = new AddressViewModel();
                        addressModel.AddId = value.AddId;
                        addressModel.AddUserId = value.AddUserId;
                        addressModel.AddUserTypeId = value.AddUserTypeId;
                        addressModel.AddAddressType = value.AddAddressType;
                        addressModel.AddDoorNo = value.AddDoorNo;
                        addressModel.AddStreetName = value.AddStreetName;
                        addressModel.AddArea = value.AddArea;
                        addressModel.AddCity = value.AddCity;
                        addressModel.AddLandmark = value.AddLandmark;
                        addressModel.AddPin = value.AddPin;
                        addressModel.AddLatitude = value.AddLatitude;
                        addressModel.AddLongitude = value.AddLongitude;
                        listModel.Add(addressModel);
                    }
                    return listModel;
                }
                else { return listModel; }
            }
            catch (Exception ex)
            {
                return null;
            }
        }*/

    }
}
