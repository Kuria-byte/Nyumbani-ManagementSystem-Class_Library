using ClassLibrary_PropertyManager.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_PropertyManager.Controller
{
    public class cEmployee
    {

        public static int AddNewEmployee(mEmployee pEmployee)
        {

            int isSucess = 0;

            using (SqlConnection con = new SqlConnection(Global.connString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO tblEmployee ( LandLordID , EmployeeName , EmployeeType , EmployeeEmail , EmployeePassword, EmployeePhone, BuildingID, EmployeePicture, EmployeeAddedOn, EmployeeStatus) " +
                                                            " VALUES ( @LandLordID , @EmployeeName , @EmployeeType , @EmployeeEmail , @EmployeePassword, @EmployeePhone, @BuildingID, @EmployeePicture, @EmployeeAddedOn, @EmployeeStatus) select CAST(scope_identity() AS int) ", con))
                {
                    command.Parameters.AddWithValue("@LandLordID", pEmployee.LandLordID);
                    command.Parameters.AddWithValue("@EmployeeName", pEmployee.EmployeeName);
                    command.Parameters.AddWithValue("@EmployeeType", pEmployee.EmployeeType);
                    command.Parameters.AddWithValue("@EmployeeEmail", pEmployee.EmployeeEmail);
                    command.Parameters.AddWithValue("@EmployeePassword", pEmployee.EmployeePassword);
                    command.Parameters.AddWithValue("@EmployeePhone", pEmployee.EmployeePhone);
                    command.Parameters.AddWithValue("@BuildingID", pEmployee.BuildingID);
                    command.Parameters.AddWithValue("@EmployeePicture", pEmployee.EmployeePicture);
                    command.Parameters.AddWithValue("@EmployeeAddedOn", DateTime.Now);
                    command.Parameters.AddWithValue("@EmployeeStatus", pEmployee.EmployeeStatus);

                    isSucess = Convert.ToInt32(command.ExecuteScalar());

                }
            }

             return isSucess;

        }


    }
}
