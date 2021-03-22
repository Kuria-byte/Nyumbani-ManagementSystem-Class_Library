using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager.Model
{
    public class mTenantContract
    {
        public int TenantContractID;
        public int TenantID;
        public int LandLordID;
        public int UnitID;
        public double TenantDeposit;
        public double TenantMonthlyRent;
        public DateTime ContractStartDate;
        public DateTime ContractEndDate;
        public string AgreementDocoument;
        public bool ContractStatusID;

    }
}
