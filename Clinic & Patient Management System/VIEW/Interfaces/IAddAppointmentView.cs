using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
    public interface IAddAppointmentView
    {
        int ScheduleID { get; }
        int TimeSlotID { get; }
        int DoctorID { get; }
        string DoctorName { get; }
        DateTime ScheduleDate { get; }
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        int SelectedPatientID { get; }
        string Status { get; }

        void SetPatientList(DataTable patients);
        void ShowMessage(string message);
        void CloseForm();

        event Action AppointmentSaved;
        void TriggerAppointmentSaved();
    }
}
