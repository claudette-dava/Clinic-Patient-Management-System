using Clinic___Patient_Management_System.MODEL;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.PRESENTER
{
    public class AddPaymentPresenter
    {
        private readonly IAddPaymentView _view;
        private readonly PaymentModel _model;

        public AddPaymentPresenter(IAddPaymentView view)
        {
            _view = view;
            _model = new PaymentModel();
        }

        public void SavePayment()
        {
            // --- Validation ---
            if (_view.Amount <= 0)
            {
                _view.ShowMessage("Please enter a valid amount.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.PaymentMethod))
            {
                _view.ShowMessage("Please select a payment method.");
                return;
            }

            // --- Insert into DB ---
            try
            {
                _model.AddPayment(
                    _view.AppointmentID,
                    _view.PatientID,
                    _view.DoctorID,
                    _view.Amount,
                    _view.PaymentMethod,
                    _view.Status,
                    _view.Notes
                );

                _view.ShowMessage("Payment recorded successfully!");
                _view.NotifyPaymentSaved();  // ✅ use helper
                _view.CloseForm();
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Error saving payment: " + ex.Message);
            }
        }
    }
}
