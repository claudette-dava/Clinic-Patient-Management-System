using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
    public interface IAddPaymentView
    {
        int AppointmentID { get; }
        int PatientID { get; }
        int DoctorID { get; }
        decimal Amount { get; }
        string PaymentMethod { get; }
        string Status { get; }
        string Notes { get; }

        void ShowMessage(string message);
        void CloseForm();

        event Action PaymentSaved;
        void NotifyPaymentSaved();
    }
}
