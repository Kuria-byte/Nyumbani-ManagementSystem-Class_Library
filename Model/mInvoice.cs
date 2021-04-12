using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager.Model
{
    public class mInvoice
    {
        public int InvoiceID;
        public int TenantID;
        public int LandLordID;
        public string InvoiceType;
        public double InvoiceAmount;
        public DateTime InvoiceDueDate;
        public string InvoiceNotes;
        public string InvoiceAttatchments;
        public bool InvoiceReminder;
        public DateTime InvoiceGeneratedOn;
    }
}
