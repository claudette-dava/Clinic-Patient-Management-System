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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class addDoctor : Form, IAddDoctorView
    {
        private readonly AddDoctorPresenter _presenter;
        private DoctorRecord _parentForm;
        public event Action DoctorSaved;

        public addDoctor(DoctorRecord parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _presenter = new AddDoctorPresenter(this);

            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
            btn_addDoctor.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");

            _presenter.LoadSpecializations(); // Load dropdown
        }
        public string DoctorName => txt_DoctorName.Text;
        public int SpecializationID => Convert.ToInt32(cmb_specialization.SelectedValue);
        public string ContactNumber => txt_phoneNumber.Text;
        public string Email => txt_Email.Text;
        public string Status => rb_active.Checked ? "Active" : "Inactive";
        public void SetSpecializationList(DataTable specializations)
        {
            cmb_specialization.DataSource = specializations;
            cmb_specialization.DisplayMember = "SpecializationName";
            cmb_specialization.ValueMember = "SpecializationID";
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseForm() => this.Close();

        public void TriggerDoctorSaved()
        {
            DoctorSaved?.Invoke();
        }


        private void btn_addDoctor_Click(object sender, EventArgs e)
        {
            _presenter.SaveDoctor();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
