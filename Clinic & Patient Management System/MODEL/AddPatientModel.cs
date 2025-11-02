using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Clinic___Patient_Management_System.MODEL
{
    public class AddPatientModel
    {
        private readonly string _connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public void SavePatient(int patientId, string name, string age, string address, string sex, string contact, string email)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                SqlCommand cmd;

                if (patientId > 0)
                {
                    // UPDATE
                    cmd = new SqlCommand(@"UPDATE tbl_patientRecord 
                                           SET Name=@Name, Age=@Age, Address=@Address, 
                                               Sex=@Sex, ContactNo=@ContactNo, Email=@Email 
                                           WHERE PatientID=@PatientID", con);
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                }
                else
                {
                    // INSERT
                    cmd = new SqlCommand(@"INSERT INTO tbl_patientRecord
                                           (Name, Age, Address, Sex, ContactNo, Email)
                                           VALUES (@Name, @Age, @Address, @Sex, @ContactNo, @Email)", con);
                }

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Sex", sex);
                cmd.Parameters.AddWithValue("@ContactNo", contact);
                cmd.Parameters.AddWithValue("@Email", email);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
