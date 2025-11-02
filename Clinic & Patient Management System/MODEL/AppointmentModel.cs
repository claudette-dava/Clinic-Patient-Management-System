using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class AppointmentModel
    {
        private readonly string _connection =
           @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public DataTable GetAppointments()
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();

                string query = @"
                    SELECT a.AppointmentID, a.ScheduleID, a.TimeSlotID,
                           d.Name AS DoctorName, p.Name AS PatientName, 
                           s.ScheduleDate, a.StartTime, a.EndTime, a.Status
                    FROM tbl_appointment a
                    INNER JOIN tbl_schedule s ON a.ScheduleID = s.ScheduleID
                    INNER JOIN tbl_doctor d ON a.DoctorID = d.DoctorID
                    INNER JOIN tbl_patientRecord p ON a.PatientID = p.PatientID
                    ORDER BY s.ScheduleDate, a.StartTime";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
