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
                    row["PatientName"],
                    row["DoctorName"],
                    Convert.ToDateTime(row["ConsultationDate"]).ToShortDateString(),
                    row["ChiefComplaint"].ToString(),
                    row["Diagnosis"].ToString(),
                    row["Treatment"].ToString(),
                    followUpText,
                    followUpDate,
                    "View"
                );
            }

            // Hide ID columns if present
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
            if (e.RowIndex < 0) return;

            string columnName = dgv_consultation.Columns[e.ColumnIndex].Name;

            if (columnName == "ViewDetails")
            {
                int consultationID = Convert.ToInt32(dgv_consultation.Rows[e.RowIndex].Cells["ConsultationID"].Value);

                ViewConsultation frm = new ViewConsultation(consultationID);
                frm.ShowDialog();
            }
        }
    }
}
