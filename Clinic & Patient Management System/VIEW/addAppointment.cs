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

namespace Clinic___Patient_Management_System.VIEW
{

        public partial class addAppointment : Form, IAddAppointmentView
        {
        private readonly AddAppointmentPresenter _presenter;
        public event Action AppointmentSaved;

        public int ScheduleID { get; private set; }
        public int TimeSlotID { get; private set; }
        public int DoctorID { get; private set; }
        public string DoctorName { get; private set; }
        public DateTime ScheduleDate { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public int SelectedPatientID => cmb_patient.SelectedIndex >= 0 ? Convert.ToInt32(cmb_patient.SelectedValue) : -1;
        public string Status => cmb_status.SelectedItem?.ToString();




        public addAppointment(int scheduleID, int timeslotID, int doctorID,  string doctorName, string scheduleDate, string startTime, string endTime)
            {
                InitializeComponent();
                panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
            btn_addPatient.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
            _presenter = new AddAppointmentPresenter(this);

            ScheduleID = scheduleID;
            TimeSlotID = timeslotID;
            DoctorID = doctorID;
            DoctorName = doctorName;
            ScheduleDate = DateTime.Parse(scheduleDate);
            StartTime = DateTime.Parse(startTime);
            EndTime = DateTime.Parse(endTime);

            txt_doctor.Text = DoctorName;
            txt_sched.Text = ScheduleDate.ToShortDateString();
            txt_start.Text = StartTime.ToString("h:mm tt");
            txt_end.Text = EndTime.ToString("h:mm tt");
            LoadStatus();
            _presenter.LoadPatients();


        }

        public void SetPatientList(DataTable patients)
        {
            cmb_patient.DisplayMember = "Name";
            cmb_patient.ValueMember = "PatientID";
            cmb_patient.DataSource = patients;
            cmb_patient.SelectedIndex = -1;
        }

        private void LoadStatus()
        {
            cmb_status.Items.Clear();
            cmb_status.Items.Add("Scheduled");
            cmb_status.Items.Add("Completed");
            cmb_status.Items.Add("Cancelled");
            cmb_status.SelectedIndex = -1;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseForm() => this.Close();

        public void TriggerAppointmentSaved() => AppointmentSaved?.Invoke();


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            _presenter.SaveAppointment();
        }

      
    }
}
