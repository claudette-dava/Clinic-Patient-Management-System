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
using static Clinic___Patient_Management_System.MODEL.DoctorModel;


namespace Clinic___Patient_Management_System.VIEW
{
    public partial class DoctorRecord : Form, IDoctorRecordView
    {


        private readonly DoctorRecordPresenter _presenter;
        public DoctorRecord()
        {
            InitializeComponent();
            _presenter = new DoctorRecordPresenter(this);
            txt_searchDoctor.Text = "   Search";
            txt_searchDoctor.ForeColor = Color.Gray;

            _presenter.LoadDoctors();
        }
        public void DisplayDoctors(List<Doctor> doctors)
        {
            dgv_doctorRecord.Rows.Clear();

            foreach (var d in doctors)
            {
                dgv_doctorRecord.Rows.Add(
                    d.DoctorID,
                    d.Name,
                    d.Specialization,
                    d.ContactNo,
                    d.Email,
                    d.Status,
                    "Edit", "Delete"
                );
            }
        }
        private void txt_searchDoctor_Enter(object sender, EventArgs e)
        {
            if (txt_searchDoctor.Text == "   Search")
            {
                txt_searchDoctor.Text = "   "; 
                txt_searchDoctor.ForeColor = Color.Black; 
            }
        }

        private void txt_searchDoctor_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchDoctor.Text))
            {
                txt_searchDoctor.Text = "   Search";
                txt_searchDoctor.ForeColor = Color.Gray; 
            }
        }

        private void c_Click(object sender, EventArgs e)
        {
            addDoctor addDoctorForm = new addDoctor(this);

            // 🟢 Subscribe to refresh event
            addDoctorForm.DoctorSaved += () =>
            {
                _presenter.LoadDoctors(); // refresh after save
            };

            addDoctorForm.ShowDialog();
        }

        private void DoctorRecord_Load(object sender, EventArgs e)
        {

        } 

      
    }
}
