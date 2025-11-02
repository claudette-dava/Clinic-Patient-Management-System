namespace Clinic___Patient_Management_System.VIEW
{
    partial class addDoctor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_DoctorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_specialization = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_addDoctor = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.PhoneNy = new System.Windows.Forms.Label();
            this.txt_phoneNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.rb_active = new System.Windows.Forms.RadioButton();
            this.rb_inactive = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_DoctorName
            // 
            this.txt_DoctorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DoctorName.Location = new System.Drawing.Point(16, 91);
            this.txt_DoctorName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DoctorName.Multiline = true;
            this.txt_DoctorName.Name = "txt_DoctorName";
            this.txt_DoctorName.Size = new System.Drawing.Size(516, 40);
            this.txt_DoctorName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Doctor Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Specialization";
            // 
            // cmb_specialization
            // 
            this.cmb_specialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_specialization.FormattingEnabled = true;
            this.cmb_specialization.Location = new System.Drawing.Point(16, 154);
            this.cmb_specialization.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_specialization.Name = "cmb_specialization";
            this.cmb_specialization.Size = new System.Drawing.Size(516, 32);
            this.cmb_specialization.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 59);
            this.panel1.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(102, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(350, 31);
            this.label11.TabIndex = 37;
            this.label11.Text = "DOCTOR INFORMATION";
            // 
            // btn_addDoctor
            // 
            this.btn_addDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_addDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addDoctor.ForeColor = System.Drawing.Color.White;
            this.btn_addDoctor.Location = new System.Drawing.Point(144, 378);
            this.btn_addDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addDoctor.Name = "btn_addDoctor";
            this.btn_addDoctor.Size = new System.Drawing.Size(219, 41);
            this.btn_addDoctor.TabIndex = 28;
            this.btn_addDoctor.Text = "Add Doctor";
            this.btn_addDoctor.UseVisualStyleBackColor = true;
            this.btn_addDoctor.Click += new System.EventHandler(this.btn_addDoctor_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Red;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(416, 392);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(91, 27);
            this.btn_cancel.TabIndex = 37;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // PhoneNy
            // 
            this.PhoneNy.AutoSize = true;
            this.PhoneNy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNy.Location = new System.Drawing.Point(15, 205);
            this.PhoneNy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PhoneNy.Name = "PhoneNy";
            this.PhoneNy.Size = new System.Drawing.Size(97, 16);
            this.PhoneNy.TabIndex = 40;
            this.PhoneNy.Text = "Phone Number";
            // 
            // txt_phoneNumber
            // 
            this.txt_phoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phoneNumber.Location = new System.Drawing.Point(19, 225);
            this.txt_phoneNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txt_phoneNumber.Multiline = true;
            this.txt_phoneNumber.Name = "txt_phoneNumber";
            this.txt_phoneNumber.Size = new System.Drawing.Size(317, 40);
            this.txt_phoneNumber.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 282);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Email";
            // 
            // txt_Email
            // 
            this.txt_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Email.Location = new System.Drawing.Point(18, 302);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Email.Multiline = true;
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(312, 40);
            this.txt_Email.TabIndex = 42;
            // 
            // rb_active
            // 
            this.rb_active.AutoSize = true;
            this.rb_active.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_active.Location = new System.Drawing.Point(361, 245);
            this.rb_active.Margin = new System.Windows.Forms.Padding(4);
            this.rb_active.Name = "rb_active";
            this.rb_active.Size = new System.Drawing.Size(62, 20);
            this.rb_active.TabIndex = 44;
            this.rb_active.TabStop = true;
            this.rb_active.Text = "Active";
            this.rb_active.UseVisualStyleBackColor = true;
            // 
            // rb_inactive
            // 
            this.rb_inactive.AutoSize = true;
            this.rb_inactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_inactive.Location = new System.Drawing.Point(436, 245);
            this.rb_inactive.Margin = new System.Windows.Forms.Padding(4);
            this.rb_inactive.Name = "rb_inactive";
            this.rb_inactive.Size = new System.Drawing.Size(71, 20);
            this.rb_inactive.TabIndex = 45;
            this.rb_inactive.TabStop = true;
            this.rb_inactive.Text = "Inactive";
            this.rb_inactive.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(352, 213);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 46;
            this.label8.Text = "Status";
            // 
            // addDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 440);
            this.Controls.Add(this.rb_active);
            this.Controls.Add(this.rb_inactive);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_phoneNumber);
            this.Controls.Add(this.PhoneNy);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_addDoctor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmb_specialization);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_DoctorName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "addDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_DoctorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_specialization;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_addDoctor;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label PhoneNy;
        private System.Windows.Forms.TextBox txt_phoneNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.RadioButton rb_active;
        private System.Windows.Forms.RadioButton rb_inactive;
        private System.Windows.Forms.Label label8;
    }
}