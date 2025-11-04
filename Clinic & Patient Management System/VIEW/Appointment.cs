using Clinic___Patient_Management_System.PRESENTER;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic___Patient_Management_System.VIEW;

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class Appointment : Form, IAppointmentView
    {
        private readonly AppointmentPresenter _presenter;
        public Appointment()
        {
            InitializeComponent();
            _presenter = new AppointmentPresenter(this);
            txt_searchAppointment.Text = "   Search";
            txt_searchAppointment.ForeColor = Color.Gray;
            _presenter.LoadAppointments();
        }

        private void txt_searchAppointment_Enter(object sender, EventArgs e)
        {
            if (txt_searchAppointment.Text == "   Search")
            {
                txt_searchAppointment.Text = "   "; // remove placeholder
                txt_searchAppointment.ForeColor = Color.Black; // set text color to black
            }
        }

        private void txt_searchAppointment_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchAppointment.Text))
            {
                txt_searchAppointment.Text = "   Search"; // restore placeholder
                txt_searchAppointment.ForeColor = Color.Gray; // make it gray again
            }
        }
        public void DisplayAppointments(DataTable appointments)
        {
            dgv_appointmentRecord.Rows.Clear();

            string role = CurrentUser.Role?.Trim();

            foreach (DataRow row in appointments.Rows)
            {
                int appointmentID = Convert.ToInt32(row["AppointmentID"]);
                int scheduleID = Convert.ToInt32(row["ScheduleID"]);
                int timeslotID = Convert.ToInt32(row["TimeSlotID"]);

                string doctorName = row["DoctorName"].ToString();
                string patientName = row["PatientName"].ToString();
                string scheduleDate = Convert.ToDateTime(row["ScheduleDate"]).ToShortDateString();

                TimeSpan startTS = (TimeSpan)row["StartTime"];
                TimeSpan endTS = (TimeSpan)row["EndTime"];
                string startTime = DateTime.Today.Add(startTS).ToString("h:mm tt");
                string endTime = DateTime.Today.Add(endTS).ToString("h:mm tt");

                string status = row["Status"].ToString();

                int index = dgv_appointmentRecord.Rows.Add(
                    appointmentID,
                    patientName,
                    doctorName,
                    scheduleID,
                    timeslotID,
                    scheduleDate,
                    startTime,
                    endTime,
                    status,
                    "Add Consultation",
                    "Pay",
                    "Cancel",
                    "Delete",
                    "Add Consultation"
                );

                DataGridViewRow r = dgv_appointmentRecord.Rows[index];

                // 🎨 Style cancelled rows
                if (status == "Cancelled")
                {
                    r.DefaultCellStyle.ForeColor = Color.Gray;
                    r.DefaultCellStyle.Font = new Font(dgv_appointmentRecord.Font, FontStyle.Italic);
                }

                if (role == "Doctor")
                {
                   
                    string[] restrictedColumns = { "Pay", "Cancel", "Delete" };

                    foreach (string colName in restrictedColumns)
                    {
                        if (dgv_appointmentRecord.Columns.Contains(colName))
                        {
                            var cell = r.Cells[colName];
                            cell.Style.ForeColor = Color.DarkGray;
                            cell.ReadOnly = true;
                        }
                    }
                }
                else if (role == "Staff")
                {
                  
                    if (r.Cells["AddConsultation"] != null)
                    {
                        r.Cells["AddConsultation"].Style.ForeColor = Color.DarkGray;
                        r.Cells["AddConsultation"].ReadOnly = true;
                    }
                }

            }

            if (dgv_appointmentRecord.Columns.Contains("scheduleID"))
                dgv_appointmentRecord.Columns["scheduleID"].Visible = false;

            if (dgv_appointmentRecord.Columns.Contains("timeSlotID"))
                dgv_appointmentRecord.Columns["timeSlotID"].Visible = false;
        }



        private void btn_addAppointment_Click(object sender, EventArgs e)
        {

        }

        private void dgv_appointmentRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            string columnName = dgv_appointmentRecord.Columns[e.ColumnIndex].Name;
            string status = dgv_appointmentRecord.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            string role = CurrentUser.Role?.Trim();


            if (role == "Doctor" && columnName != "AddConsultation")
            {
                MessageBox.Show("Doctors can only add consultations.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (role == "Staff" && columnName == "AddConsultation")
            {
                MessageBox.Show("Staff cannot add consultations.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            
            if (status == "Cancelled" && columnName != "Delete")
            {
                MessageBox.Show("This appointment has been cancelled and cannot be modified.",
                    "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ ADD CONSULTATION
            if (columnName == "AddConsultation")
            {
                if (status != "Scheduled")
                {
                    MessageBox.Show("Consultation can only be added for scheduled appointments.",
                        "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int appointmentID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["AppointmentID"].Value);
                int scheduleID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["ScheduleID"].Value);
                int timeslotID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["TimeSlotID"].Value);
                string doctorName = dgv_appointmentRecord.Rows[e.RowIndex].Cells["DoctorName"].Value.ToString();
                string patientName = dgv_appointmentRecord.Rows[e.RowIndex].Cells["patientID"].Value.ToString();
                string scheduleDate = dgv_appointmentRecord.Rows[e.RowIndex].Cells["date"].Value.ToString();

                int doctorID = GetDoctorID(appointmentID);
                int patientID = GetPatientID(appointmentID);

                addConsulation frm = new addConsulation(
                    appointmentID,
                    doctorID,
                    patientID,
                    doctorName,
                    patientName,
                    scheduleDate
                );

                frm.ConsultationSaved += () =>
                {
                    UpdateAppointmentStatus(appointmentID, "Completed");
                    _presenter.LoadAppointments(); // refresh grid after update
                };

                frm.ShowDialog();
            }

            // 💳 PAYMENT
            else if (columnName == "Payment")
            {
                if (status != "Completed")
                {
                    MessageBox.Show("Only completed consultations can proceed to payment.",
                        "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int appointmentID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["AppointmentID"].Value);
                string patientName = dgv_appointmentRecord.Rows[e.RowIndex].Cells["patientID"].Value.ToString();
                string doctorName = dgv_appointmentRecord.Rows[e.RowIndex].Cells["DoctorName"].Value.ToString();
                string appointmentDate = dgv_appointmentRecord.Rows[e.RowIndex].Cells["date"].Value.ToString();

                int doctorID = GetDoctorID(appointmentID);
                int patientID = GetPatientID(appointmentID);

                addPayment frm = new addPayment(appointmentID, patientID, doctorID, patientName, doctorName, appointmentDate);
                frm.PaymentSaved += () => _presenter.LoadAppointments();
                frm.ShowDialog();
            }

            // ❌ CANCEL
            else if (columnName == "Cancel")
            {
                if (status == "Completed")
                {
                    MessageBox.Show("Completed appointments cannot be cancelled.",
                        "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to cancel this appointment?",
                    "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int appointmentID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["AppointmentID"].Value);
                    int timeslotID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["TimeSlotID"].Value);

                    CancelAppointment(appointmentID, timeslotID);
                    _presenter.LoadAppointments(); // Refresh grid
                }
            }

            // 🗑️ DELETE (Allowed for Cancelled only)
            else if (columnName == "Delete")
            {
                if (status != "Cancelled")
                {
                    MessageBox.Show("Only cancelled appointments can be deleted.",
                        "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to permanently delete this cancelled appointment?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    int appointmentID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["AppointmentID"].Value);
                    DeleteAppointment(appointmentID);
                    _presenter.LoadAppointments(); // refresh grid after delete
                }
            }

        }
        private int GetDoctorID(int appointmentID)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DoctorID FROM tbl_appointment WHERE AppointmentID = @id", con);
                cmd.Parameters.AddWithValue("@id", appointmentID);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int GetPatientID(int appointmentID)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PatientID FROM tbl_appointment WHERE AppointmentID = @id", con);
                cmd.Parameters.AddWithValue("@id", appointmentID);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private void UpdateAppointmentStatus(int appointmentID, string newStatus)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tbl_appointment SET Status = @status WHERE AppointmentID = @id", con);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", appointmentID);
                cmd.ExecuteNonQuery();
            }
        }
        private void CancelAppointment(int appointmentID, int timeslotID)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;"))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 1️⃣ Update appointment status
                    string updateAppointment = "UPDATE tbl_appointment SET Status = 'Cancelled' WHERE AppointmentID = @id";
                    using (SqlCommand cmd1 = new SqlCommand(updateAppointment, con, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@id", appointmentID);
                        cmd1.ExecuteNonQuery();
                    }

                    // 2️⃣ Free up the timeslot
                    string updateTimeslot = "UPDATE tbl_timeslot SET Status = 'Available' WHERE TimeslotID = @tid";
                    using (SqlCommand cmd2 = new SqlCommand(updateTimeslot, con, transaction))
                    {
                        cmd2.Parameters.AddWithValue("@tid", timeslotID);
                        cmd2.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Appointment cancelled successfully.\nTimeslot is now available again.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error cancelling appointment: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DeleteAppointment(int appointmentID)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;"))
            {
                con.Open();
                try
                {
                    string query = "DELETE FROM tbl_appointment WHERE AppointmentID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", appointmentID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cancelled appointment deleted successfully.",
                        "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting appointment: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
