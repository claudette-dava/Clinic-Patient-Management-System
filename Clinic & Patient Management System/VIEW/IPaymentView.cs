using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW
{
    public interface IPaymentView
    {
        void DisplayPayments(DataTable payments);
        void ShowMessage(string message);
    }
}
