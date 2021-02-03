using System;
using System.Collections.Generic;
using System.Text;

namespace Library_EstateManagementSystem.Models
{
    public class mAdminLogin
    {
        public int AdminLoginID;
        public string AdminLoginName;
        public string AdminLoginEmail;
        public string AdminLoginPassword;
        public string AdminPicture;
        public DateTime LastLoginDateTime;
        public bool IsActive;
    }
}
