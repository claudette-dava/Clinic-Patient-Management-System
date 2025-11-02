using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
    public interface IAddDoctorView
    {
        string DoctorName { get; }
        int SpecializationID { get; }
        string ContactNumber { get; }
        string Email { get; }
        string Status { get; }

        void SetSpecializationList(DataTable specializations);
        void ShowMessage(string message);
        void CloseForm();

        event Action DoctorSaved;
        void TriggerDoctorSaved();
    }
}
