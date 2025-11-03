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
using static Clinic___Patient_Management_System.MODEL.DoctorModel;
using static Clinic___Patient_Management_System.MODEL.PatientModel;

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class addConsulation : Form, IAddConsultationView
    {
        private readonly AddConsultationPresenter _presenter;
        public event Action ConsultationSaved;

        public int AppointmentID { get; private set; }
        public int DoctorID { get; private set; }
        public int PatientID { get; private set; }

        public string Temperature => txt_temperature.Text;
        public string BloodPressure => txt_bp.Text;
        public string Weight => txt_weight.Text;
        public string Height => txt_height.Text;
        public string HeartRate => txt_hr.Text;
        public string ChiefComplaint => txt_complaint.Text;
        public string Diagnosis => txt_diagnosis.Text;
        public string Treatment => txt_treatment.Text;
        public string Prescription => txt_prescription.Text;
        public string Notes => txt_notes.Text;
        public bool FollowUpRequired => chk_followup.Checked;
        public DateTime? FollowUpDate => chk_followup.Checked ? dtp_followUpDate.Value : (DateTime?)null;

        public addConsulation(int appointmentID, int doctorID, int patientID, string doctorName, string patientName, string appointmentDate)
        {
            InitializeComponent();
            _presenter = new AddConsultationPresenter(this);

            AppointmentID = appointmentID;
            DoctorID = doctorID;
            PatientID = patientID;

            txt_patientName.Text = patientName;
            txt_doctorName.Text = doctorName;
            txt_appointmentDate.Text = appointmentDate;
            txt_consultationDate.Text = DateTime.Now.ToShortDateString();
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
            btn_addPatient.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Consultation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseForm() => this.Close();

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            _presenter.SaveConsultation();
        }
        public void NotifyConsultationSaved()
        {
            ConsultationSaved?.Invoke();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addConsulation_Load(object sender, EventArgs e)
        {

        }

        private void chk_followup_CheckedChanged(object sender, EventArgs e)
        {
            dtp_followUpDate.Enabled = chk_followup.Checked;
        }
    }
}
