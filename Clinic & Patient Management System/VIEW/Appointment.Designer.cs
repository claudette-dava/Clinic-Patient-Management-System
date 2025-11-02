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
            this.btn_addAppointment = new System.Windows.Forms.Button();
            this.txt_searchAppointment = new System.Windows.Forms.TextBox();
            this.appointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSlotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editAppointment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteAppointment = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_appointmentRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_appointmentRecord
            // 
            this.dgv_appointmentRecord.AllowUserToAddRows = false;
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
            this.editAppointment,
            this.deleteAppointment});
            this.dgv_appointmentRecord.Location = new System.Drawing.Point(15, 51);
            this.dgv_appointmentRecord.Name = "dgv_appointmentRecord";
            this.dgv_appointmentRecord.Size = new System.Drawing.Size(1246, 427);
            this.dgv_appointmentRecord.TabIndex = 0;
            // 
            // btn_addAppointment
            // 
            this.btn_addAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addAppointment.Location = new System.Drawing.Point(1007, 12);
            this.btn_addAppointment.Name = "btn_addAppointment";
            this.btn_addAppointment.Size = new System.Drawing.Size(254, 33);
            this.btn_addAppointment.TabIndex = 4;
            this.btn_addAppointment.Text = "ADD AN APPOINTMENT";
            this.btn_addAppointment.UseVisualStyleBackColor = true;
            this.btn_addAppointment.Click += new System.EventHandler(this.btn_addAppointment_Click);
            // 
            // txt_searchAppointment
            // 
            this.txt_searchAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchAppointment.Location = new System.Drawing.Point(15, 12);
            this.txt_searchAppointment.Multiline = true;
            this.txt_searchAppointment.Name = "txt_searchAppointment";
            this.txt_searchAppointment.Size = new System.Drawing.Size(486, 33);
            this.txt_searchAppointment.TabIndex = 5;
            this.txt_searchAppointment.Enter += new System.EventHandler(this.txt_searchAppointment_Enter);
            this.txt_searchAppointment.Leave += new System.EventHandler(this.txt_searchAppointment_Leave);
            // 
            // appointmentID
            // 
            this.appointmentID.HeaderText = "AppointmentID";
            this.appointmentID.Name = "appointmentID";
            // 
            // patientID
            // 
            this.patientID.HeaderText = "PatientName";
            this.patientID.Name = "patientID";
            // 
            // DoctorName
            // 
            this.DoctorName.HeaderText = "DoctorName";
            this.DoctorName.Name = "DoctorName";
            // 
            // scheduleID
            // 
            this.scheduleID.HeaderText = "ScheduleID";
            this.scheduleID.Name = "scheduleID";
            // 
            // timeSlotID
            // 
            this.timeSlotID.HeaderText = "TimeSlotID";
            this.timeSlotID.Name = "timeSlotID";
            // 
            // date
            // 
            this.date.HeaderText = "AppointmentDate";
            this.date.Name = "date";
            this.date.Width = 150;
            // 
            // startTime
            // 
            this.startTime.HeaderText = "StartTime";
            this.startTime.Name = "startTime";
            // 
            // endTime
            // 
            this.endTime.HeaderText = "EndTime";
            this.endTime.Name = "endTime";
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.Width = 150;
            // 
            // editAppointment
            // 
            this.editAppointment.HeaderText = "Edit";
            this.editAppointment.Name = "editAppointment";
            // 
            // deleteAppointment
            // 
            this.deleteAppointment.HeaderText = "Delete";
            this.deleteAppointment.Name = "deleteAppointment";
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 495);
            this.Controls.Add(this.txt_searchAppointment);
            this.Controls.Add(this.btn_addAppointment);
            this.Controls.Add(this.dgv_appointmentRecord);
            this.Name = "Appointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_appointmentRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_appointmentRecord;
        private System.Windows.Forms.Button btn_addAppointment;
        private System.Windows.Forms.TextBox txt_searchAppointment;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeSlotID;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn editAppointment;
        private System.Windows.Forms.DataGridViewButtonColumn deleteAppointment;
    }
}