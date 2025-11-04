using Clinic___Patient_Management_System.MODEL;
using Clinic___Patient_Management_System.VIEW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System.PRESENTER
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly LoginModel _model;

        public LoginPresenter(ILoginView view)
        {
            _view = view;
            _model = new LoginModel();
        }
        public void Login()
        {
            var (Success, UserID, FullName, Role, DoctorID) = _model.ValidateLogin(_view.Username, _view.Password);

            if (Success)
            {
                // Store session info
                CurrentUser.UserID = UserID;
                CurrentUser.FullName = FullName;
                CurrentUser.Role = Role;
                CurrentUser.DoctorID = DoctorID;

                _view.ShowMessage($"Welcome, {FullName}!");
                _view.OpenHomeForm();
            }
            else
            {
                _view.ShowMessage("Invalid username or password.");
            }
        }
    }
}
