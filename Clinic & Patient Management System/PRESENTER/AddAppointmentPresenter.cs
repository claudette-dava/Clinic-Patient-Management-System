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
   public class AddAppointmentPresenter
    {
        private readonly IAddAppointmentView _view;
        private readonly AddAppointmentModel _model;

        public AddAppointmentPresenter(IAddAppointmentView view)
        {
            _view = view;
            _model = new AddAppointmentModel();
        }

        public void LoadPatients()
        {
            DataTable patients = _model.GetPatients();
            _view.SetPatientList(patients);
        }

        public void SaveAppointment()
        {
            if (_view.SelectedPatientID == -1)
            {
                _view.ShowMessage("Please select a patient.");
                return;
            }

            if (string.IsNullOrEmpty(_view.Status))
            {
                _view.ShowMessage("Please select a status.");
                return;
            }

            _model.SaveAppointment(
                _view.ScheduleID,
                _view.TimeSlotID,
                _view.DoctorID,
                _view.SelectedPatientID,
                _view.ScheduleDate,
                _view.StartTime.TimeOfDay,
                _view.EndTime.TimeOfDay,
                _view.Status
            );

            _view.ShowMessage("Appointment saved successfully!");
            _view.TriggerAppointmentSaved();
            _view.CloseForm();
        }
    }
}
