using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
    public interface IMedicalHistoryView
    {
        int PatientID { get; }
        string PatientName { get; set; }

        string Allergies { get; set; }
        string Medications { get; set; }
        string PastIllnesses { get; set; }
        string ChronicConditions { get; set; }
        string Notes { get; set; }

        void ShowMessage(string message);
        void CloseForm();
    }
}
