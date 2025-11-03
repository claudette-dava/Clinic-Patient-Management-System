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
    public class MedicalHistoryPresenter
    {
        private readonly IMedicalHistoryView _view;
        private readonly MedicalHistoryModel _model;

        public MedicalHistoryPresenter(IMedicalHistoryView view)
        {
            _view = view;
            _model = new MedicalHistoryModel();
        }

        // Load data for patient (auto-create blank if none exists)
        public void LoadMedicalHistory(int patientId)
        {
            // Check if history exists
            bool exists = _model.HasMedicalHistory(patientId);

            // If no record, create an empty one
            if (!exists)
            {
                _model.CreateEmptyMedicalHistory(patientId);
            }

            // Now load it
            DataRow history = _model.GetMedicalHistory(patientId);

            if (history != null)
            {
                _view.Allergies = history["Allergies"]?.ToString() ?? "";
                _view.Medications = history["Medications"]?.ToString() ?? "";
                _view.PastIllnesses = history["PastIllnesses"]?.ToString() ?? "";
                _view.ChronicConditions = history["ChronicConditions"]?.ToString() ?? "";
                _view.Notes = history["Notes"]?.ToString() ?? "";
            }
            else
            {
                _view.ShowMessage("Failed to load medical history.");
            }
        }

        // Save or update the medical history record
        public void SaveMedicalHistory()
        {
            try
            {
                _model.UpdateMedicalHistory(
                    _view.PatientID,
                    _view.Allergies,
                    _view.Medications,
                    _view.PastIllnesses,
                    _view.ChronicConditions,
                    _view.Notes
                );

                _view.ShowMessage("Medical history updated successfully!");
                _view.CloseForm();
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Error saving medical history: " + ex.Message);
            }
        }
    }
}
