using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class LoginModel
    {
        private readonly string connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";

        public (bool Success, int UserID, string FullName, string Role, int? DoctorID) ValidateLogin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = @"
                    SELECT UserID, FullName, Role, DoctorID 
                    FROM tbl_user
                    WHERE Username = @username 
                    AND PasswordHash = @password
                    AND IsActive = 1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["UserID"]);
                            string fullName = reader["FullName"].ToString();
                            string role = reader["Role"].ToString();
                            int? doctorId = reader["DoctorID"] != DBNull.Value
                                ? (int?)Convert.ToInt32(reader["DoctorID"])
                                : null;

                            return (true, userId, fullName, role, doctorId);
                        }
                    }
                }
            }
            return (false, 0, null, null, null);
        }
    }
}
