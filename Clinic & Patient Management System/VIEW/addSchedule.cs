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
    public partial class addSchedule : Form
    {

        string connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        private ScheduleDoctor _parentform;
        public addSchedule(ScheduleDoctor parentform)
        {
            InitializeComponent();
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
            btn_addPatient.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
            _parentform = parentform;    
        }

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            int doctorID = Convert.ToInt32(cmb_doctor.SelectedValue);
            DateTime scheduleDate = dtp_date.Value.Date;
            TimeSpan startTime = dtp_start.Value.TimeOfDay;
            TimeSpan endTime = dtp_end.Value.TimeOfDay;
            string status = rb_active.Checked ? "Active" : "Inactive";

            // Validation: End must be after start
            if (endTime <= startTime)
            {
                MessageBox.Show("End time must be after Start time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string insertQuery = @"INSERT INTO tbl_schedule (DoctorID, ScheduleDate, StartTime, EndTime, Status)
                               VALUES (@DoctorID, @ScheduleDate, @StartTime, @EndTime, @Status)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                   
                    cmd.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorID;
                    cmd.Parameters.Add("@ScheduleDate", SqlDbType.Date).Value = scheduleDate;
                    cmd.Parameters.Add("@StartTime", SqlDbType.Time).Value = startTime;
                    cmd.Parameters.Add("@EndTime", SqlDbType.Time).Value = endTime;
                    cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = status;

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Schedule added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
           _parentform.RefreshSchedules();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addSchedule_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT DoctorID, Name FROM tbl_doctor WHERE Status='Active'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmb_doctor.DisplayMember = "Name";
                cmb_doctor.ValueMember = "DoctorID";
                cmb_doctor.DataSource = dt;
                cmb_doctor.SelectedIndex = -1;
            }
            dtp_date.Value = DateTime.Today;
            dtp_start.Format = DateTimePickerFormat.Time;
            dtp_start.ShowUpDown = true;
            dtp_start.Value = DateTime.Today.AddHours(8); 

         
            dtp_end.Format = DateTimePickerFormat.Time;
            dtp_end.ShowUpDown = true;
            dtp_end.Value = DateTime.Today.AddHours(17); 
        }
    }
}
