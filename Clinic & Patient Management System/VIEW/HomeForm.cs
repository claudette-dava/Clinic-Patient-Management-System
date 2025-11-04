using Clinic___Patient_Management_System.OTHERS;
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
    public partial class HomeForm : Form
    {
        public static Appointment appointmentForm;
        public HomeForm()
        {
            InitializeComponent();
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#2e373a");
            panel2.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");

            pic_UserProfile.Top = 15;
            pic_UserProfile.Left = 15;
            SetPictureBoxRadius(pic_UserProfile, 50);
            SetPictureBoxRadius(pic_island, 50);

            lbl_userName.Top = 25;
            lbl_userName.Left = 70;
            lbl_role.Top = 40;
            lbl_role.Left = 70;

            pic_dashboard.Top = 120;
            pic_dashboard.Left = 15;
            lbl_dashboard.Top = 130;
            lbl_dashboard.Left = 55;
         


            pic_patient.Top = 180;
            pic_patient.Left = 15;
            lbl_patient.Top = 190;
            lbl_patient.Left = 55;

            pic_doctor.Top = 240;
            pic_doctor.Left = 15;
            lbl_doctor.Top = 250;
            lbl_doctor.Left = 55;

            pic_schedule.Top = 300;
            pic_schedule.Left = 15;
            lbl_schedule.Top = 310;
            lbl_schedule.Left = 55;

            pic_appointment.Top = 360;
            pic_appointment.Left = 15;
            lbl_appointment.Top = 370;
            lbl_appointment.Left = 55;

            pic_Consultation.Top = 420;
            pic_Consultation.Left = 15;
            lbl_Consultation.Top = 430;
            lbl_Consultation.Left = 55;

            pic_payment.Top = 480;
            pic_payment.Left = 15;
            lbl_payment.Top = 490;
            lbl_payment.Left = 55;


            pic_addUser.Top = 840;
            pic_addUser.Left = 15;
            lbl_addUser.Top = 850;
            lbl_addUser.Left = 55;

            pic_logout.Top = 900;
            pic_logout.Left = 15;
            lbl_logout.Top = 910;
            lbl_logout.Left = 55;
            string role = CurrentUser.Role?.Trim();
          

           
            if (role == "Doctor")
            {
                pic_appointment.Top = 240;
                pic_appointment.Left = 15;
                lbl_appointment.Top = 250;
                lbl_appointment.Left = 55;

                pic_Consultation.Top = 300;
                pic_Consultation.Left = 15;
                lbl_Consultation.Top = 310;
                lbl_Consultation.Left = 55;
            }

            ConfigureUIByRole();
            SetGreetingMessage();
            LoadDashboardData();
            LoadTodayAppointments();
        }
        private void ConfigureUIByRole()
        {
            string role = CurrentUser.Role?.Trim();
            lbl_dashboard.Visible = true;
            lbl_appointment.Visible = true;
            lbl_patient.Visible = true;
            lbl_Consultation.Visible = true;
            lbl_doctor.Visible = true;
            lbl_schedule.Visible = true;
            lbl_payment.Visible = true;
            lbl_addUser.Visible = true;
            pic_logout.Visible = true;

            switch (role)
            {
                case "Admin":
                    // Admin sees everything
                    break;

                case "Staff":
                   
                  
                    lbl_addUser.Visible = false;
                    pic_addUser.Visible = false;
                    break;

                case "Doctor":
                    // Doctor only sees Consultation and Dashboard
                    lbl_doctor.Visible = false;
                    pic_doctor.Visible = false;


                    lbl_schedule.Visible = false;
                    pic_schedule.Visible = false;


                    lbl_payment.Visible = false;
                    pic_payment.Visible = false;

                    lbl_addUser.Visible = false;
                    pic_addUser.Visible = false;
                    break;

                default:
                    MessageBox.Show("Unrecognized role. Limited access granted.", "Warning");
                    break;
            }
        }
        private void LoadDashboardData()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;"))
            {
                con.Open();

                string role = CurrentUser.Role?.Trim();

                string doctorCountQuery = "SELECT COUNT(*) FROM tbl_doctor";
                string patientCountQuery;
                string appointmentCountQuery;
                string upcomingQuery;

                if (role == "Doctor")
                {
                    int doctorId = CurrentUser.DoctorID ?? 0;

                   
                    patientCountQuery = $@"
            SELECT COUNT(DISTINCT PatientID)
            FROM tbl_appointment
            WHERE DoctorID = {doctorId}";

                    
                    appointmentCountQuery = $@"
            SELECT COUNT(*)
            FROM tbl_appointment
            WHERE DoctorID = {doctorId}
              AND Status = 'Scheduled'
              AND CAST(ScheduleDate AS DATE) = CAST(GETDATE() AS DATE)";

                   
                    upcomingQuery = $@"
            SELECT COUNT(*)
            FROM tbl_appointment
            WHERE DoctorID = {doctorId}
              AND Status = 'Scheduled'
              AND CAST(ScheduleDate AS DATE) > CAST(GETDATE() AS DATE)";
                }
                else
                {
                    
                    
                    patientCountQuery = "SELECT COUNT(*) FROM tbl_patientRecord";

                    
                    appointmentCountQuery = @"
            SELECT COUNT(*)
            FROM tbl_appointment
            WHERE Status = 'Scheduled'
              AND CAST(ScheduleDate AS DATE) = CAST(GETDATE() AS DATE)";

                    
                    upcomingQuery = @"
            SELECT COUNT(*)
            FROM tbl_appointment
            WHERE Status = 'Scheduled'
              AND CAST(ScheduleDate AS DATE) > CAST(GETDATE() AS DATE)";
                }
                SqlCommand cmdDoctor = new SqlCommand(doctorCountQuery, con);
                SqlCommand cmdPatient = new SqlCommand(patientCountQuery, con);
                SqlCommand cmdAppointment = new SqlCommand(appointmentCountQuery, con);
                SqlCommand cmdUpcoming = new SqlCommand(upcomingQuery, con);

                
                lbl_doctorCount.Text = cmdDoctor.ExecuteScalar().ToString();
                lbl_patientCount.Text = cmdPatient.ExecuteScalar().ToString();
                lbl_appointmentCount.Text = cmdAppointment.ExecuteScalar().ToString();
                lbl_pendingCount.Text = cmdUpcoming.ExecuteScalar().ToString(); // rename to lbl_upcomingCount for clarity
            }


        }

        private void SetGreetingMessage()
        {
            string firstName = GetFirstName(CurrentUser.FullName);
            string role = CurrentUser.Role?.Trim();
            string greeting;

            if (role == "Doctor")
                greeting = $"Good Morning, Dr. {firstName}!";
            else if (role == "Admin")
                greeting = $"Welcome back, {firstName}! (Administrator)";
            else
                greeting = $"Good Morning, {firstName}!";

            lbl_greeting.Text = greeting;
        }
        private string GetFirstName(string fullName)
        {
            var parts = fullName.Split(' ');
            return parts.Length > 0 ? parts[0] : fullName;
        }
        private void LoadTodayAppointments()
        {
            string connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
            string role = CurrentUser.Role?.Trim();

            dgv_todayAppointments.Rows.Clear();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                SqlCommand cmd;

                if (role == "Doctor")
                {
                    int doctorId = CurrentUser.DoctorID ?? 0;

                    // 🩺 Doctor: show only their own appointments
                    cmd = new SqlCommand(@"
                SELECT 
                    d.Name AS DoctorName,
                    p.Name AS PatientName, 
                    a.StartTime, 
                    a.EndTime, 
                    a.Status
                FROM tbl_appointment a
                INNER JOIN tbl_patientRecord p ON a.PatientID = p.PatientID
                INNER JOIN tbl_doctor d ON a.DoctorID = d.DoctorID
                WHERE a.DoctorID = @DoctorID
                  AND CAST(a.ScheduleDate AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY a.StartTime ASC", con);

                    cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                }
                else
                {
                    // 🧑‍💼 Staff/Admin: show all appointments for today
                    cmd = new SqlCommand(@"
                SELECT 
                    d.Name AS DoctorName,
                    p.Name AS PatientName,
                    a.StartTime,
                    a.EndTime,
                    a.Status
                FROM tbl_appointment a
                INNER JOIN tbl_patientRecord p ON a.PatientID = p.PatientID
                INNER JOIN tbl_doctor d ON a.DoctorID = d.DoctorID
                WHERE CAST(a.ScheduleDate AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY a.StartTime ASC, d.Name ASC", con);
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string doctorName = reader["DoctorName"].ToString();
                        string patientName = reader["PatientName"].ToString();
                        string startTime = DateTime.Today.Add((TimeSpan)reader["StartTime"]).ToString("h:mm tt");
                        string endTime = DateTime.Today.Add((TimeSpan)reader["EndTime"]).ToString("h:mm tt");
                        string status = reader["Status"].ToString();

                        dgv_todayAppointments.Rows.Add(doctorName, patientName, startTime, endTime, status);
                    }
                }
            }

     
            if (dgv_todayAppointments.Rows.Count == 0)
            {
                dgv_todayAppointments.Rows.Add("—", "No appointments found for today —", "", "", "");
            }
        }


        private void SetPictureBoxRadius(PictureBox picture, int radius)
        { 
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();

            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(picture.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(picture.Width - radius, picture.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, picture.Height - radius, radius, radius), 90, 90);

            path.CloseFigure();
            picture.Region = new Region(path);
        }

        private void HomeForm_Resize(object sender, EventArgs e)
        {
            panel1.Height = this.ClientSize.Height;
            panel1.Top = 70;
            panel1.Left = 0;  

            panel2.Width = this.ClientSize.Width;
            panel2.Top = 0;
            panel2.Left = 0;
            panel2.Height = 70;
        }

        private void addPatient_Click(object sender, EventArgs e)
        {
            PatientRecord patientRecord = new PatientRecord();
            patientRecord.ShowDialog();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            lbl_userName.Text = CurrentUser.FullName;
            lbl_role.Text = CurrentUser.Role;
        }

      
        private void lbl_appointment_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.ShowDialog();
        }

        private void lbl_patient_Click(object sender, EventArgs e)
        {
            PatientRecord pr = new PatientRecord();
            pr.ShowDialog();
        }

        private void lbl_Consultation_Click(object sender, EventArgs e)
        {
            Consultation con = new Consultation(); 
            con.ShowDialog();
        }

        private void lbl_doctor_Click(object sender, EventArgs e)
        {
            DoctorRecord doctorRecord = new DoctorRecord();
            doctorRecord.ShowDialog();  
        }

        private void lbl_schedule_Click(object sender, EventArgs e)
        {
            ScheduleDoctor sched = new ScheduleDoctor();    
            sched.ShowDialog(); 
        }

        private void lbl_payment_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.ShowDialog();
        }

        
        private void lbl_logout_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to log out?",
                                    "Logout",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                
                CurrentUser.Clear();

              
                LogIn loginForm = new LogIn();
                loginForm.Show();

                // Close or hide this form
                this.Close();
            }
        }

        private void lbl_addUser_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.ShowDialog();
        }

        private void lbl_patient_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lbl_patient_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData ();   
        }

        private void pnl_bg_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
