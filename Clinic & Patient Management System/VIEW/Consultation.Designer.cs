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
            this.dgv_consultationRecord = new System.Windows.Forms.DataGridView();
            this.consultationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followUpRequired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nextDateVisit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_searchConsultation = new System.Windows.Forms.TextBox();
            this.btn_addConsultation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultationRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_consultationRecord
            // 
            this.dgv_consultationRecord.AllowUserToAddRows = false;
            this.dgv_consultationRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_consultationRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consultationID,
            this.appointmentID,
            this.diagnosis,
            this.followUpRequired,
            this.nextDateVisit,
            this.doctorNotes,
            this.edit,
            this.delete});
            this.dgv_consultationRecord.Location = new System.Drawing.Point(12, 51);
            this.dgv_consultationRecord.Name = "dgv_consultationRecord";
            this.dgv_consultationRecord.Size = new System.Drawing.Size(1195, 347);
            this.dgv_consultationRecord.TabIndex = 0;
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
            // diagnosis
            // 
            this.diagnosis.HeaderText = "Diagnosis";
            this.diagnosis.Name = "diagnosis";
            this.diagnosis.Width = 200;
            // 
            // followUpRequired
            // 
            this.followUpRequired.HeaderText = "FollowUpRequired";
            this.followUpRequired.Name = "followUpRequired";
            this.followUpRequired.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.followUpRequired.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // nextDateVisit
            // 
            this.nextDateVisit.HeaderText = "NextDateVisit";
            this.nextDateVisit.Name = "nextDateVisit";
            this.nextDateVisit.Width = 150;
            // 
            // doctorNotes
            // 
            this.doctorNotes.HeaderText = "Notes";
            this.doctorNotes.Name = "doctorNotes";
            this.doctorNotes.Width = 300;
            // 
            // edit
            // 
            this.edit.HeaderText = "Edit";
            this.edit.Name = "edit";
            // 
            // delete
            // 
            this.delete.HeaderText = "Delete";
            this.delete.Name = "delete";
            // 
            // txt_searchConsultation
            // 
            this.txt_searchConsultation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchConsultation.Location = new System.Drawing.Point(12, 12);
            this.txt_searchConsultation.Multiline = true;
            this.txt_searchConsultation.Name = "txt_searchConsultation";
            this.txt_searchConsultation.Size = new System.Drawing.Size(486, 33);
            this.txt_searchConsultation.TabIndex = 7;
            this.txt_searchConsultation.Enter += new System.EventHandler(this.txt_searchConsultation_Enter);
            this.txt_searchConsultation.Leave += new System.EventHandler(this.txt_searchConsultation_Leave);
            // 
            // btn_addConsultation
            // 
            this.btn_addConsultation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addConsultation.Location = new System.Drawing.Point(953, 11);
            this.btn_addConsultation.Name = "btn_addConsultation";
            this.btn_addConsultation.Size = new System.Drawing.Size(254, 33);
            this.btn_addConsultation.TabIndex = 6;
            this.btn_addConsultation.Text = "ADD A CONSULTATION";
            this.btn_addConsultation.UseVisualStyleBackColor = true;
            this.btn_addConsultation.Click += new System.EventHandler(this.btn_addConsultation_Click);
            // 
            // Consultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 410);
            this.Controls.Add(this.txt_searchConsultation);
            this.Controls.Add(this.btn_addConsultation);
            this.Controls.Add(this.dgv_consultationRecord);
            this.Name = "Consultation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consultationRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_consultationRecord;
        private System.Windows.Forms.TextBox txt_searchConsultation;
        private System.Windows.Forms.Button btn_addConsultation;
        private System.Windows.Forms.DataGridViewTextBoxColumn consultationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn diagnosis;
        private System.Windows.Forms.DataGridViewCheckBoxColumn followUpRequired;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextDateVisit;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorNotes;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}