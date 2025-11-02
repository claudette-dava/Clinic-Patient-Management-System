using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class AddAppointmentModel
    {
        private readonly string _connection =
           @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";

        public DataTable GetPatients()
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT PatientID, Name FROM tbl_patientRecord", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void SaveAppointment(int scheduleID, int timeslotID, int doctorID, int patientID,
            DateTime scheduleDate, TimeSpan start, TimeSpan end, string status)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();

                // Insert appointment record
                string insertQuery = @"INSERT INTO tbl_appointment 
                               (ScheduleID, TimeSlotID, DoctorID, PatientID, ScheduleDate, StartTime, EndTime, Status)
                               VALUES 
                               (@ScheduleID, @TimeSlotID, @DoctorID, @PatientID, @ScheduleDate, @StartTime, @EndTime, @Status)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);
                    cmd.Parameters.AddWithValue("@TimeSlotID", timeslotID);
                    cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    cmd.Parameters.AddWithValue("@ScheduleDate", scheduleDate);
                    cmd.Parameters.AddWithValue("@StartTime", start);
                    cmd.Parameters.AddWithValue("@EndTime", end);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();
                }

                // Update timeslot to booked
                string updateSlot = "UPDATE tbl_timeslot SET Status='Booked' WHERE TimeslotID=@TimeslotID";
                using (SqlCommand cmd = new SqlCommand(updateSlot, con))
                {
                    cmd.Parameters.AddWithValue("@TimeslotID", timeslotID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
