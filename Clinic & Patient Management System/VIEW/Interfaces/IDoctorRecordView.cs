using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clinic___Patient_Management_System.MODEL.DoctorModel;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
    public interface IDoctorRecordView
    {
        void DisplayDoctors(List<Doctor> doctors);
    }
}
