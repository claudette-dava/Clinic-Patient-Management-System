using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic___Patient_Management_System
{
    public static class FormNavigator
    {
        public static async Task ShowFormSmoothly(Form current, Form next, Form owner = null)
        {
            // Optional delay to simulate "smoothness" without flicker
            const int transitionDelay = 10;

            try
            {
                // Disable current to avoid user input while switching
                if (current != null && current.Visible)
                {
                    current.Enabled = false;
                    current.Hide(); // instantly hides without opacity flicker
                }

                if (owner != null)
                    next.Owner = owner;

                // Prepare next form before showing
                next.StartPosition = FormStartPosition.CenterScreen;
                next.Show();
                next.BringToFront();

                // Small async delay for a tiny buffer (optional)
                await Task.Delay(transitionDelay);

                // When next is closed, restore the previous form
                next.FormClosed += (s, e) =>
                {
                    if (current != null && !current.IsDisposed)
                    {
                        current.Show();
                        current.Enabled = true;
                        current.BringToFront();
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Navigation error: " + ex.Message);
            }
        }
    }
}
