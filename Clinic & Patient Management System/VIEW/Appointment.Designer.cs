namespace Clinic___Patient_Management_System.VIEW
{
    partial class Appointment
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
            this.dgv_appointmentRecord = new System.Windows.Forms.DataGridView();
            this.appointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSlotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddConsultation = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Payment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Cancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_searchAppointment = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_appointmentRecord)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_appointmentRecord
            // 
            this.dgv_appointmentRecord.AllowUserToAddRows = false;
            this.dgv_appointmentRecord.AllowUserToDeleteRows = false;
            this.dgv_appointmentRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_appointmentRecord.BackgroundColor = System.Drawing.Color.White;
            this.dgv_appointmentRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_appointmentRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointmentID,
            this.patientID,
            this.DoctorName,
            this.scheduleID,
            this.timeSlotID,
            this.date,
            this.startTime,
            this.endTime,
            this.status,
            this.AddConsultation,
            this.Payment,
            this.Cancel,
            this.Delete});
            this.dgv_appointmentRecord.Location = new System.Drawing.Point(30, 124);
            this.dgv_appointmentRecord.Name = "dgv_appointmentRecord";
            this.dgv_appointmentRecord.ReadOnly = true;
            this.dgv_appointmentRecord.Size = new System.Drawing.Size(1341, 427);
            this.dgv_appointmentRecord.TabIndex = 0;
            this.dgv_appointmentRecord.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_appointmentRecord_CellContentClick);
            // 
            // appointmentID
            // 
            this.appointmentID.HeaderText = "AppointmentID";
            this.appointmentID.Name = "appointmentID";
            this.appointmentID.ReadOnly = true;
            // 
            // patientID
            // 
            this.patientID.HeaderText = "PatientName";
            this.patientID.Name = "patientID";
            this.patientID.ReadOnly = true;
            // 
            // DoctorName
            // 
            this.DoctorName.HeaderText = "DoctorName";
            this.DoctorName.Name = "DoctorName";
            this.DoctorName.ReadOnly = true;
            // 
            // scheduleID
            // 
            this.scheduleID.HeaderText = "ScheduleID";
            this.scheduleID.Name = "scheduleID";
            this.scheduleID.ReadOnly = true;
            // 
            // timeSlotID
            // 
            this.timeSlotID.HeaderText = "TimeSlotID";
            this.timeSlotID.Name = "timeSlotID";
            this.timeSlotID.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "AppointmentDate";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // startTime
            // 
            this.startTime.HeaderText = "StartTime";
            this.startTime.Name = "startTime";
            this.startTime.ReadOnly = true;
            // 
            // endTime
            // 
            this.endTime.HeaderText = "EndTime";
            this.endTime.Name = "endTime";
            this.endTime.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // AddConsultation
            // 
            this.AddConsultation.HeaderText = "Add Consultation";
            this.AddConsultation.Name = "AddConsultation";
            this.AddConsultation.ReadOnly = true;
            this.AddConsultation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AddConsultation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Payment
            // 
            this.Payment.HeaderText = "Payment";
            this.Payment.Name = "Payment";
            this.Payment.ReadOnly = true;
            this.Payment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Payment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Cancel
            // 
            this.Cancel.HeaderText = "Cancel Appointment";
            this.Cancel.Name = "Cancel";
            this.Cancel.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // txt_searchAppointment
            // 
            this.txt_searchAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchAppointment.Location = new System.Drawing.Point(30, 76);
            this.txt_searchAppointment.Multiline = true;
            this.txt_searchAppointment.Name = "txt_searchAppointment";
            this.txt_searchAppointment.Size = new System.Drawing.Size(1341, 33);
            this.txt_searchAppointment.TabIndex = 5;
            this.txt_searchAppointment.Enter += new System.EventHandler(this.txt_searchAppointment_Enter);
            this.txt_searchAppointment.Leave += new System.EventHandler(this.txt_searchAppointment_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-7, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1409, 67);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "APPOINTMENT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1359, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1394, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_searchAppointment);
            this.Controls.Add(this.dgv_appointmentRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Appointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_appointmentRecord)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_appointmentRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeSlotID;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn AddConsultation;
        private System.Windows.Forms.DataGridViewButtonColumn Payment;
        private System.Windows.Forms.DataGridViewButtonColumn Cancel;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.TextBox txt_searchAppointment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}