using Clinic___Patient_Management_System.MODEL;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.PRESENTER
{
    public class AddDoctorPresenter
    {
        private readonly IAddDoctorView _view;
        private readonly AddDoctorModel _model;
        private readonly DoctorModel _doctorModel;
        public AddDoctorPresenter(IAddDoctorView view)
        {
            _view = view;
            _model = new AddDoctorModel();
            _doctorModel = new DoctorModel();
        }

        public void LoadSpecializations()
        {
            DataTable dt = _model.GetSpecializations();
            _view.SetSpecializationList(dt);
        }

        public void SaveDoctor()
        {
            string name = _view.DoctorName.Trim();
            int specializationID = _view.SpecializationID;
            string contact = _view.ContactNumber.Trim();
            string email = _view.Email.Trim();
            string status = _view.Status;          
            if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[A-Za-z\s.'-]+$"))
            {
                _view.ShowMessage("Invalid name. Only letters, spaces, and periods are allowed.");
                return;
            }

            if (name.Length < 3)
            {
                _view.ShowMessage("Name is too short. Please enter the full name.");
                return;
            }

         
            if (!System.Text.RegularExpressions.Regex.IsMatch(contact, @"^09\d{9}$"))
            {
                _view.ShowMessage("Invalid contact number. It must start with '09' and contain 11 digits.");
                return;
            }

         
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
            {
                _view.ShowMessage("Invalid email address format.");
                return;
            }

           
            if (_view is VIEW.addDoctor form && form.DoctorID > 0)
            {
                
                _doctorModel.UpdateDoctor(form.DoctorID, name, specializationID, contact, email, status);
                _view.ShowMessage("Doctor record updated successfully!");
            }
            else
            {
              
                _model.AddDoctor(name, specializationID, contact, email, status);
                _view.ShowMessage("Doctor added successfully!");
            }

            _view.TriggerDoctorSaved();
            _view.CloseForm();
        }

    }
}
