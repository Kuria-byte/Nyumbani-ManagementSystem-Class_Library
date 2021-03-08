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
   public class cAdminLogin
    {
        public static DataTable GetAdminLoginList()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblAdminLogin ORDER BY AdminLoginName ASC", con))
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
        public static int AddNewAdminLogin(mAdminLogin pAdminLogin)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblAdminLogin ( AdminLoginName, AdminLoginEmail, AdminLoginPassword ,AdminPicture, IsEmailVerified, LastLoginDateTime, IsActive, AdminSignupDate) " +
                                                            " VALUES (@AdminLoginName ,@AdminLoginEmail, @AdminLoginPassword, @AdminPicture, @IsEmailVerified, @LastLoginDateTime,  @IsActive, @AdminSignupDate)  SELECT SCOPE_IDENTITY() ", con))
                {
                    command.Parameters.AddWithValue("@AdminLoginName", pAdminLogin.AdminLoginName);
                    command.Parameters.AddWithValue("@AdminLoginEmail", pAdminLogin.AdminLoginEmail);
                    command.Parameters.AddWithValue("@AdminLoginPassword", pAdminLogin.AdminLoginPassword);
                    command.Parameters.AddWithValue("@AdminPicture", pAdminLogin.AdminPicture);
                    command.Parameters.AddWithValue("@IsEmailVerified", pAdminLogin.IsEmailVerified);
                    command.Parameters.AddWithValue("@LastLoginDateTime", DateTime.Now);
                    command.Parameters.AddWithValue("@IsActive", pAdminLogin.IsActive);
                    command.Parameters.AddWithValue("@AdminSignupDate", DateTime.Now);


                   
                    isSucess = Convert.ToInt32(command.ExecuteScalar());


                }
            }




            return isSucess;

        }

        public static int UpdateAdminLogin(mAdminLogin pAdminLogin)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblAdminLogin SET  [AdminLoginName] = @AdminLoginEmail, [AdminLoginEmail] = @AdminLoginName, [AdminLoginPassword] = @AdminLoginPassword, [AdminPicture]= @AdminPicture, [IsEmailVerified]= @IsEmailVerified, [LastLoginDateTime] = @LastLoginDateTime, " +
                                                            "[IsActive] = @IsActive, [AdminSignupDate] = @AdminSignupDate  WHERE AdminLoginID = @AdminLoginID ", con))

                {
                    command.Parameters.AddWithValue("@AdminLoginID", pAdminLogin.AdminLoginID);
                    command.Parameters.AddWithValue("@AdminLoginName", pAdminLogin.AdminLoginName);
                    command.Parameters.AddWithValue("@AdminLoginEmail", pAdminLogin.AdminLoginEmail);
                    command.Parameters.AddWithValue("@AdminLoginPassword", pAdminLogin.AdminLoginPassword);
                    command.Parameters.AddWithValue("@AdminPicture", pAdminLogin.AdminPicture);
                    command.Parameters.AddWithValue("@IsEmailVerified", pAdminLogin.IsEmailVerified);
                    command.Parameters.AddWithValue("@LastLoginDateTime", DateTime.Now);
                    command.Parameters.AddWithValue("@IsActive", pAdminLogin.IsActive);
                    command.Parameters.AddWithValue("@AdminSignupDate", DateTime.Now);

                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;

        }



        public static mAdminLogin VerifyAdminInformation(string pAdminLoginEmail, string pAdminLoginPassword)
        {
            mAdminLogin collectmAdmin = new mAdminLogin();
            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select * from tblAdminLogin where AdminLoginEmail = @AdminLoginEmail and AdminLoginPassword = @AdminLoginPassword", con))
                {
                    command.Parameters.AddWithValue("@AdminLoginEmail", pAdminLoginEmail);
                    command.Parameters.AddWithValue("@AdminLoginPassword", pAdminLoginPassword);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {


                                collectmAdmin.AdminLoginID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("AdminLoginID")));
                                collectmAdmin.AdminIDEncrypted = UtilityClasses.ucEDOperations.EncryptString(Global.gEDKey, Convert.ToString(reader.GetValue(reader.GetOrdinal("AdminLoginID"))));
                                collectmAdmin.AdminLoginName = reader.GetValue(reader.GetOrdinal("AdminLoginName")).ToString();

                                if (reader.GetValue(reader.GetOrdinal("AdminLoginEmail")) == null)
                                {
                                    collectmAdmin.AdminLoginEmail = null;
                                }
                                else
                                {
                                    collectmAdmin.AdminLoginEmail = reader.GetValue(reader.GetOrdinal("AdminLoginEmail")).ToString();
                                }

                                //collectmBusinessUser.LastLogin = reader.GetDateTime(reader.GetOrdinal("LastLogin")); //reader.GetDateTime(16);
                                collectmAdmin.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));   //reader.GetBoolean(17);
                                collectmAdmin.IsEmailVerified = reader.GetBoolean(reader.GetOrdinal("IsEmailVerified"));   //reader.GetBoolean(17);
                            }
                        }
                        else

                        {
                            collectmAdmin = null;
                        }

                    }
                }
            }

            return collectmAdmin;
        }
        public static mAdminLogin VerifyAdminEmail(string spAdminEmail)
        {
            mAdminLogin collectmAdmin = new mAdminLogin();
            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("select * from tblAdminLogin where AdminLoginEmail = @AdminLoginEmail ", con))
                {
                    command.Parameters.AddWithValue("@AdminLoginEmail", spAdminEmail);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                             
                                collectmAdmin.AdminLoginID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("AdminLoginID")));
                                collectmAdmin.AdminIDEncrypted = UtilityClasses.ucEDOperations.EncryptString(Global.gEDKey, Convert.ToString(reader.GetValue(reader.GetOrdinal("AdminLoginID"))));
                                collectmAdmin.AdminLoginName = reader.GetValue(reader.GetOrdinal("AdminLoginName")).ToString();

                                if (reader.GetValue(reader.GetOrdinal("AdminLoginEmail")) == null)
                                {
                                    collectmAdmin.AdminLoginEmail = null;
                                }
                                else
                                {
                                    collectmAdmin.AdminLoginEmail = reader.GetValue(reader.GetOrdinal("AdminLoginEmail")).ToString();
                                }

                                collectmAdmin.LastLoginDateTime = reader.GetDateTime(reader.GetOrdinal("lastLogin")); //reader.GetDateTime(16);
                                 collectmAdmin.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));   //reader.GetBoolean(17);
                                collectmAdmin.IsEmailVerified = reader.GetBoolean(reader.GetOrdinal("IsEmailVerified"));   //reader.GetBoolean(17);
                            }

                        }
                        else

                        {
                            collectmAdmin = null;
                        }

                    }
                }
            }

            return collectmAdmin;
        }



        public static int UpdateAdminFromEmail(int _AdminLoginID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblAdminLogin SET  [IsActive] = 1, [IsEmailVerified] = 1  WHERE AdminLoginID = @AdminLoginID ", con))

                {
                    command.Parameters.AddWithValue("@AdminLoginID", _AdminLoginID);

                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;

        }


        public static int UpdateAdminChangePasswordFromEmail(string pNewPassword, int pAdminLoginID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblAdminLogin SET AdminLoginPassword = @AdminLoginPassword WHERE AdminLoginID = @AdminLoginID  ", con))

                {
                    command.Parameters.AddWithValue("@AdminLoginID", pAdminLoginID);
                    command.Parameters.AddWithValue("@AdminLoginPassword", pNewPassword);
                    isSucess = command.ExecuteNonQuery();
                }
            }

            return isSucess;

        }



        public static DataTable GetAdminListWithNoDuplicates(mAdminLogin pAdminLogin)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblAdminLogin WHERE AdminLoginEmail = @AdminLoginEmail", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@AdminLoginEmail", pAdminLogin.AdminLoginEmail);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;

        }

        public static int UpdateAdminLoginDateTime(int _AdminLoginID)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblAdminLogin SET  LastLoginDateTime = GetDate() " +
                                                            " WHERE AdminLoginID = @AdminLoginID ", con))
                {
                    command.Parameters.AddWithValue("@AdminLoginID", _AdminLoginID);
                    isSucess = command.ExecuteNonQuery();
                }
            }

            return isSucess;

        }


    }
}
