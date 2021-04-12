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
    public class cTenant
    {
        public static int AddNewTenant(mTenant pTenant)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblTenantDetails (TenantNationalID , LandLordID , TenantName , TenantEmail , TenantPassword , TenantPhone, TenantOccupation, TenantCompany, TenantHomeAddress, TenantPicture, TenantAddedOn, Status) " +
                                                            " VALUES (@TenantNationalID, @LandLordID, @TenantName , @TenantEmail, @TenantPassword, @TenantPhone, @TenantOccupation, @TenantCompany,  @TenantHomeAddress, @TenantPicture, @TenantAddedOn ,@Status) select CAST(scope_identity() AS int) ", con))
                {
                    command.Parameters.AddWithValue("@TenantNationalID", pTenant.TenantNationalID);
                    command.Parameters.AddWithValue("@LandLordID", pTenant.LandLordID);
                    command.Parameters.AddWithValue("@TenantName", pTenant.TenantName);
                    command.Parameters.AddWithValue("@TenantEmail", pTenant.TenantEmail);
                    command.Parameters.AddWithValue("@TenantPassword", pTenant.TenantPassword);
                    command.Parameters.AddWithValue("@TenantPhone", pTenant.TenantPhone);
                    command.Parameters.AddWithValue("@TenantOccupation", pTenant.TenantOccupation);
                    command.Parameters.AddWithValue("@TenantCompany", pTenant.TenantCompany);
                    command.Parameters.AddWithValue("@TenantHomeAddress", pTenant.TenantHomeAddress);
                    command.Parameters.AddWithValue("@TenantPicture", pTenant.TenantPicture);
                    command.Parameters.AddWithValue("@TenantAddedOn", DateTime.Now);
                    command.Parameters.AddWithValue("@Status", pTenant.Status);


                    isSucess = Convert.ToInt32(command.ExecuteScalar());


                }
            }




            return isSucess;

        }

        public static DataTable GetTenantByLandLordID(int pLandLordID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblTenantDetails WHERE LandLordID = @LandLordID ORDER BY LandLordID ASC", con))
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

        public static DataTable GetTenantByTenantID(int pTenantID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblTenantDetails WHERE TenantID = @TenantID ORDER BY TenantID ASC", con))
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

        public static int UpdateTenant(mTenant pTenant)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblTenantDetails SET  [TenantNationalID] = @TenantNationalID, [LandLordID] = @LandLordID, [TenantName] = @TenantName, [TenantEmail] = @TenantEmail, " +
                                                         " [TenantOccupation] = @TenantOccupation, [TenantCompany] = @TenantCompany, [TenantHomeAddress] = @TenantHomeAddress, [TenantPicture] = @TenantPicture," +
                                                         " [Status] = @Status WHERE TenantID = @TenantID ", con))

                {
                    command.Parameters.AddWithValue("@TenantID", pTenant.TenantID);
                    command.Parameters.AddWithValue("@TenantNationalID", pTenant.TenantNationalID);
                    command.Parameters.AddWithValue("@LandLordID", pTenant.LandLordID);
                    command.Parameters.AddWithValue("@TenantName", pTenant.TenantName);
                    command.Parameters.AddWithValue("@TenantEmail", pTenant.TenantEmail);
                    command.Parameters.AddWithValue("@TenantPhone", pTenant.TenantPhone);
                    command.Parameters.AddWithValue("@TenantOccupation", pTenant.TenantOccupation);
                    command.Parameters.AddWithValue("@TenantCompany", pTenant.TenantCompany);
                    command.Parameters.AddWithValue("@TenantHomeAddress", pTenant.TenantHomeAddress);
                    command.Parameters.AddWithValue("@TenantPicture", pTenant.TenantPicture);
                    command.Parameters.AddWithValue("@Status", pTenant.Status);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }

    }
}
