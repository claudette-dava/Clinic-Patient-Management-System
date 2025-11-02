using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
    public interface IAddPatientView
    {
        int PatientID { get; }
        string NameInput { get; }
        string AgeInput { get; }
        string SexInput { get; }
        string ContactInput { get; }
        string EmailInput { get; }
        string ProvinceInput { get; }
        string CityInput { get; }
        string BrgyInput { get; }
        string StreetInput { get; }

        void ShowMessage(string message);
        void CloseForm();
        void ClearFields();
        void TriggerPatientSaved();
    }
}
