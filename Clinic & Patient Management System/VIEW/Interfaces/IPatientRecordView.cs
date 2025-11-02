using Clinic___Patient_Management_System.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clinic___Patient_Management_System.MODEL.PatientModel;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
    public interface IPatientRecordView
    {
        void DisplayPatients(List<Patient> patients);
        void ShowMessage(string message);
    }
}
