using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class MedicalHistoryModel
    {
        private readonly string connection =
            @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";

        // ✅ Check if history already exists for this patient
        public bool HasMedicalHistory(int patientId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM tbl_medicalHistory WHERE PatientID = @PatientID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // ✅ Create an empty medical history row if none exists
        public void CreateEmptyMedicalHistory(int patientId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = "INSERT INTO tbl_medicalHistory (PatientID) VALUES (@PatientID)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ Get a single patient's medical history
        public DataRow GetMedicalHistory(int patientId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = "SELECT * FROM tbl_medicalHistory WHERE PatientID = @PatientID";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@PatientID", patientId);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table.Rows.Count > 0 ? table.Rows[0] : null;
                }
            }
        }

        public void UpdateMedicalHistory(
           int patientId,
           string allergies,
           string medications,
           string pastIllnesses,
           string chronicConditions,
           string notes)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = @"
                    UPDATE tbl_medicalHistory
                    SET 
                        Allergies = @Allergies,
                        Medications = @Medications,
                        PastIllnesses = @PastIllnesses,
                        ChronicConditions = @ChronicConditions,
                        Notes = @Notes,
                        LastUpdated = GETDATE()
                    WHERE PatientID = @PatientID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.Parameters.AddWithValue("@Allergies", (object)allergies ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Medications", (object)medications ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PastIllnesses", (object)pastIllnesses ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ChronicConditions", (object)chronicConditions ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
