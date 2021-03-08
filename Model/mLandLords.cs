using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager.Model
{
   public class mLandLords
    {
        public int LandLordID;
        public string LandLordName;
        public string LandLordEmail;
        public string LandLordPassword;
        public string LandLordPicture;
        public bool IsEmailVerified;
        public DateTime LandLordSignupDate;
        public DateTime LastLoginDateTime;
        public string LandLordIDEncrypted;
        public bool IsActive;

    }
}
