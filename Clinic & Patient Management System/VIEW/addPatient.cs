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
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class addPatient : Form, IAddPatientView
    {
        public event Action PatientSaved;
        public int PatientID { get; set; }
        private readonly AddPatientPresenter _presenter;
        private readonly PatientRecord _parentForm;


        public addPatient(PatientRecord parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _presenter = new AddPatientPresenter(this);

            txt_age.ReadOnly = true;
            dtp_birthdate.Font = new Font("Microsoft Sans Serif", 15);
            dtp_birthdate.Width = 330;
            panel2.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
            btn_addPatient.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
            this.DoubleBuffered = true;
            InitializeProvinceAndCities();  
        }
        public string NameInput => txt_name.Text;
        public string AgeInput => txt_age.Text;
        public string SexInput => rb_male.Checked ? "M" : rb_female.Checked ? "F" : "";
        public string ContactInput => txt_contactNo.Text;
        public string EmailInput => txt_email.Text;
        public string ProvinceInput => cb_province.Text;
        public string CityInput => cb_city.Text;
        public string BrgyInput => txt_brgy.Text;
        public string StreetInput => txt_streetNo.Text;
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseForm() => this.Close();

        public void ClearFields()
        {
            txt_name.Clear();
            txt_age.Clear();
            rb_male.Checked = false;
            rb_female.Checked = false;
            txt_contactNo.Clear();
            txt_email.Clear();
            cb_province.SelectedIndex = -1;
            cb_city.SelectedIndex = -1;
            txt_brgy.Clear();
            txt_streetNo.Clear();
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            this.Close();
        }

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            _presenter.SavePatient();
        }    
        private void dtp_birthdate_ValueChanged(object sender, EventArgs e)
        {
            txt_age.Text = _presenter.ComputeAge(dtp_birthdate.Value);
        }
        public void FillPatientData(string name, string age, string province, string city, string brgy, string streetNo, string sex, string contact, string email)
        {
            txt_name.Text = name;
            txt_age.Text = age;
            cb_province.Text = province;
            cb_city.Text = city;
            txt_brgy.Text = brgy;
            txt_streetNo.Text = streetNo;
            rb_male.Checked = (sex == "M");
            rb_female.Checked = (sex == "F");
            txt_contactNo.Text = contact;
            txt_email.Text = email;
        }
        public void TriggerPatientSaved()
        {
            PatientSaved?.Invoke();
        }
        private void InitializeProvinceAndCities()
        {
            
            cb_province.Items.Clear();
            cb_province.Items.Add("Bulacan");      
            var bulacanCities = new List<string>
            {
                "Angat",
                "Balagtas",
                "Baliuag",
                "Bocaue",
                "Bulakan",
                "Bustos",
                "Calumpit",
                "Doña Remedios Trinidad",
                "Guiguinto",
                "Hagonoy",
                "Malolos City",
                "Marilao",
                "Meycauayan City",
                "Norzagaray",
                "Obando",
                "Pandi",
                "Paombong",
                "Plaridel",
                "Pulilan",
                "San Ildefonso",
                "San Jose del Monte City",
                "San Miguel",
                "San Rafael",
                "Santa Maria"
            };
            cb_city.Items.Clear();
            cb_city.Items.AddRange(bulacanCities.ToArray());
            cb_city.DropDownStyle = ComboBoxStyle.DropDown;
            cb_city.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_city.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}