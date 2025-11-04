using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class ScheduleDoctorModel
    {
        private readonly string _connection =
           @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";

        //for gettin doctor sched pu i2 
        public DataTable GetSchedules()
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                string query = @"
                    SELECT s.ScheduleID, s.DoctorID, d.Name, 
                           s.ScheduleDate, s.StartTime, s.EndTime, s.Status
                    FROM tbl_schedule s
                    INNER JOIN tbl_doctor d ON s.DoctorID = d.DoctorID";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public (TimeSpan, TimeSpan) GetScheduleTimeRange(int scheduleID)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT StartTime, EndTime FROM tbl_schedule WHERE ScheduleID=@ScheduleID", con);
                cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return ((TimeSpan)reader["StartTime"], (TimeSpan)reader["EndTime"]);
                    }
                }
            }

            return (TimeSpan.Zero, TimeSpan.Zero);
        }
        public int CountExistingTimeslots(int scheduleID)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM tbl_timeslot WHERE ScheduleID=@ScheduleID", con);
                cmd.Parameters.AddWithValue("@ScheduleID", scheduleID);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void InsertTimeslot(int scheduleID, TimeSpan start, TimeSpan end)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO tbl_timeslot (ScheduleID, StartTime, EndTime, Status) VALUES (@ScheduleID, @StartTime, @EndTime, 'Available')",
                    con);
                insertCmd.Parameters.AddWithValue("@ScheduleID", scheduleID);
                insertCmd.Parameters.AddWithValue("@StartTime", start);
                insertCmd.Parameters.AddWithValue("@EndTime", end);
                insertCmd.ExecuteNonQuery();
            }
        }
        public DataTable GetTimeslots(int scheduleID)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                string query = @"SELECT TimeslotID, StartTime, EndTime, Status 
                                 FROM tbl_timeslot 
                                 WHERE ScheduleID=@ScheduleID 
                                 ORDER BY StartTime";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@ScheduleID", scheduleID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable GetSchedulesForDoctorAndDate(int doctorID, DateTime followUpDate)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                string query = @"
            SELECT s.ScheduleID, s.DoctorID, d.Name, 
                   s.ScheduleDate, s.StartTime, s.EndTime, s.Status
            FROM tbl_schedule s
            INNER JOIN tbl_doctor d ON s.DoctorID = d.DoctorID
            WHERE s.DoctorID = @DoctorID 
              AND CAST(s.ScheduleDate AS DATE) = @FollowUpDate";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@DoctorID", doctorID);
                da.SelectCommand.Parameters.AddWithValue("@FollowUpDate", followUpDate.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
