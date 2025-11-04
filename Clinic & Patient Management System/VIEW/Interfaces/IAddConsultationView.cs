using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
    public interface IAddConsultationView
    {
        // IDs
        int AppointmentID { get; }
        int DoctorID { get; }
        int PatientID { get; }

        // Vital Signs
        string Temperature { get; }
        string BloodPressure { get; }
        string Weight { get; }
        string PatientHeight { get; }
        string HeartRate { get; }

        // Consultation Details
        string ChiefComplaint { get; }
        string Diagnosis { get; }
        string Treatment { get; }
        string Prescription { get; }
        string Notes { get; }

        // Follow-up Info
        bool FollowUpRequired { get; }
        DateTime? FollowUpDate { get; }

        // Feedback
        void ShowMessage(string message);
        void CloseForm();
        void NotifyConsultationSaved();

        event Action ConsultationSaved;
    }
}
