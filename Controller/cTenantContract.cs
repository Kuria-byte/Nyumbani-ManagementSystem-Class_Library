using ClassLibrary_PropertyManager.Model;
using System;
using System.Collections.Generic;
using System.Data;
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


        public static int UpdateTenantContract(mTenantContract pTenantContract)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblTenantContract SET  [TenantID] = @TenantID, [LandLordID] = @LandLordID, [UnitID] = @UnitID, [TenantDeposit] = @TenantDeposit, " +
                                                         " [TenantMonthlyRent] = @TenantMonthlyRent, [ContractStartDate] = @ContractStartDate, [ContractEndDate] = @ContractEndDate, [AgreementDocoument] = @AgreementDocoument," +
                                                         " [ContractStatusID] = @ContractStatusID WHERE TenantContractID = @TenantContractID ", con))

                {
                    command.Parameters.AddWithValue("@TenantContractID", pTenantContract.TenantContractID);
                    command.Parameters.AddWithValue("@TenantID", pTenantContract.TenantID);
                    command.Parameters.AddWithValue("@LandLordID", pTenantContract.LandLordID);
                    command.Parameters.AddWithValue("@UnitID", pTenantContract.UnitID);
                    command.Parameters.AddWithValue("@TenantDeposit", pTenantContract.TenantDeposit);
                    command.Parameters.AddWithValue("@TenantMonthlyRent", pTenantContract.TenantMonthlyRent);
                    command.Parameters.AddWithValue("@ContractStartDate", pTenantContract.ContractStartDate);
                    command.Parameters.AddWithValue("@ContractEndDate", pTenantContract.ContractEndDate);
                    command.Parameters.AddWithValue("@AgreementDocoument", pTenantContract.AgreementDocoument);
                    command.Parameters.AddWithValue("@ContractStatusID", pTenantContract.ContractStatusID);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }

        public static DataTable GetTenantContractByLandLordID(int pLandLordID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM  tblTenantContract INNER JOIN tblTenantDetails on tblTenantContract.TenantID = tblTenantDetails.TenantID " +
                    " INNER JOIN tblUnit on tblTenantContract.UnitID = tblUnit.UnitID  WHERE tblTenantContract.LandLordID = @LandLordID ORDER BY tblTenantContract.LandLordID ASC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@LandLordID", pLandLordID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }

        public static DataTable GetTenantContractByTenantID(int pTenantID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM  tblTenantContract INNER JOIN tblTenantDetails on tblTenantContract.TenantID = tblTenantDetails.TenantID " +
                    "  WHERE tblTenantContract.TenantID = @TenantID ", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@TenantID", pTenantID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }

    }
}
