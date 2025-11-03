using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class AddConsultationModel
    {
        private readonly string _connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public void SaveConsultation(
          int appointmentID,
          int doctorID,
          int patientID,
          string temperature,
          string bp,
          string weight,
          string height,
          string heartRate,
          string complaint,
          string diagnosis,
          string treatment,
          string prescription,
          string notes,
          bool followUpRequired,
          DateTime? followUpDate)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();

                string query = @"
                    INSERT INTO tbl_consultation (
                        AppointmentID, DoctorID, PatientID, 
                        Temperature, BloodPressure, Weight, Height, HeartRate,
                        ChiefComplaint, Diagnosis, Treatment, Prescription, Notes,
                        FollowUpRequired, FollowUpDate
                    )
                    VALUES (
                        @AppointmentID, @DoctorID, @PatientID,
                        @Temperature, @BloodPressure, @Weight, @Height, @HeartRate,
                        @ChiefComplaint, @Diagnosis, @Treatment, @Prescription, @Notes,
                        @FollowUpRequired, @FollowUpDate
                    )";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    cmd.Parameters.AddWithValue("@Temperature", (object)temperature ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BloodPressure", (object)bp ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Weight", (object)weight ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Height", (object)height ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HeartRate", (object)heartRate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ChiefComplaint", (object)complaint ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Diagnosis", (object)diagnosis ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Treatment", (object)treatment ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prescription", (object)prescription ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Notes", (object)notes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FollowUpRequired", followUpRequired);
                    cmd.Parameters.AddWithValue("@FollowUpDate", (object)followUpDate ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
