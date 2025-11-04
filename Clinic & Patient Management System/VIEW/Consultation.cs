using Clinic___Patient_Management_System.PRESENTER;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class Consultation : Form, IConsultationView
    {
        private readonly ConsultationPresenter _presenter;
        public Consultation()
        {
            InitializeComponent();


            txt_searchConsultation.Text = "   Search";
            txt_searchConsultation.ForeColor = Color.Gray;
            _presenter = new ConsultationPresenter(this);
            _presenter.LoadConsultations();
        }

        public void DisplayConsultations(DataTable consultations)
        {
            dgv_consultation.Rows.Clear();

            foreach (DataRow row in consultations.Rows)
            {
                string followUpText = Convert.ToBoolean(row["FollowUpRequired"]) ? "Yes" : "No";
                string followUpDate = row["FollowUpDate"] == DBNull.Value
                    ? ""
                    : Convert.ToDateTime(row["FollowUpDate"]).ToShortDateString();

                dgv_consultation.Rows.Add(
                    row["ConsultationID"],
                    row["AppointmentID"],
                     row["PatientID"],
                    row["DoctorID"],
                    row["PatientName"],
                    row["DoctorName"],
                    Convert.ToDateTime(row["ConsultationDate"]).ToShortDateString(),
                    row["ChiefComplaint"].ToString(),
                    row["Diagnosis"].ToString(),
                    row["Treatment"].ToString(),
                    followUpText,
                    followUpDate,
                    "View Consultation Details",
                    "Schedule Now"
                );
            }
            string role = CurrentUser.Role?.Trim();

            DataGridViewRow r = dgv_consultation.Rows[dgv_consultation.Rows.Count - 1];

            // 🚫 Role-based button restrictions
            if (role == "Doctor")
            {
                // Disable Schedule Now
                if (r.Cells["FollowUpAppointment"] != null)
                {
                    r.Cells["FollowUpAppointment"].Style.ForeColor = Color.DarkGray;
                    r.Cells["FollowUpAppointment"].ReadOnly = true;
                }
            }
            else if (role == "Staff")
            {
                // Disable View Consultation Details
                if (r.Cells["ViewDetails"] != null)
                {
                    r.Cells["ViewDetails"].Style.ForeColor = Color.DarkGray;
                    r.Cells["ViewDetails"].ReadOnly = true;
                }
            }

            if (dgv_consultation.Columns.Contains("DoctorID"))
                dgv_consultation.Columns["DoctorID"].Visible = false;
            if (dgv_consultation.Columns.Contains("PatientID"))
                dgv_consultation.Columns["PatientID"].Visible = false; 
            if (dgv_consultation.Columns.Contains("ConsultationID"))
                dgv_consultation.Columns["ConsultationID"].Visible = false;  
            if (dgv_consultation.Columns.Contains("AppointmentID"))
                dgv_consultation.Columns["AppointmentID"].Visible = false; 
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_searchConsultation_Enter(object sender, EventArgs e)
        {
            if (txt_searchConsultation.Text == "   Search")
            {
                txt_searchConsultation.Text = "   "; // remove placeholder
                txt_searchConsultation.ForeColor = Color.Black; // set text color to black
            }
        }

        private void txt_searchConsultation_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchConsultation.Text))
            {
                txt_searchConsultation.Text = "   Search"; // restore placeholder
                txt_searchConsultation.ForeColor = Color.Gray; // make it gray again
            }
        }

        private void dgv_consultation_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {
            string role = CurrentUser.Role?.Trim();
            if (e.RowIndex < 0) return;

            string columnName = dgv_consultation.Columns[e.ColumnIndex].Name;

            if (role == "Doctor" && columnName == "FollowUpAppointment")
            {
                MessageBox.Show("Doctors cannot schedule follow-up appointments.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (role == "Staff" && columnName == "ViewDetails")
            {
                MessageBox.Show("Staff cannot view consultation details.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (columnName == "ViewDetails")
            {
                int consultationID = Convert.ToInt32(dgv_consultation.Rows[e.RowIndex].Cells["ConsultationID"].Value);
                ViewConsultation frm = new ViewConsultation(consultationID);
                frm.ShowDialog();
            }
            else if (columnName == "FollowUpAppointment")
            {
                bool followUpRequired = dgv_consultation.Rows[e.RowIndex].Cells["FollowUpRequired"].Value?.ToString() == "Yes";
                string followUpDateText = dgv_consultation.Rows[e.RowIndex].Cells["FollowUpDate"].Value?.ToString();

                if (!followUpRequired)
                {
                    MessageBox.Show("Follow-up is not required for this consultation.",
                        "No Follow-Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (string.IsNullOrEmpty(followUpDateText))
                {
                    MessageBox.Show("Follow-up date not set. Please check consultation details.",
                        "Missing Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime followUpDate = Convert.ToDateTime(followUpDateText);
                int doctorID = Convert.ToInt32(dgv_consultation.Rows[e.RowIndex].Cells["DoctorID"].Value);
                int patientID = Convert.ToInt32(dgv_consultation.Rows[e.RowIndex].Cells["PatientID"].Value);

                // ✅ Open filtered ScheduleDoctor
                ScheduleDoctor scheduleForm = new ScheduleDoctor(doctorID, patientID, followUpDate);
                scheduleForm.ShowDialog();
            }
        }
    }
}
