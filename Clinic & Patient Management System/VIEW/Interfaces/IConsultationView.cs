using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
   public interface IConsultationView
    {
        void DisplayConsultations(DataTable consultations);
        void ShowMessage(string message);
    }
}
