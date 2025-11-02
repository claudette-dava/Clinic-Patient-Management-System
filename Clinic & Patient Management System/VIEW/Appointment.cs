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

                // ✅ Match the actual column order of your DataGridView
                dgv_appointmentRecord.Rows.Add(
                    appointmentID,    // Appointment ID
                    patientName,      // Patient Name
                    doctorName,       // Doctor Name
                    scheduleID,       // Schedule ID (hidden)
                    timeslotID,       // TimeSlot ID (hidden)
                    scheduleDate,     // Appointment Date
                    startTime,        // Start Time
                    endTime,          // End Time
                    status,           // Status
                    "Edit",           // Edit column
                    "Delete"          // Delete column
                );
            }

            // Hide ID columns safely
            if (dgv_appointmentRecord.Columns.Contains("scheduleID"))
                dgv_appointmentRecord.Columns["scheduleID"].Visible = false;

            if (dgv_appointmentRecord.Columns.Contains("timeSlotID"))
                dgv_appointmentRecord.Columns["timeSlotID"].Visible = false;
        }


        private void btn_addAppointment_Click(object sender, EventArgs e)
        {
           
        }
     

    }
}
