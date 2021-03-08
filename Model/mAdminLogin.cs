using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager.Model
{
    public class mAdminLogin
    {
        public int AdminLoginID;
        public string AdminLoginName;
        public string AdminLoginEmail;
        public string AdminLoginPassword;
        public string AdminPicture;
        public bool IsEmailVerified;
        public DateTime LastLoginDateTime;
        public bool IsActive;
        public DateTime AdminSignupDate;
        public string AdminIDEncrypted;
    }
}
