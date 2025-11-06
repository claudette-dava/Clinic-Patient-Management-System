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
            this.Shown += DoctorRecord_Shown;
            _presenter.LoadDoctors();
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
            StyleDataGridView();
        }
        private void StyleDataGridView()
        {
            var dgv = dgv_doctorRecord;


            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;


            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.LightGray;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;


            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#6495ed");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 240, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 40;
            dgv.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);

            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);




            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(235, 243, 255);
            };
            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(245, 248, 255);
                }
            };
        }
          private void DoctorRecord_Shown(object sender, EventArgs e)
        {

            _presenter.LoadDoctors();


            this.BeginInvoke(new Action(() =>
            {
                try
                {
                    dgv_doctorRecord.AutoResizeColumns();
                    dgv_doctorRecord.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                    dgv_doctorRecord.ClearSelection();
                    dgv_doctorRecord.Refresh();
                }
                catch
                {
                    
                }
            }));
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
            dgv_doctorRecord.AutoResizeColumns();
            dgv_doctorRecord.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dgv_doctorRecord.ClearSelection();
            dgv_doctorRecord.Refresh();
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

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_doctorRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Assuming "Edit" is column 6 and "Delete" is column 7
            string columnName = dgv_doctorRecord.Columns[e.ColumnIndex].Name;

            if (columnName == "edit")
            {
                int doctorId = Convert.ToInt32(dgv_doctorRecord.Rows[e.RowIndex].Cells["doctorID"].Value);
                string name = dgv_doctorRecord.Rows[e.RowIndex].Cells["doctorName"].Value.ToString();
                string specialization = dgv_doctorRecord.Rows[e.RowIndex].Cells["specialization"].Value.ToString();
                string contact = dgv_doctorRecord.Rows[e.RowIndex].Cells["phoneNumber"].Value.ToString();
                string email = dgv_doctorRecord.Rows[e.RowIndex].Cells["email"].Value.ToString();
                string status = dgv_doctorRecord.Rows[e.RowIndex].Cells["Status"].Value.ToString();


                int specializationId = _presenter.GetSpecializationIdByName(specialization);

                var editForm = new addDoctor(this);
                editForm.FillDoctorData(doctorId, name, specializationId, contact, email, status);

                editForm.DoctorSaved += () => _presenter.LoadDoctors();

                editForm.ShowDialog();
            }
            else if (columnName == "delete")
            {
                int doctorId = Convert.ToInt32(dgv_doctorRecord.Rows[e.RowIndex].Cells["doctorID"].Value);
                string doctorName = dgv_doctorRecord.Rows[e.RowIndex].Cells["doctorName"].Value.ToString();

                var confirm = MessageBox.Show(
                    $"Are you sure you want to delete Dr. {doctorName}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _presenter.DeleteDoctor(doctorId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting doctor:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void txt_searchDoctor_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_searchDoctor.Text.Trim();

            // ignore the placeholder
            if (keyword == "Search" || keyword == "")
            {
                _presenter.LoadDoctors();
                return;
            }

            _presenter.SearchDoctors(keyword);
        }
    }
}
