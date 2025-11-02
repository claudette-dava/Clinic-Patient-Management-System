using Clinic___Patient_Management_System.MODEL;
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
using static Clinic___Patient_Management_System.MODEL.PatientModel;

namespace Clinic___Patient_Management_System.VIEW
{ 

    public partial class PatientRecord : Form, IPatientRecordView
    {
        private readonly PatientRecordPresenter _presenter;
        public PatientRecord()
        {
            InitializeComponent();
            _presenter = new PatientRecordPresenter(this);
            _presenter.LoadPatients();
            txt_searchPatient.Text = "   Search";
            txt_searchPatient.ForeColor = Color.Gray;

        }

        public void DisplayPatients(List<Patient> patients)
        {
            dgv_patientRecord.Rows.Clear();

            foreach (var p in patients)
            {
                dgv_patientRecord.Rows.Add(
                    p.PatientID,
                    p.Name,
                    p.Age,
                    p.Address,
                    p.Sex,
                    p.ContactNo,
                    p.Email,
                    "Edit", "Delete"
                );
            }
        }

        private void txt_searchPatient_Enter(object sender, EventArgs e)
        {
            if (txt_searchPatient.Text == "   Search")
            {
                txt_searchPatient.Text = "   "; // remove placeholder
                txt_searchPatient.ForeColor = Color.Black; // set text color to black
            }
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_searchPatient_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchPatient.Text))
            {
                txt_searchPatient.Text = "   Search"; // restore placeholder
                txt_searchPatient.ForeColor = Color.Gray; // make it gray again
            }
        }

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            addPatient addPatientForm = new addPatient(this);

            // 🟢 Subscribe to the event from addPatient
            addPatientForm.PatientSaved += () =>
            {
                _presenter.LoadPatients(); // refresh patient list automatically
            };

            addPatientForm.ShowDialog();
        }

        private void dgv_patientRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int patientId = Convert.ToInt32(dgv_patientRecord.Rows[e.RowIndex].Cells["PatientID"].Value);

            switch (e.ColumnIndex)
            {
                case 7:
                    addPatient frm = new addPatient(this);

         
                    string name = dgv_patientRecord.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    string age = dgv_patientRecord.Rows[e.RowIndex].Cells["Age"].Value.ToString();
                    string address = dgv_patientRecord.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                    string sex = dgv_patientRecord.Rows[e.RowIndex].Cells["Sex"].Value.ToString();
                    string contact = dgv_patientRecord.Rows[e.RowIndex].Cells["ContactNo"].Value.ToString();
                    string email = dgv_patientRecord.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                    // Split the address into its parts
                    string[] parts = address.Split(',');
                    string streetNo = parts.Length > 0 ? parts[0].Trim() : "";
                    string brgy = parts.Length > 1 ? parts[1].Trim() : "";
                    string city = parts.Length > 2 ? parts[2].Trim() : "";
                    string province = parts.Length > 3 ? parts[3].Trim() : "";

                    // Pass data to the Add/Edit form
                    frm.PatientID = patientId;
                    frm.FillPatientData(name, age, province, city, brgy, streetNo, sex, contact, email);

                    frm.ShowDialog();
                    break;

                case 8: // DELETE PATIENT
                    _presenter.DeletePatient(patientId);
                    break;
            }
        }
    }
}
   
