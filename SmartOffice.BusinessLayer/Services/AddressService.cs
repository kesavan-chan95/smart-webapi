using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.DataLayer.Repositories;
using SmartOffice.Infrastructure.Infrastructure;
using SmartOffice.Models.UserModel;
using System.Collections.Generic;

namespace SmartOffice.BusinessLayer.Services
{

    public interface IAddressService
    {
        bool AddressCreation(AddressModel addressModel, string type);
        AddressModel GetAddressById(int addId);
        List<AddressModel> GetAllAddress();

    }
    public class AddressService : IAddressService
    {

        private readonly ImasaddressRepository masaddressRepository;
        private readonly IUnitOfWork<MasterDBContext> unitOfWork;
        public AddressService(ImasaddressRepository masaddressRepository, IUnitOfWork<MasterDBContext> unitOfWork)
        {
            this.masaddressRepository = masaddressRepository;
            this.unitOfWork = unitOfWork;
        }


        public bool AddressCreation(AddressModel addressModel, string type)
        {
            Masaddress tempUser = null;
            try
            {
                if (addressModel != null && type != "D")
                {
                    if (addressModel.AddId == 0)
                    {
                        tempUser = new Masaddress();
                        tempUser.AddUserId = addressModel.AddUserId;
                        tempUser.AddUserTypeId = addressModel.AddUserTypeId;
                        tempUser.AddAddressType = addressModel.AddAddressType;
                        tempUser.AddDoorNo = addressModel.AddDoorNo;
                        tempUser.AddStreetName = addressModel.AddStreetName;
                        tempUser.AddArea = addressModel.AddArea;
                        tempUser.AddCity = addressModel.AddCity;
                        tempUser.AddLandmark = addressModel.AddLandmark;
                        tempUser.AddPin = addressModel.AddPin;
                        tempUser.AddLatitude = addressModel.AddLatitude;
                        tempUser.AddLongitude = addressModel.AddLongitude;
                        tempUser.AddIsactive = addressModel.AddIsactive;
                        tempUser.CreatedBy = addressModel.CreatedBy;
                        tempUser.CreatedDate = addressModel.CreatedDate;
                        this.masaddressRepository.Add(tempUser);
                        unitOfWork.Commit();
                        return true;
                    }
                    else
                    {
                        var userData = this.masaddressRepository.Get(exp => exp.AddId == addressModel.AddId && exp.AddIsactive == 1);
                        userData.AddId = addressModel.AddId;
                        userData.AddUserId = addressModel.AddUserId;
                        userData.AddUserTypeId = addressModel.AddUserTypeId;
                        userData.AddAddressType = addressModel.AddAddressType;
                        userData.AddDoorNo = addressModel.AddDoorNo;
                        userData.AddStreetName = addressModel.AddStreetName;
                        userData.AddArea = addressModel.AddArea;
                        userData.AddCity = addressModel.AddCity;
                        userData.AddLandmark = addressModel.AddLandmark;
                        userData.AddPin = addressModel.AddPin;
                        userData.AddLatitude = addressModel.AddLatitude;
                        userData.AddLongitude = addressModel.AddLongitude;
                        userData.AddIsactive = addressModel.AddIsactive;
                        userData.ModifiedBy = addressModel.ModifiedBy;
                        userData.ModifiedDate = addressModel.ModifiedDate;
                        masaddressRepository.Update(userData);
                        unitOfWork.Commit();
                        return true;
                    }
                }
                else
                {
                    var userData = this.masaddressRepository.Get(exp => exp.AddId == addressModel.AddId);
                    userData.AddIsactive = 0;
                    userData.ModifiedBy = addressModel.ModifiedBy;
                    userData.ModifiedDate = addressModel.ModifiedDate;
                    masaddressRepository.Update(userData);
                    unitOfWork.Commit();
                    return true;
                }
            }
            finally { tempUser = null; }
        }
        public AddressModel GetAddressById(int addId)
        {
            AddressModel addressModel = null;
            try
            {
                var model = masaddressRepository.Get(exp => exp.AddId == addId && exp.AddIsactive == 1);
                addressModel = new AddressModel();
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
            finally
            { addressModel = null; }
        }
        public List<AddressModel> GetAllAddress()
        {
            List<AddressModel> listModel = null;
            AddressModel addressModel = null;
            try
            {
                var model = masaddressRepository.GetAll();
                if (model != null)
                {

                    listModel = new List<AddressModel>();
                    foreach (var value in model)
                    {
                        addressModel = new AddressModel();
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
                }
                return listModel;
            }
            finally
            { addressModel = null; listModel = null; }
        }

    }
}
