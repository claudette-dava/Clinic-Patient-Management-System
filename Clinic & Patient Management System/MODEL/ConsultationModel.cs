using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class ConsultationModel
    {
        private readonly string connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public DataTable GetAllConsultations()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = @"
                    SELECT 
                    c.ConsultationID,
                    c.AppointmentID,
                    c.PatientID,
                    c.DoctorID,
                    p.Name AS PatientName,
                    d.Name AS DoctorName,
                    c.ConsultationDate,
                    c.ChiefComplaint,
                    c.Diagnosis,
                    c.Treatment,
                    c.FollowUpRequired,
                    c.FollowUpDate
                FROM tbl_consultation c
                INNER JOIN tbl_patientRecord p ON c.PatientID = p.PatientID
                INNER JOIN tbl_doctor d ON c.DoctorID = d.DoctorID
                ORDER BY c.ConsultationDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }
    }
}
