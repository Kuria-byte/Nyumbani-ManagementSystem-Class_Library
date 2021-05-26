using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager.Model
{
    public class mBill
    {
        public int BillID;
        public int TenantID;
        public int LandLordID;
        public String BillType;
        public Double BillAmount;
        public int BillRecurrency;
        public DateTime BillCreatedOn;
        public DateTime BillDueDate;
        public string BillNotes;
        public string BillAttatchment;
        public int BillStatus;

    }
}
