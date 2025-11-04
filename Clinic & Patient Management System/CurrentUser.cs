using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic___Patient_Management_System
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }
        public static int? DoctorID { get; set; }

        public static void Clear()
        {
            UserID = 0;
            FullName = null;
            Role = null;
            DoctorID = null;
        }
    }
}
