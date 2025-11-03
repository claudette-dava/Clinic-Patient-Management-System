using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.MODEL
{
    public class PaymentModel
    {
        private readonly string connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public void AddPayment(int appointmentId, int patientId, int doctorId, decimal amount,
                              string method, string status, string notes)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = @"
                    INSERT INTO tbl_payment 
                    (AppointmentID, PatientID, DoctorID, Amount, PaymentMethod, Status, Notes)
                    VALUES (@AppointmentID, @PatientID, @DoctorID, @Amount, @Method, @Status, @Notes)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Method", method);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? DBNull.Value : (object)notes);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = @"
                    SELECT 
                        p.PaymentID,
                        pr.Name AS PatientName,
                        d.Name AS DoctorName,
                        a.ScheduleDate AS AppointmentDate,
                        p.Amount,
                        p.PaymentMethod,
                        p.Status,
                        p.PaymentDate,
                        p.Notes
                    FROM tbl_payment p
                    INNER JOIN tbl_appointment a ON p.AppointmentID = a.AppointmentID
                    INNER JOIN tbl_patientRecord pr ON p.PatientID = pr.PatientID
                    INNER JOIN tbl_doctor d ON p.DoctorID = d.DoctorID
                    ORDER BY p.PaymentDate DESC";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        // ✅ Get payment details for a specific appointment (optional)
        public DataRow GetPaymentByAppointment(int appointmentId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = @"
                    SELECT TOP 1 * FROM tbl_payment WHERE AppointmentID = @AppointmentID";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@AppointmentID", appointmentId);
                    adapter.Fill(dt);
                }
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // ✅ Update payment (if needed)
        public void UpdatePayment(int paymentId, decimal amount, string method, string status, string notes)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = @"
                    UPDATE tbl_payment 
                    SET Amount = @Amount,
                        PaymentMethod = @Method,
                        Status = @Status,
                        Notes = @Notes
                    WHERE PaymentID = @PaymentID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", paymentId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Method", method);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? DBNull.Value : (object)notes);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ Delete payment record (optional)
        public void DeletePayment(int paymentId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = "DELETE FROM tbl_payment WHERE PaymentID = @PaymentID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", paymentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
