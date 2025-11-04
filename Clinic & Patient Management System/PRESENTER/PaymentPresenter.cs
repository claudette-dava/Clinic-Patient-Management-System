using Clinic___Patient_Management_System.MODEL;
using Clinic___Patient_Management_System.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.PRESENTER
{
    public class PaymentPresenter
    {
        private readonly IPaymentView _view;
        private readonly PaymentModel _model;

        public PaymentPresenter(IPaymentView view)
        {
            _view = view;
            _model = new PaymentModel();
        }

        public void LoadPayments()
        {
            try
            {
                var data = _model.GetAllPayments();
                _view.DisplayPayments(data);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Error loading payments: " + ex.Message);
            }
        }

        public void DeletePayment(int paymentId)
        {
            try
            {
                _model.DeletePayment(paymentId);
                _view.ShowMessage("Payment record deleted successfully!");
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Error deleting payment: " + ex.Message);
            }
        }

    }
}
