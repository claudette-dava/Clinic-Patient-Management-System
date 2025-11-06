using Clinic___Patient_Management_System.MODEL;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.PRESENTER
{
    public class AddPatientPresenter
    {
        private readonly IAddPatientView _view;
        private readonly AddPatientModel _model;

        public AddPatientPresenter(IAddPatientView view)
        {
            _view = view;
            _model = new AddPatientModel();
        }
        public void SavePatient()
        {
            if (!int.TryParse(_view.AgeInput, out int age))
            {
                _view.ShowMessage("Invalid age format.");
                return;
            }

            if (age < 0)
            {
                _view.ShowMessage("Age cannot be negative.");
                return;
            }

            if (age > 120)
            {
                _view.ShowMessage("Age seems unrealistic. Please check the birthdate.");
                return;
            }

            if (!Regex.IsMatch(_view.NameInput.Trim(), @"^[A-Za-z\s]+$"))
            {
                _view.ShowMessage("Invalid name. Only letters and spaces are allowed.");
                return;
            }

            if (string.IsNullOrEmpty(_view.SexInput))
            {
                _view.ShowMessage("Please select a gender.");
                return;
            }

            if (!Regex.IsMatch(_view.ContactInput.Trim(), @"^09\d{9}$"))
            {
                _view.ShowMessage("Invalid phone number. Please enter a valid phone number.");
                return;
            }

            if (!Regex.IsMatch(_view.EmailInput.Trim(), @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
            {
                _view.ShowMessage("Invalid email address.");
                return;
            }

            // --- ADDRESS COMBINE ---
            string street = _view.StreetInput.Trim();
            if (!street.EndsWith(",")) street += ",";
            string fullAddress = $"{street} {_view.BrgyInput}, {_view.CityInput}, {_view.ProvinceInput}";

            // --- SAVE TO DATABASE ---
            _model.SavePatient(
                _view.PatientID,
                _view.NameInput,
                _view.AgeInput,
                fullAddress,
                _view.SexInput,
                _view.ContactInput,
                _view.EmailInput
            );

            // --- FEEDBACK ---
            string msg = _view.PatientID > 0 ? "Record updated successfully!" : "Patient added successfully!";
            _view.ShowMessage(msg);
            _view.ClearFields();
            _view.TriggerPatientSaved();

            _view.CloseForm();
        }

        public string ComputeAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age))
                age--;
            return age.ToString();
        }
    }
}
