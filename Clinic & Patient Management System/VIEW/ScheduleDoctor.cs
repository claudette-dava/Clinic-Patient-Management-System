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
    public partial class ScheduleDoctor : Form, IScheduleDoctorView
    {
        private readonly ScheduleDoctorPresenter _presenter;
        private int? _doctorID;
        private int? _patientID;
        private DateTime? _followUpDate;

        public ScheduleDoctor()
        {
            InitializeComponent();
            _presenter = new ScheduleDoctorPresenter(this);
            txt_searchPayment.Text = "   Search";   
            txt_searchPayment.ForeColor = Color.Gray;
            _presenter.LoadSchedules(); // load all schedules normally
        }

        // 2️⃣ Overloaded (used by Consultation “Schedule Now”)
        public ScheduleDoctor(int doctorID, int patientID, DateTime followUpDate)
        {
            InitializeComponent();
            _presenter = new ScheduleDoctorPresenter(this);
            _doctorID = doctorID;
            _patientID = patientID;
            _followUpDate = followUpDate;
            txt_searchPayment.Text = "   Search";
            txt_searchPayment.ForeColor = Color.Gray;
            _presenter.LoadSchedulesForDoctor(doctorID, followUpDate); // filtered load
        }
        public void DisplaySchedules(DataTable schedules)
        {
            dgv_schedule.Rows.Clear();
            foreach (DataRow row in schedules.Rows)
            {
                dgv_schedule.Rows.Add(
                    row["ScheduleID"].ToString(),
                    row["DoctorID"].ToString(),
                    row["Name"].ToString(),
                    Convert.ToDateTime(row["ScheduleDate"]).ToShortDateString(),
                    DateTime.Parse(row["StartTime"].ToString()).ToString("hh:mm tt"),
                    DateTime.Parse(row["EndTime"].ToString()).ToString("hh:mm tt"),
                    row["Status"].ToString()
                );
            }

            dgv_schedule.Columns["Column5"].Visible = false;
        }

        public void DisplayTimeslots(DataTable timeslots)
        {
            dgv_timeslot.Rows.Clear();
            foreach (DataRow row in timeslots.Rows)
            {
                TimeSpan s = (TimeSpan)row["StartTime"];
                TimeSpan e = (TimeSpan)row["EndTime"];
                dgv_timeslot.Rows.Add(
                    row["TimeslotID"],
                    DateTime.Today.Add(s).ToString("h:mm tt"),
                    DateTime.Today.Add(e).ToString("h:mm tt"),
                    row["Status"].ToString()
                );
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void txt_searchPayment_Enter(object sender, EventArgs e)
        {
            if (txt_searchPayment.Text == "   Search")
            {
                txt_searchPayment.Text = "   "; 
                txt_searchPayment.ForeColor = Color.Black;
            }
        }

        private void txt_searchPayment_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchPayment.Text))
            {
                txt_searchPayment.Text = "   Search"; 
                txt_searchPayment.ForeColor = Color.Gray; 
            }
        }

        private void c(object sender, EventArgs e)
        {

        }

        private void btn_addPayment_Click(object sender, EventArgs e)
        {
            addSchedule form = new addSchedule(this);
            form.ShowDialog();
        }

       


       
            private void dgv_schedule_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            if (e.RowIndex < 0) return;
            int scheduleID = Convert.ToInt32(dgv_schedule.Rows[e.RowIndex].Cells["schedID"].Value);
            _presenter.LoadTimeslots(scheduleID);
        }

        private void dgv_timeslot_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int timeslotID = Convert.ToInt32(dgv_timeslot.Rows[e.RowIndex].Cells["TimeslotID"].Value);
            string start = dgv_timeslot.Rows[e.RowIndex].Cells["StartTime"].Value.ToString();
            string end = dgv_timeslot.Rows[e.RowIndex].Cells["EndTime"].Value.ToString();
            string status = dgv_timeslot.Rows[e.RowIndex].Cells["Status"].Value.ToString();

            if (status != "Available")
            {
                ShowMessage("This timeslot is already booked.");
                return;
            }

            if (dgv_schedule.SelectedRows.Count == 0)
            {
                ShowMessage("Please select a schedule first.");
                return;
            }

            int scheduleID = Convert.ToInt32(dgv_schedule.SelectedRows[0].Cells["schedID"].Value);
            int doctorID = Convert.ToInt32(dgv_schedule.SelectedRows[0].Cells["Column5"].Value);
            string doctorName = dgv_schedule.SelectedRows[0].Cells["DoctorName"].Value.ToString();
            string scheduleDate = dgv_schedule.SelectedRows[0].Cells["Column1"].Value.ToString();

            addAppointment frm = new addAppointment(
                scheduleID,
                timeslotID,
                doctorID,
                doctorName,
                scheduleDate,
                start,
                end
            );
            frm.ShowDialog();

            _presenter.LoadTimeslots(scheduleID);
        }
        public void RefreshSchedules()
        {
            _presenter.LoadSchedules();  
        }
    }
}
    