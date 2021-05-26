using ClassLibrary_PropertyManager.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager.Controller
{
   public class cBill
    {
        public static int AddNewBill(mBill pBill)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblBill (TenantID, LandLordID, BillType ,BillAmount, BillRecurrency, BillCreatedOn, BillDueDate, BillNotes, BillAttatchment, BillStatus) " +
                                                            " VALUES (@TenantID, @LandLordID, @BillType , @BillAmount , @BillRecurrency, @BillCreatedOn, @BillDueDate, @BillNotes, @BillAttatchment, @BillStatus) select CAST(scope_identity() AS int) ", con))
                {
                    command.Parameters.AddWithValue("@TenantID", pBill.TenantID);
                    command.Parameters.AddWithValue("@LandLordID", pBill.LandLordID);
                    command.Parameters.AddWithValue("@BillType", pBill.BillType);
                    command.Parameters.AddWithValue("@BillAmount", pBill.BillAmount);
                    command.Parameters.AddWithValue("@BillRecurrency", pBill.BillRecurrency);
                    command.Parameters.AddWithValue("@BillCreatedOn", DateTime.Now);
                    command.Parameters.AddWithValue("@BillDueDate", pBill.BillDueDate);
                    command.Parameters.AddWithValue("@BillNotes", pBill.BillNotes);
                    command.Parameters.AddWithValue("@BillAttatchment", pBill.BillAttatchment);
                    command.Parameters.AddWithValue("@BillStatus", pBill.BillStatus);

                    isSucess = Convert.ToInt32(command.ExecuteScalar());


                }
            }


            return isSucess;

        }
    }
}
