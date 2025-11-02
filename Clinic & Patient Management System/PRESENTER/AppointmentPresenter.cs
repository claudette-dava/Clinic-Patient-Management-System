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
    public class AppointmentPresenter
    {
        private readonly IAppointmentView _view;
        private readonly AppointmentModel _model;
        public AppointmentPresenter(IAppointmentView view)
        {
            _view = view;
            _model = new AppointmentModel();
        }

        public void LoadAppointments()
        {
            DataTable dt = _model.GetAppointments();
            _view.DisplayAppointments(dt);
        }
    }
}
