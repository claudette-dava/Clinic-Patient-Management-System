using Clinic___Patient_Management_System.MODEL;
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
using static Clinic___Patient_Management_System.MODEL.PatientModel;

namespace Clinic___Patient_Management_System.VIEW
{ 

    public partial class PatientRecord : Form, IPatientRecordView
    {
        private readonly HomeForm _homeForm;   
        private readonly PatientRecordPresenter _presenter;
        public PatientRecord(HomeForm homeForm)
        {
            InitializeComponent();
            _presenter = new PatientRecordPresenter(this);
            _homeForm = homeForm;   
            this.Shown += PatientRecord_Shown;  
            txt_searchPatient.Text = "   Search";
            txt_searchPatient.ForeColor = Color.Gray;
            txt_searchPatient.TextChanged += txt_searchPatient_TextChanged;
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
            StyleDataGridView();    

        }
        private void StyleDataGridView()
        {
            var dgv = dgv_patientRecord; 

           
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



        public void DisplayPatients(List<Patient> patients)
        {
            dgv_patientRecord.Rows.Clear();

            string role = CurrentUser.Role?.Trim();

            foreach (var p in patients)
            {
                // 🧠 Smart display for age: "Infant" if 0 or "0"
                string displayAge = "N/A";
                if (int.TryParse(p.Age, out int numericAge))
                {
                    displayAge = numericAge == 0 ? "Infant" : numericAge.ToString();
                }
                else
                {
                    displayAge = p.Age; // in case age is already a string like "2 months"
                }

                int rowIndex = dgv_patientRecord.Rows.Add(
                    p.PatientID,
                    p.Name,
                    displayAge,     // 🟢 use displayAge here
                    p.Address,
                    p.Sex,
                    p.ContactNo,
                    p.Email,
                    "View", "Edit", "Delete"
                );

                var row = dgv_patientRecord.Rows[rowIndex];

                // 🔒 Restrict Doctor's edit/delete access
                if (role == "Doctor")
                {
                    if (dgv_patientRecord.Columns.Contains("edit"))
                    {
                        var editCell = row.Cells["edit"];
                        editCell.Style.ForeColor = Color.DarkGray;
                        editCell.ReadOnly = true;
                    }

                    if (dgv_patientRecord.Columns.Contains("delete"))
                    {
                        var delCell = row.Cells["delete"];
                        delCell.Style.ForeColor = Color.DarkGray;
                        delCell.ReadOnly = true;
                    }
                }
            }

            dgv_patientRecord.AutoResizeColumns();
            dgv_patientRecord.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dgv_patientRecord.ClearSelection();
            dgv_patientRecord.Refresh();
        }


        private void txt_searchPatient_Enter(object sender, EventArgs e)
        {
            if (txt_searchPatient.Text == "   Search")
            {
                txt_searchPatient.Text = ""; 
                txt_searchPatient.ForeColor = Color.Black; 
            }
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_searchPatient_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchPatient.Text))
            {
             
                txt_searchPatient.Text = "   Search";
                txt_searchPatient.ForeColor = Color.Gray;
            }
        }

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            if (CurrentUser.Role?.Trim() == "Doctor")
            {
                MessageBox.Show("Doctors cannot add new patients.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addPatientForm = new addPatient(this);

            addPatientForm.PatientSaved += () => _presenter.LoadPatients();

          
            this.Hide();

            addPatientForm.StartPosition = FormStartPosition.CenterParent; 
            addPatientForm.ShowDialog(_homeForm); 

        
            this.Show();
            _presenter.LoadPatients();

        }

        private void dgv_patientRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int patientId = Convert.ToInt32(dgv_patientRecord.Rows[e.RowIndex].Cells["PatientID"].Value);

            if (e.RowIndex < 0) return;

            string role = CurrentUser.Role?.Trim();

            if (role == "Doctor" && (e.ColumnIndex == 8 || e.ColumnIndex == 9))
            {
                MessageBox.Show("Doctors are not allowed to edit or delete patient records.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            switch (e.ColumnIndex)
            {
                case 7: 
                    {
                        string patientName = dgv_patientRecord.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                        MedicalHistory form = new MedicalHistory(patientId, patientName);
                        form.ShowDialog();
                        break;
                    }

                case 8: 
                    {
                        addPatient frm = new addPatient(this);

                        string name = dgv_patientRecord.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                        string age = dgv_patientRecord.Rows[e.RowIndex].Cells["Age"].Value.ToString();
                        string address = dgv_patientRecord.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                        string sex = dgv_patientRecord.Rows[e.RowIndex].Cells["Sex"].Value.ToString();
                        string contact = dgv_patientRecord.Rows[e.RowIndex].Cells["ContactNo"].Value.ToString();
                        string email = dgv_patientRecord.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                      
                        string[] parts = address.Split(',');
                        string streetNo = parts.Length > 0 ? parts[0].Trim() : "";
                        string brgy = parts.Length > 1 ? parts[1].Trim() : "";
                        string city = parts.Length > 2 ? parts[2].Trim() : "";
                        string province = parts.Length > 3 ? parts[3].Trim() : "";

                       
                        frm.PatientID = patientId;
                        frm.FillPatientData(name, age, province, city, brgy, streetNo, sex, contact, email);

                     
                        frm.PatientSaved += () =>
                        {
                            _presenter.LoadPatients(); 
                        };

                        frm.ShowDialog();
                        break;
                    }


                case 9: 
                    {
                        _presenter.DeletePatient(patientId);
                        break;
                    }

                default:
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_searchPatient_TextChanged(object sender, EventArgs e)
        {
            
            string text = txt_searchPatient.Text.Trim();

            if (string.IsNullOrWhiteSpace(text) || text == "Search")
            {
                _presenter.LoadPatients();
                return;
            }

          
            _presenter.SearchPatients(text);
        }
        private void PatientRecord_Shown(object sender, EventArgs e)
        {
          
            _presenter.LoadPatients();

           
            this.BeginInvoke(new Action(() =>
            {
                try
                {
                   
                    dgv_patientRecord.AutoResizeColumns();
                    dgv_patientRecord.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells); 
                    dgv_patientRecord.ClearSelection();
                    dgv_patientRecord.Refresh();
                }
                catch
                {
                    
                }
            }));
        }

        private void dgv_patientRecord_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {  
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var dgv = (DataGridView)sender;

           
            if (e.ColumnIndex >= dgv.Columns.Count)
                return;

          
            string columnName = dgv.Columns[e.ColumnIndex].Name;

            if (columnName == "ViewMH" || columnName == "edit" || columnName == "delete")
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Paint(e.ClipBounds, DataGridViewPaintParts.Border);

                Rectangle rect = e.CellBounds;
                rect.Inflate(-6, -8);

                Color backColor, hoverColor;
                switch (columnName)
                {
                    case "ViewMH":
                        backColor = ColorTranslator.FromHtml("#007bff");
                        hoverColor = ColorTranslator.FromHtml("#3399ff");
                        break;
                    case "edit":
                        backColor = ColorTranslator.FromHtml("#28a745");
                        hoverColor = ColorTranslator.FromHtml("#34c759");
                        break;
                    case "delete":
                        backColor = ColorTranslator.FromHtml("#dc3545");
                        hoverColor = ColorTranslator.FromHtml("#ff4d4d");
                        break;
                    default:
                        backColor = Color.LightGray;
                        hoverColor = Color.Gray;
                        break;
                }

                bool isHovered = e.State.HasFlag(DataGridViewElementStates.Selected);
                Color fillColor = isHovered ? hoverColor : backColor;

                using (SolidBrush brush = new SolidBrush(fillColor))
                using (Pen border = new Pen(Color.White, 1))
                {
                    e.Graphics.FillRectangle(brush, rect);
                    e.Graphics.DrawRectangle(border, rect);
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    e.FormattedValue?.ToString() ?? "",
                    new Font("Segoe UI", 9, FontStyle.Bold),
                    rect,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
            }
        }
    }
}
   
