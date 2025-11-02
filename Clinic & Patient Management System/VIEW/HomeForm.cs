using Clinic___Patient_Management_System.OTHERS;
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
            SetPictureBoxRadius(pic_createAppointment, 30);

            lbl_userName.Top = 25;
            lbl_userName.Left = 70;
            lbl_profession.Top = 40;
            lbl_profession.Left = 70;

            pic_dashboard.Top = 120;
            pic_dashboard.Left = 15;
            lbl_dashboard.Top = 130;
            lbl_dashboard.Left = 55;


            pic_appointment.Top = 180;
            pic_appointment.Left = 15;
            lbl_appointment.Top = 190;
            lbl_appointment.Left = 55;

            pic_patient.Top = 240;
            pic_patient.Left = 15;
            lbl_patient.Top = 250;
            lbl_patient.Left = 55;

            pic_Consultation.Top = 300;
            pic_Consultation.Left = 15;
            lbl_Consultation.Top = 310;
            lbl_Consultation.Left = 55;

            pic_doctor.Top = 360;
            pic_doctor.Left = 15;
            lbl_doctor.Top = 370;
            lbl_doctor.Left = 55;

            pic_schedule.Top =420;
            pic_schedule.Left = 15;
            lbl_schedule.Top = 430;
            lbl_schedule.Left = 55;

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

        }

        private void lbl_dashboard_Click(object sender, EventArgs e)
        {

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
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            this.Close();

    
            LogIn loginForm = Application.OpenForms.OfType<LogIn>().FirstOrDefault();
            if (loginForm == null)
                loginForm = new LogIn();

            loginForm.Show();
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
    }
}
