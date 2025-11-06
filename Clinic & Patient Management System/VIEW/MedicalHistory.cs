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
    public partial class MedicalHistory : Form, IMedicalHistoryView    
    {
        private readonly MedicalHistoryPresenter _presenter;
        public int PatientID { get; private set; }
        public string PatientName
        {
            get => txt_name.Text;
            set => txt_name.Text = value;
        }

        public MedicalHistory(int patientId, string patientName)
        {
            InitializeComponent();
            _presenter = new MedicalHistoryPresenter(this);
            panel2.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
            btn_save.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
            PatientID = patientId;
            PatientName = patientName;
            _presenter.LoadMedicalHistory(patientId);
            txt_name.ReadOnly = true;
        }

        public string Allergies
        {
            get => txt_allergies.Text;
            set => txt_allergies.Text = value;
        }

        public string Medications
        {
            get => txt_medications.Text;
            set => txt_medications.Text = value;
        }

        public string PastIllnesses
        {
            get => txt_pastIllnesses.Text;
            set => txt_pastIllnesses.Text = value;
        }

        public string ChronicConditions
        {
            get => txt_condition.Text;
            set => txt_condition.Text = value;
        }

        public string Notes
        {
            get => txt_notes.Text;
            set => txt_notes.Text = value;
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void CloseForm() => this.Close();

        private void btn_save_Click(object sender, EventArgs e)
        {
            _presenter.SaveMedicalHistory();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

