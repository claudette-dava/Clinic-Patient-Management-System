using Clinic___Patient_Management_System.MODEL;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.PRESENTER
{
    public class ScheduleDoctorPresenter
    {
        private readonly IScheduleDoctorView _view;
        private readonly ScheduleDoctorModel _model;

        public ScheduleDoctorPresenter(IScheduleDoctorView view)
        {
            _view = view;
            _model = new ScheduleDoctorModel();
        }

        public void LoadSchedules()
        {
            DataTable dt = _model.GetSchedules();
            _view.DisplaySchedules(dt);
        }

        public void LoadTimeslots(int scheduleID)
        {
            var (startTS, endTS) = _model.GetScheduleTimeRange(scheduleID);
            if (startTS == TimeSpan.Zero && endTS == TimeSpan.Zero)
            {
                _view.ShowMessage("Schedule not found.");
                return;
            }

            int count = _model.CountExistingTimeslots(scheduleID);
            if (count == 0)
            {
                GenerateTimeslots(scheduleID, startTS, endTS);
            }

            DataTable slots = _model.GetTimeslots(scheduleID);
            _view.DisplayTimeslots(slots);
        }

        private void GenerateTimeslots(int scheduleID, TimeSpan startTS, TimeSpan endTS)
        {
            DateTime start = DateTime.Today.Add(startTS);
            DateTime end = DateTime.Today.Add(endTS);
            TimeSpan interval = TimeSpan.FromMinutes(30);

            for (DateTime time = start; time < end; time = time.Add(interval))
            {
                if (time.Hour == 12) continue; // skip lunch break
                _model.InsertTimeslot(scheduleID, time.TimeOfDay, time.Add(interval).TimeOfDay);
            }
        }
    }
}
