namespace Clinic___Patient_Management_System.VIEW
{
    partial class Consultation
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
            this.dgv_consultation = new System.Windows.Forms.DataGridView();
            this.consultationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsultationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiefComplaint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Treatment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followUpRequired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followUpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewDetails = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FollowUpAppointment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_searchConsultation = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultation)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_consultation
            // 
            this.dgv_consultation.AllowUserToAddRows = false;
            this.dgv_consultation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_consultation.BackgroundColor = System.Drawing.Color.White;
            this.dgv_consultation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_consultation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consultationID,
            this.appointmentID,
            this.PatientID,
            this.DoctorID,
            this.PatientName,
            this.DoctorName,
            this.ConsultationDate,
            this.ChiefComplaint,
            this.diagnosis,
            this.Treatment,
            this.followUpRequired,
            this.followUpDate,
            this.ViewDetails,
            this.FollowUpAppointment});
            this.dgv_consultation.Location = new System.Drawing.Point(12, 119);
            this.dgv_consultation.Name = "dgv_consultation";
            this.dgv_consultation.Size = new System.Drawing.Size(1289, 403);
            this.dgv_consultation.TabIndex = 0;
            this.dgv_consultation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_consultation_CellContentClick);
            // 
            // consultationID
            // 
            this.consultationID.HeaderText = "ConsultationID";
            this.consultationID.Name = "consultationID";
            // 
            // appointmentID
            // 
            this.appointmentID.HeaderText = "AppointmentID";
            this.appointmentID.Name = "appointmentID";
            // 
            // PatientID
            // 
            this.PatientID.HeaderText = "Patient ID";
            this.PatientID.Name = "PatientID";
            // 
            // DoctorID
            // 
            this.DoctorID.HeaderText = "Doctor ID";
            this.DoctorID.Name = "DoctorID";
            // 
            // PatientName
            // 
            this.PatientName.HeaderText = "Patient Name";
            this.PatientName.Name = "PatientName";
            // 
            // DoctorName
            // 
            this.DoctorName.HeaderText = "Doctor Name";
            this.DoctorName.Name = "DoctorName";
            // 
            // ConsultationDate
            // 
            this.ConsultationDate.HeaderText = "Consultation Date";
            this.ConsultationDate.Name = "ConsultationDate";
            // 
            // ChiefComplaint
            // 
            this.ChiefComplaint.HeaderText = "ChiefComplaint";
            this.ChiefComplaint.Name = "ChiefComplaint";
            // 
            // diagnosis
            // 
            this.diagnosis.HeaderText = "Diagnosis";
            this.diagnosis.Name = "diagnosis";
            // 
            // Treatment
            // 
            this.Treatment.HeaderText = "Treatment";
            this.Treatment.Name = "Treatment";
            // 
            // followUpRequired
            // 
            this.followUpRequired.HeaderText = "Follow Up Required";
            this.followUpRequired.Name = "followUpRequired";
            this.followUpRequired.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // followUpDate
            // 
            this.followUpDate.HeaderText = "Follow Up Date";
            this.followUpDate.Name = "followUpDate";
            // 
            // ViewDetails
            // 
            this.ViewDetails.HeaderText = "View Details";
            this.ViewDetails.Name = "ViewDetails";
            this.ViewDetails.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FollowUpAppointment
            // 
            this.FollowUpAppointment.HeaderText = "Follow Up Appointment";
            this.FollowUpAppointment.Name = "FollowUpAppointment";
            this.FollowUpAppointment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FollowUpAppointment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txt_searchConsultation
            // 
            this.txt_searchConsultation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchConsultation.Location = new System.Drawing.Point(12, 68);
            this.txt_searchConsultation.Multiline = true;
            this.txt_searchConsultation.Name = "txt_searchConsultation";
            this.txt_searchConsultation.Size = new System.Drawing.Size(1289, 33);
            this.txt_searchConsultation.TabIndex = 7;
            this.txt_searchConsultation.Enter += new System.EventHandler(this.txt_searchConsultation_Enter);
            this.txt_searchConsultation.Leave += new System.EventHandler(this.txt_searchConsultation_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-6, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1331, 60);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONSULTATION";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1277, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Consultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1313, 541);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_searchConsultation);
            this.Controls.Add(this.dgv_consultation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Consultation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_consultation;
        private System.Windows.Forms.TextBox txt_searchConsultation;
        private System.Windows.Forms.DataGridViewTextBoxColumn consultationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsultationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiefComplaint;
        private System.Windows.Forms.DataGridViewTextBoxColumn diagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Treatment;
        private System.Windows.Forms.DataGridViewTextBoxColumn followUpRequired;
        private System.Windows.Forms.DataGridViewTextBoxColumn followUpDate;
        private System.Windows.Forms.DataGridViewButtonColumn ViewDetails;
        private System.Windows.Forms.DataGridViewButtonColumn FollowUpAppointment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}