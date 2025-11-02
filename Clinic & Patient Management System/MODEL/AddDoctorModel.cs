using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class AddDoctorModel
    {
        private readonly string _connection =
          @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";

        public DataTable GetSpecializations()
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = "SELECT SpecializationID, SpecializationName FROM tbl_specialization";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddDoctor(string name, int specializationID, string contact, string email, string status)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                string query = @"INSERT INTO tbl_doctor 
                                 (Name, SpecializationID, ContactNumber, Email, Status)
                                 VALUES (@Name, @SpecializationID, @ContactNumber, @Email, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@SpecializationID", specializationID);
                    cmd.Parameters.AddWithValue("@ContactNumber", contact);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Status", status);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
