using Clinic___Patient_Management_System.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic___Patient_Management_System.VIEW.Interfaces;

namespace Clinic___Patient_Management_System.PRESENTER
{
    public class PatientRecordPresenter
    {
        private readonly IPatientRecordView _view;
        private readonly PatientModel _model;

        public PatientRecordPresenter(IPatientRecordView view)
        {
            _view = view;
            _model = new PatientModel();
        }
       public void LoadPatients()
        {
   
        string role = CurrentUser.Role?.Trim();
  
        int doctorId = CurrentUser.DoctorID ?? 0;

        List<PatientModel.Patient> patients;

            if (role == "Doctor" && doctorId > 0)
        {
         patients = _model.GetPatientsForDoctor(doctorId);
        }
          else
        {
        patients = _model.GetAllPatients();
        }

    _view.DisplayPatients(patients);
        }

        public void DeletePatient(int id)
        {

            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to delete this patient record?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.No)
                return;


            if (!_model.CanDeletePatient(id))
            {
                _view.ShowMessage("Cannot delete patient because they have appointments.");
                return;
            }

            _model.DeletePatient(id);
            _view.ShowMessage("Patient record deleted successfully!");
            LoadPatients();
        }
        public void SearchPatients(string keyword)
        {
            string role = CurrentUser.Role?.Trim();
            int doctorId = CurrentUser.DoctorID ?? 0;

            var results = _model.SearchPatients(keyword, role, doctorId);
            _view.DisplayPatients(results);
        }



    }
}