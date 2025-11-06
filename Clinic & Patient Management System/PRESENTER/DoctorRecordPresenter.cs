using Clinic___Patient_Management_System.MODEL;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public int GetSpecializationIdByName(string specializationName)
        {
            return _model.GetSpecializationIdByName(specializationName);
        }
        public void DeleteDoctor(int id)
        {
            if (!_model.CanDeleteDoctor(id))
            {
                MessageBox.Show("Cannot delete doctor because they have linked appointments or schedules.",
                                "Deletion Blocked",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            _model.SoftDeleteDoctor(id);
            MessageBox.Show("Doctor has been marked as inactive.", "Soft Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDoctors();
        }
        public void SearchDoctors(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadDoctors(); // show all if search box is empty
                return;
            }

            var results = _model.SearchDoctors(keyword);
            _view.DisplayDoctors(results);
        }

    }
}
