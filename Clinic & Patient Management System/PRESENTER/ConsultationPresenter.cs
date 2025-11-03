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
    public class ConsultationPresenter
    {
        private readonly IConsultationView _view;
        private readonly ConsultationModel _model;

        public ConsultationPresenter(IConsultationView view)
        {
            _view = view;
            _model = new ConsultationModel();
        }

        public void LoadConsultations()
        {
            try
            {
                DataTable consultations = _model.GetAllConsultations();
                _view.DisplayConsultations(consultations);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Error loading consultations: {ex.Message}");
            }
        }
    }
}
