using ClassLibrary_PropertyManager.Model;
using ClassLibrary_PropertyManager.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager.Controller
{
   public class cLandLords
    {
        public static DataTable GetLandLordList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblLandlord ORDER BY LandlordID ASC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;

                        sda.Fill(dt);

                    }
                }
            }
            return dt;
        }

        public static int AddNewLandLord(mLandLords pLandlord)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblLandlord ( LandLordName, LandLordEmail , LandLordPassword , LandLordPicture, IsEmailVerified, LandLordSignupDate, LastLoginDateTime, IsActive) " +
                                                            " VALUES (@LandLordName, @LandLordEmail, @LandLordPassword , @LandLordPicture, @IsEmailVerified, @LandLordSignupDate, @LastLoginDateTime,  @IsActive) ", con))
                {
                    command.Parameters.AddWithValue("@LandLordName", pLandlord.LandLordName);
                    command.Parameters.AddWithValue("@LandLordEmail", pLandlord.LandLordEmail);
                    command.Parameters.AddWithValue("@LandLordPassword", pLandlord.LandLordPassword);
                    command.Parameters.AddWithValue("@LandLordPicture", pLandlord.LandLordPicture);
                    command.Parameters.AddWithValue("@IsEmailVerified", pLandlord.IsEmailVerified);
                    command.Parameters.AddWithValue("@LandLordSignupDate", DateTime.Now);
                    command.Parameters.AddWithValue("@LastLoginDateTime", DateTime.Now);
                    command.Parameters.AddWithValue("@IsActive", pLandlord.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;

        }

        public static int UpdateLandlordrFromEmail(int _LandlordID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblLandlord SET  [IsActive] = 1, [IsEmailVerified] = 1  WHERE LandLordID = @LandLordID ", con))

                {
                    command.Parameters.AddWithValue("@LandLordID", _LandlordID);

                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;

        }

        public static mLandLords VerifyLandLordInformation(string pLandLordEmail, string pLandLordPassword)
        {
            mLandLords collectmLandLord = new mLandLords();
            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select * from tblLandlord where LandLordEmail =@LandLordEmail and LandLordPassword=@LandLordPassword", con))
                {
                    command.Parameters.AddWithValue("@LandLordEmail", pLandLordEmail);
                    command.Parameters.AddWithValue("@LandLordPassword", pLandLordPassword);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {


                                collectmLandLord.LandLordID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("LandLordID")));
                                collectmLandLord.LandLordIDEncrypted = ucEDOperations.EncryptString(Global.gEDKey, Convert.ToString(reader.GetValue(reader.GetOrdinal("LandLordID"))));
                                collectmLandLord.LandLordName = reader.GetValue(reader.GetOrdinal("LandLordName")).ToString();

                                if (reader.GetValue(reader.GetOrdinal("LandLordEmail")) == null)
                                {
                                    collectmLandLord.LandLordEmail = null;
                                }
                                else
                                {
                                    collectmLandLord.LandLordEmail = reader.GetValue(reader.GetOrdinal("LandLordEmail")).ToString();
                                }

                                //collectmLandLord.LastLogin = reader.GetDateTime(reader.GetOrdinal("LastLogin")); //reader.GetDateTime(16);
                                collectmLandLord.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));   //reader.GetBoolean(17);
                                collectmLandLord.IsEmailVerified = reader.GetBoolean(reader.GetOrdinal("IsEmailVerified"));   //reader.GetBoolean(17);
                            }
                        }
                        else

                        {
                            collectmLandLord = null;
                        }

                    }
                }
            }
            return collectmLandLord;
        }

     

    }
}
