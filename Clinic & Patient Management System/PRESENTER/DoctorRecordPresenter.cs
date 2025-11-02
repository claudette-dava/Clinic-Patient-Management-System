using Clinic___Patient_Management_System.MODEL;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.PRESENTER
{
    public class DoctorRecordPresenter

    {
        private readonly IDoctorRecordView _view;
        private readonly DoctorModel _model;

        public DoctorRecordPresenter(IDoctorRecordView view)
        {
            _view = view;
            _model = new DoctorModel();
        }
        public void LoadDoctors()
        {
            var doctors = _model.GetAllDoctors();
            _view.DisplayDoctors(doctors);
        }
    }
}
