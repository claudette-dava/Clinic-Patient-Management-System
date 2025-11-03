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
    public partial class ViewConsultation : Form
    {
        private readonly int _consultationID;
        private readonly string connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public ViewConsultation(int consultationID)
        {
            InitializeComponent();
            _consultationID = consultationID;
            LoadConsultationDetails();
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
            btn_addPatient.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
        }
        private void LoadConsultationDetails()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = @"
                    SELECT 
                        c.ConsultationDate, c.Temperature, c.BloodPressure, c.Weight, c.Height, c.HeartRate,
                        c.ChiefComplaint, c.Diagnosis, c.Treatment, c.Prescription, c.Notes,
                        c.FollowUpRequired, c.FollowUpDate,
                        p.Name AS PatientName,
                        d.Name AS DoctorName
                    FROM tbl_consultation c
                    INNER JOIN tbl_patientRecord p ON c.PatientID = p.PatientID
                    INNER JOIN tbl_doctor d ON c.DoctorID = d.DoctorID
                    WHERE c.ConsultationID = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", _consultationID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txt_patientName.Text = reader["PatientName"].ToString();
                    txt_doctorName.Text = reader["DoctorName"].ToString();
                    txt_consultationDate.Text = Convert.ToDateTime(reader["ConsultationDate"]).ToShortDateString();

                    txt_temperature.Text = reader["Temperature"].ToString();
                    txt_bp.Text = reader["BloodPressure"].ToString();
                    txt_weight.Text = reader["Weight"].ToString();
                    txt_height.Text = reader["Height"].ToString();
                    txt_hr.Text = reader["HeartRate"].ToString();

                    txt_complaint.Text = reader["ChiefComplaint"].ToString();
                    txt_diagnosis.Text = reader["Diagnosis"].ToString();
                    txt_treatment.Text = reader["Treatment"].ToString();
                    txt_prescription.Text = reader["Prescription"].ToString();
                    txt_notes.Text = reader["Notes"].ToString();

                    bool followUp = Convert.ToBoolean(reader["FollowUpRequired"]);
                    txt_followUp.Text = followUp ? "Yes" : "No";
                    txt_followUpDate.Text = reader["FollowUpDate"] == DBNull.Value ? "" :
                                            Convert.ToDateTime(reader["FollowUpDate"]).ToShortDateString();
                }
            }
        }

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
