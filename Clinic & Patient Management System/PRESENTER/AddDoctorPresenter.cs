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
        public AddDoctorPresenter(IAddDoctorView view)
        {
            _view = view;
            _model = new AddDoctorModel();
        }

        public void LoadSpecializations()
        {
            DataTable dt = _model.GetSpecializations();
            _view.SetSpecializationList(dt);
        }

        public void SaveDoctor()
        {
            string name = _view.DoctorName;
            int specializationID = _view.SpecializationID;
            string contact = _view.ContactNumber;
            string email = _view.Email;
            string status = _view.Status;

            _model.AddDoctor(name, specializationID, contact, email, status);

            _view.ShowMessage("Doctor added successfully!");
            _view.TriggerDoctorSaved();
            _view.CloseForm();
        }
    }
}
