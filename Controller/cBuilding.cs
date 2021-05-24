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
    public class cBuilding
    {
        public static DataTable GetBuildings()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblBuildings ORDER BY BuildingID ASC", con))
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

        public static int AddBuilding(mBuilding pBuilding)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblBuildings (BuildingType, LandLordID, BuildingName, BuildingCity, BuildingAddress , TotalUnits, Contractor, CompletionDate, BuildingImage, Parking, Security, KidFriendly, IsActive) " +
                                                            " VALUES ( @BuildingType, @LandLordID, @BuildingName, @BuildingCity, @BuildingAddress, @TotalUnits, @Contractor, @CompletionDate, @BuildingImage , @Parking,  @Security, @KidFriendly, @IsActive) ", con))
                {
                    command.Parameters.AddWithValue("@BuildingType", pBuilding.BuildingType);
                    command.Parameters.AddWithValue("@LandLordID", pBuilding.LandLordID);
                    command.Parameters.AddWithValue("@BuildingName", pBuilding.BuildingName);
                    command.Parameters.AddWithValue("@BuildingCity", pBuilding.BuildingCity);
                    command.Parameters.AddWithValue("@BuildingAddress", pBuilding.BuildingAddress);
                    command.Parameters.AddWithValue("@TotalUnits", pBuilding.TotalUnits);
                    command.Parameters.AddWithValue("@Contractor", pBuilding.Contractor);
                    command.Parameters.AddWithValue("@CompletionDate", pBuilding.CompletionDate);
                    command.Parameters.AddWithValue("@BuildingImage", pBuilding.BuildingImage);
                    command.Parameters.AddWithValue("@Parking", pBuilding.Parking);
                    command.Parameters.AddWithValue("@Security", pBuilding.Security);
                    command.Parameters.AddWithValue("@Kidfriendly", pBuilding.KidFriendly);
                    command.Parameters.AddWithValue("@IsActive", pBuilding.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;


        }

        public static DataTable GetBuildingByLandLordID(int pLandLordID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblBuildings WHERE LandLordID = @LandLordID ORDER BY LandLordID ASC", con))
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
        public static DataTable GetBuildingByBuildingID(int pBuildingID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblBuildings WHERE BuildingID = @BuildingID ORDER BY BuildingID ASC", con))
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
        public static int UpdateBuildig(mBuilding pBuilding)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblBuildings SET  [BuildingType] = @BuildingType, [LandLordID] = @LandLordID, [BuildingName] = @BuildingName, [BuildingCity] = @BuildingCity, " +
                                                         " [BuildingAddress] = @BuildingAddress, [TotalUnits] = @TotalUnits, [Contractor] = @Contractor, [CompletionDate] = @CompletionDate," +
                                                         " [BuildingImage] = @BuildingImage,[Parking] = @Parking,[Security] = @Security,[KidFriendly] = @KidFriendly,  " +
                                                         " [IsActive] = @IsActive WHERE BuildingID = @BuildingID ", con))

                {
                    command.Parameters.AddWithValue("@BuildingID", pBuilding.BuildingID);
                    command.Parameters.AddWithValue("@BuildingType", pBuilding.BuildingType);
                    command.Parameters.AddWithValue("@LandLordID", pBuilding.LandLordID);
                    command.Parameters.AddWithValue("@BuildingName", pBuilding.BuildingName);
                    command.Parameters.AddWithValue("@BuildingCity", pBuilding.BuildingCity);
                    command.Parameters.AddWithValue("@BuildingAddress", pBuilding.BuildingAddress);
                    command.Parameters.AddWithValue("@TotalUnits", pBuilding.TotalUnits);
                    command.Parameters.AddWithValue("@Contractor", pBuilding.Contractor);
                    command.Parameters.AddWithValue("@CompletionDate", pBuilding.CompletionDate);
                    command.Parameters.AddWithValue("@BuildingImage", pBuilding.BuildingImage);
                    command.Parameters.AddWithValue("@Parking", pBuilding.Parking);
                    command.Parameters.AddWithValue("@Security", pBuilding.Security);
                    command.Parameters.AddWithValue("@KidFriendly", pBuilding.KidFriendly);
                    command.Parameters.AddWithValue("@IsActive", pBuilding.IsActive);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }


    }
}
