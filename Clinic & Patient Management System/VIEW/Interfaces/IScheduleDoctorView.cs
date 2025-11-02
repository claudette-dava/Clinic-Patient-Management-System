using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
    public interface IScheduleDoctorView
    {
        void DisplaySchedules(DataTable schedules);
        void DisplayTimeslots(DataTable timeslots);
        void ShowMessage(string message);
    }
}
