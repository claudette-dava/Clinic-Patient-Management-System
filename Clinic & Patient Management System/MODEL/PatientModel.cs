using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Clinic___Patient_Management_System.MODEL
{
    public class PatientModel
    {
        private readonly string _connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public class Patient
        {
            public int PatientID { get; set; }
            public string Name { get; set; }
            public string Age { get; set; }
            public string Address { get; set; }
            public string Sex { get; set; }
            public string ContactNo { get; set; }
            public string Email { get; set; }
        }

        public List<Patient> GetAllPatients()
        {
            var patients = new List<Patient>();

            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_patientRecord", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    patients.Add(new Patient
                    {
                        PatientID = (int)reader["PatientID"],
                        Name = reader["Name"].ToString(),
                        Age = reader["Age"].ToString(),
                        Address = reader["Address"].ToString(),
                        Sex = reader["Sex"].ToString(),
                        ContactNo = reader["ContactNo"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }

            return patients;
        }

        public void DeletePatient(int patientID)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_patientRecord WHERE PatientID=@PatientID", con))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public bool CanDeletePatient(int patientID)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM tbl_appointment WHERE PatientID=@PatientID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    int count = (int)cmd.ExecuteScalar();
                    return count == 0;
                }
            }
        }


    }
}
