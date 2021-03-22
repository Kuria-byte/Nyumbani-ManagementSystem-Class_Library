using ClassLibrary_PropertyManager.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager.Controller
{
   public class cTenantContract
    {
        public static int AddNewContract(mTenantContract pTenantContract)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblTenantContract (TenantID , LandLordID , UnitID , TenantDeposit , TenantMonthlyRent, ContractStartDate, ContractEndDate, AgreementDocoument, ContractStatusID) " +
                                                            " VALUES (@TenantID, @LandLordID, @UnitID , @TenantDeposit, @TenantMonthlyRent, @ContractStartDate, @ContractEndDate,  @AgreementDocoument, @ContractStatusID) select CAST(scope_identity() AS int) ", con))
                {
                    command.Parameters.AddWithValue("@TenantID", pTenantContract.TenantID);
                    command.Parameters.AddWithValue("@LandLordID", pTenantContract.LandLordID);
                    command.Parameters.AddWithValue("@UnitID", pTenantContract.UnitID);
                    command.Parameters.AddWithValue("@TenantDeposit", pTenantContract.TenantDeposit);
                    command.Parameters.AddWithValue("@TenantMonthlyRent", pTenantContract.TenantMonthlyRent);
                    command.Parameters.AddWithValue("@ContractStartDate", pTenantContract.ContractStartDate);
                    command.Parameters.AddWithValue("@ContractEndDate", pTenantContract.ContractEndDate);
                    command.Parameters.AddWithValue("@AgreementDocoument", pTenantContract.AgreementDocoument);
                    command.Parameters.AddWithValue("@ContractStatusID", pTenantContract.ContractStatusID);
                  
                    isSucess = Convert.ToInt32(command.ExecuteScalar());


                }
            }
    

            return isSucess;

        }
    }
}
