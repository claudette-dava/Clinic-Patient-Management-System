using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class DoctorModel
    {
        private readonly string _connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public class Doctor
        {
            public int DoctorID { get; set; }
            public string Name { get; set; }
            public string Specialization { get; set; }
            public string ContactNo { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
        }


        public List<Doctor> GetAllDoctors()
        {
            var doctors = new List<Doctor>();

            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();


                string query = @"SELECT DoctorID, Name, SpecializationName, 
                                 ContactNumber, Email, Status
                                 FROM tbl_doctor 
                                 INNER JOIN tbl_specialization 
                                 ON tbl_doctor.SpecializationID = tbl_specialization.SpecializationID";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    doctors.Add(new Doctor
                    {
                        DoctorID = (int)reader["DoctorID"],
                        Name = reader["Name"].ToString(),
                        Specialization = reader["SpecializationName"].ToString(),
                        ContactNo = reader["ContactNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Status = reader["Status"].ToString()
                    });
                }
            }

            return doctors;
        }
        public void UpdateDoctor(int id, string name, int specializationId, string contact, string email, string status)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                string query = @"UPDATE tbl_doctor 
                         SET Name = @Name, SpecializationID = @SpecID, ContactNumber = @Contact, 
                             Email = @Email, Status = @Status 
                         WHERE DoctorID = @ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@SpecID", specializationId);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
        }
        public int GetSpecializationIdByName(string name)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                string query = "SELECT SpecializationID FROM tbl_specialization WHERE SpecializationName = @Name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
        public bool CanDeleteDoctor(int doctorID)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();

                
                string query = @"
            SELECT 
                (SELECT COUNT(*) FROM tbl_appointment WHERE DoctorID = @DoctorID) +
                (SELECT COUNT(*) FROM tbl_schedule WHERE DoctorID = @DoctorID)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                    int count = (int)cmd.ExecuteScalar();
                    return count == 0; 
                }
            }
        }
        public void SoftDeleteDoctor(int doctorID)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();

                string query = "UPDATE tbl_doctor SET Status = 'Inactive' WHERE DoctorID = @DoctorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Doctor> SearchDoctors(string keyword)
        {
            var doctors = new List<Doctor>();

            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();

                string query = @"
            SELECT d.DoctorID, d.Name, s.SpecializationName, d.ContactNumber, d.Email, d.Status
            FROM tbl_doctor d
            INNER JOIN tbl_specialization s ON d.SpecializationID = s.SpecializationID
            WHERE d.Status = 'Active' 
              AND (d.Name LIKE @Keyword OR s.SpecializationName LIKE @Keyword)
            ORDER BY d.Name ASC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        doctors.Add(new Doctor
                        {
                            DoctorID = (int)reader["DoctorID"],
                            Name = reader["Name"].ToString(),
                            Specialization = reader["SpecializationName"].ToString(),
                            ContactNo = reader["ContactNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }

            return doctors;
        }


    }
}
