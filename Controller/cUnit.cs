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
    public class cUnit
    {
        public static DataTable GetUnits()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblUnit ORDER BY UnitID ASC", con))
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

        public static int AddUnit(mUnit pUnit)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblUnit (UnitType, BuildingID, LandLordID, UnitNumber, FloorLevel , UnitSize, UnitAddress, UnitCity, Description, Bedrooms, Bathrooms, Kitchen, UnitPrice, Garage, Furnishing, Available, UnitPictures, UnitAddedOn) " +
                                                            " VALUES ( @UnitType, @BuildingID, @LandLordID, @UnitNumber, @FloorLevel, @UnitSize, @UnitAddress, @UnitCity, @Description , @Bedrooms,  @Bathrooms, @Kitchen, @UnitPrice, @Garage, @Furnishing, @Available, @UnitPictures, @UnitAddedOn ) ", con))
                {
                    command.Parameters.AddWithValue("@UnitType", pUnit.UnitType);
                    command.Parameters.AddWithValue("@BuildingID", pUnit.BuildingID);
                    command.Parameters.AddWithValue("@LandLordID", pUnit.LandLordID);
                    command.Parameters.AddWithValue("@UnitNumber", pUnit.UnitNumber);
                    command.Parameters.AddWithValue("@FloorLevel", pUnit.FloorLevel);
                    command.Parameters.AddWithValue("@UnitSize", pUnit.UnitSize);
                    command.Parameters.AddWithValue("@UnitAddress", pUnit.UnitAddress);
                    command.Parameters.AddWithValue("@UnitCity", pUnit.UnitCity);
                    command.Parameters.AddWithValue("@Description", pUnit.Description);
                    command.Parameters.AddWithValue("@Bedrooms", pUnit.Bedrooms);
                    command.Parameters.AddWithValue("@Bathrooms", pUnit.Bathrooms);
                    command.Parameters.AddWithValue("@Kitchen", pUnit.Kitchen);
                    command.Parameters.AddWithValue("@UnitPrice", pUnit.UnitPrice);
                    command.Parameters.AddWithValue("@Garage", pUnit.Garage);
                    command.Parameters.AddWithValue("@Furnishing", pUnit.Furnishing);
                    command.Parameters.AddWithValue("@Available", pUnit.Available);
                    command.Parameters.AddWithValue("@UnitPictures", pUnit.UnitPictures);
                    command.Parameters.AddWithValue("@UnitAddedOn", DateTime.Now);

                    isSucess = command.ExecuteNonQuery();


                }
            }




            return isSucess;


        }

        public static DataTable GetUnitByUnitID(int pUnitID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM  tblUnit INNER JOIN tblBuildings ON tblUnit.BuildingID = tblBuildings.BuildingID  WHERE tblUnit.UnitID = @UnitID ORDER BY tblUnit.UnitID ASC", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UnitID", pUnitID);

                        sda.Fill(dt);


                    }
                }
            }
            return dt;
        }
        public static DataTable GetUnitByLandLordID(int pLandLordID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM  tblUnit INNER JOIN tblBuildings ON tblUnit.BuildingID = tblBuildings.BuildingID  WHERE tblUnit.LandLordID = @LandLordID ORDER BY tblUnit.LandLordID ASC", con))
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

        public static DataTable GetUnitByBuildingID(int pBuildingID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT  * FROM   tblUnit WHERE BuildingID = @BuildingID ORDER BY BuildingID ASC", con))
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
        public static int UpdateUnitAvailability(int UnitId, bool Availbalble)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblUnit SET  [Available] = @Available WHERE UnitID = @UnitID ", con))

                {
                    command.Parameters.AddWithValue("@UnitID", UnitId);
                    command.Parameters.AddWithValue("@Available",Availbalble);

                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }
        public static int UpdateUnit(mUnit pUnit)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("UPDATE tblUnit SET  [UnitType] = @UnitType, [BuildingID] = @BuildingID, [UnitNumber] = @UnitNumber, [FloorLevel] = @FloorLevel, " +
                                                         " [UnitSize] = @UnitSize, [UnitAddress] = @UnitAddress, [UnitCity] = @UnitCity, [Description] = @Description," +
                                                         " [Bedrooms] = @Bedrooms,[Bathrooms] = @Bathrooms,[Kitchen] = @Kitchen,[UnitPrice] = @UnitPrice,  " +
                                                         " [Garage] = @Garage, [Furnishing] = @Furnishing, [Available] = @Available, [UnitPictures] = @UnitPictures WHERE UnitID = @UnitID ", con))

                {
                    command.Parameters.AddWithValue("@UnitID", pUnit.UnitID);
                    command.Parameters.AddWithValue("@UnitType", pUnit.UnitType);
                    command.Parameters.AddWithValue("@BuildingID", pUnit.BuildingID);
                    command.Parameters.AddWithValue("@LandLordID", pUnit.LandLordID);
                    command.Parameters.AddWithValue("@UnitNumber", pUnit.UnitNumber);
                    command.Parameters.AddWithValue("@FloorLevel", pUnit.FloorLevel);
                    command.Parameters.AddWithValue("@UnitSize", pUnit.UnitSize);
                    command.Parameters.AddWithValue("@UnitAddress", pUnit.UnitAddress);
                    command.Parameters.AddWithValue("@UnitCity", pUnit.UnitCity);
                    command.Parameters.AddWithValue("@Description", pUnit.Description);
                    command.Parameters.AddWithValue("@Bedrooms", pUnit.Bedrooms);
                    command.Parameters.AddWithValue("@Bathrooms", pUnit.Bathrooms);
                    command.Parameters.AddWithValue("@Kitchen", pUnit.Kitchen);
                    command.Parameters.AddWithValue("@UnitPrice", pUnit.UnitPrice);
                    command.Parameters.AddWithValue("@Garage", pUnit.Garage);
                    command.Parameters.AddWithValue("@Furnishing", pUnit.Furnishing);
                    command.Parameters.AddWithValue("@Available", pUnit.Available);
                    command.Parameters.AddWithValue("@UnitPictures", pUnit.UnitPictures);


                    isSucess = command.ExecuteNonQuery();


                }
            }

            return isSucess;


        }


    }
}
