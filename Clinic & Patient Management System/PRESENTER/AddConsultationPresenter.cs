using Clinic___Patient_Management_System.MODEL;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.PRESENTER
{
    public class AddConsultationPresenter
    {
        private readonly IAddConsultationView _view;
        private readonly AddConsultationModel _model;

        public AddConsultationPresenter(IAddConsultationView view)
        {
            _view = view;
            _model = new AddConsultationModel();
        }
        public void SaveConsultation()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.Diagnosis))
                {
                    _view.ShowMessage("Please enter a diagnosis before saving.");
                    return;
                }

                _model.SaveConsultation(
                    _view.AppointmentID,
                    _view.DoctorID,
                    _view.PatientID,
                    _view.Temperature,
                    _view.BloodPressure,
                    _view.Weight,
                    _view.Height,
                    _view.HeartRate,
                    _view.ChiefComplaint,
                    _view.Diagnosis,
                    _view.Treatment,
                    _view.Prescription,
                    _view.Notes,
                    _view.FollowUpRequired,
                    _view.FollowUpDate
                );

                _view.ShowMessage("Consultation saved successfully!");
                _view.NotifyConsultationSaved();
                _view.CloseForm();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error saving consultation: {ex.Message}");
            }
        }
    }
}
