using ClassLibrary_PropertyManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager
{
   public class Global
    {
        public static string connString = "";
        public static ClassLibrary_PropertyManager.Model.mAdminLogin gAdminLogin = new ClassLibrary_PropertyManager.Model.mAdminLogin();

        public static mLandLords gLandLordInfo;
        public static string gEDKey;
        public static string gFromEmail;
        public static string gFromEmailPassword;
        public static string gWebDomain;


    }
}
