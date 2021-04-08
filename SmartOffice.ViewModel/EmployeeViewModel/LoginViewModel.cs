namespace SmartOffice.ViewModel.EmployeeViewModel
{
    public class LoginViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }


    }

    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string type { get; set; }
    }

    public class GetViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
     
        public string Emproll { get; set; }
      
    }

}


