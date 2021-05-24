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
    public class cInvoice
    {
        public static DataTable GetInvoiceByLandLordID(int pLandLordID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();
         

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM  tblInvoice INNER JOIN tblTenantDetails on tblInvoice.TenantID = tblTenantDetails.TenantID " +
               "  WHERE tblInvoice.LandLordID = @LandLordID ORDER BY tblInvoice.LandLordID ASC", con))
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

        public static DataTable GetInvoiceByBuildingID(int pBuildingID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();


                using (SqlCommand cmd = new SqlCommand("SELECT * FROM  tblInvoice  " +
               "  WHERE tblInvoice.BuildingID = @BuildingID ORDER BY tblInvoice.BuildingID ASC", con))
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

        public static int AddNewInvoice(mInvoice pInvoice)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblInvoice (TenantID ,LandLordID, InvoiceType , InvoiceAmount, InvoiceGeneratedOn, InvoiceDueDate , InvoiceNotes , InvoiceAttatchments, InvoiceReminder, InvoiceStatus ) " +
                                                            " VALUES (@TenantID, @LandLordID,@BuildingID, @InvoiceType, @InvoiceAmount , @InvoiceGeneratedOn, @InvoiceDueDate, @InvoiceNotes, @InvoiceAttatchments, @InvoiceReminder, @InvoiceStatus) select CAST(scope_identity() AS int) ", con))
                {
                    command.Parameters.AddWithValue("@TenantID", pInvoice.TenantID);
                    command.Parameters.AddWithValue("@LandLordID", pInvoice.LandLordID);
                
                    command.Parameters.AddWithValue("@InvoiceType", pInvoice.InvoiceType);
                    command.Parameters.AddWithValue("@InvoiceAmount", pInvoice.InvoiceAmount);
                    command.Parameters.AddWithValue("@InvoiceGeneratedOn", DateTime.Now);
                    command.Parameters.AddWithValue("@InvoiceDueDate", pInvoice.InvoiceDueDate);
                    command.Parameters.AddWithValue("@InvoiceNotes", pInvoice.InvoiceNotes);
                    command.Parameters.AddWithValue("@InvoiceAttatchments", pInvoice.InvoiceAttatchments);
                    command.Parameters.AddWithValue("@InvoiceReminder", pInvoice.InvoiceReminder);
                    command.Parameters.AddWithValue("@InvoiceStatus", pInvoice.InvoiceStatus);

                    isSucess = Convert.ToInt32(command.ExecuteScalar());


                }
            }


            return isSucess;

        }


    }
}
