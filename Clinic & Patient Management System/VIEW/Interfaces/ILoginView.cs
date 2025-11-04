using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.VIEW.Interfaces
{
   public interface ILoginView
    {
        string Username { get; }
        string Password { get; }

        void ShowMessage(string message);
        void OpenHomeForm();
    }
}
