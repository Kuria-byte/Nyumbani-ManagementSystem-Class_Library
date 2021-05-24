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
   public class cAnnouncment
    {
        public static int AddNewAnnouncment(mAnnouncment pAnnouncment)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblAnnouncments (Announcment , AnnouncmentPicture , AnnouncmentDate , LandLordID , BuildingID, AnnouncmentStatus) " +
                                                            " VALUES (@Announcment, @AnnouncmentPicture, @AnnouncmentDate , @LandLordID, @BuildingID, @AnnouncmentStatus) select CAST(scope_identity() AS int) ", con))
                {
                    command.Parameters.AddWithValue("@Announcment", pAnnouncment.Announcment);
                    command.Parameters.AddWithValue("@AnnouncmentPicture", pAnnouncment.AnnouncmentPicture);
                    command.Parameters.AddWithValue("@AnnouncmentDate", DateTime.Now);
                    command.Parameters.AddWithValue("@LandLordId", pAnnouncment.LandLordId);
                    command.Parameters.AddWithValue("@BuildingID", pAnnouncment.BuildingID);
                    command.Parameters.AddWithValue("@AnnouncmentStatus", pAnnouncment.AnnouncmentStatus);
                  


                    isSucess = Convert.ToInt32(command.ExecuteScalar());


                }
            }




            return isSucess;

        }

        public static DataTable GetAnnouncmentsByLandLordID(int pLandLordID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblAnnouncments WHERE LandLordID = @LandLordID ORDER BY LandLordID ASC", con))
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

        public static DataTable GetAnnouncmentsByBuildingID(int pBuildingID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblAnnouncments WHERE BuildingID = @BuildingID ORDER BY BuildingID ASC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@BuildingID", pBuildingID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }

    }
}
