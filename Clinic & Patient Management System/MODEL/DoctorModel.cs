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

                // Removed RoomNumber
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
    }
}
