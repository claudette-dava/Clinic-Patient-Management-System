namespace Clinic___Patient_Management_System.VIEW
{
    partial class ScheduleDoctor
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
            this.dgv_schedule = new System.Windows.Forms.DataGridView();
            this.schedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_searchPayment = new System.Windows.Forms.TextBox();
            this.btn_addSchedule = new System.Windows.Forms.Button();
            this.dgv_timeslot = new System.Windows.Forms.DataGridView();
            this.TimeSlotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_schedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_timeslot)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_schedule
            // 
            this.dgv_schedule.AllowUserToAddRows = false;
            this.dgv_schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_schedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.schedID,
            this.Column5,
            this.DoctorName,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv_schedule.Location = new System.Drawing.Point(12, 51);
            this.dgv_schedule.Name = "dgv_schedule";
            this.dgv_schedule.Size = new System.Drawing.Size(643, 525);
            this.dgv_schedule.TabIndex = 0;
            this.dgv_schedule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_schedule_CellClick);
            // 
            // schedID
            // 
            this.schedID.HeaderText = "ScheduleID";
            this.schedID.Name = "schedID";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "DoctorID";
            this.Column5.Name = "Column5";
            // 
            // DoctorName
            // 
            this.DoctorName.HeaderText = "DoctorName";
            this.DoctorName.Name = "DoctorName";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ScheduleDate";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "StartTime";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "EndTime";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Status";
            this.Column4.Name = "Column4";
            // 
            // txt_searchPayment
            // 
            this.txt_searchPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchPayment.Location = new System.Drawing.Point(12, 12);
            this.txt_searchPayment.Multiline = true;
            this.txt_searchPayment.Name = "txt_searchPayment";
            this.txt_searchPayment.Size = new System.Drawing.Size(421, 33);
            this.txt_searchPayment.TabIndex = 10;
            this.txt_searchPayment.TextChanged += new System.EventHandler(this.c);
            this.txt_searchPayment.Enter += new System.EventHandler(this.txt_searchPayment_Enter);
            this.txt_searchPayment.Leave += new System.EventHandler(this.txt_searchPayment_Leave);
            // 
            // btn_addSchedule
            // 
            this.btn_addSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addSchedule.Location = new System.Drawing.Point(446, 12);
            this.btn_addSchedule.Name = "btn_addSchedule";
            this.btn_addSchedule.Size = new System.Drawing.Size(210, 33);
            this.btn_addSchedule.TabIndex = 11;
            this.btn_addSchedule.Text = "ADD A SCHEDULE";
            this.btn_addSchedule.UseVisualStyleBackColor = true;
            this.btn_addSchedule.Click += new System.EventHandler(this.btn_addPayment_Click);
            // 
            // dgv_timeslot
            // 
            this.dgv_timeslot.AllowUserToAddRows = false;
            this.dgv_timeslot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_timeslot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeSlotID,
            this.StartTime,
            this.EndTime,
            this.Status});
            this.dgv_timeslot.Location = new System.Drawing.Point(662, 12);
            this.dgv_timeslot.Name = "dgv_timeslot";
            this.dgv_timeslot.Size = new System.Drawing.Size(518, 564);
            this.dgv_timeslot.TabIndex = 12;
            this.dgv_timeslot.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_timeslot_CellDoubleClick);
            // 
            // TimeSlotID
            // 
            this.TimeSlotID.HeaderText = "TimeSlotID";
            this.TimeSlotID.Name = "TimeSlotID";
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "StartTime";
            this.StartTime.Name = "StartTime";
            this.StartTime.Width = 225;
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "EndTime";
            this.EndTime.Name = "EndTime";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 150;
            // 
            // ScheduleDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 588);
            this.Controls.Add(this.dgv_timeslot);
            this.Controls.Add(this.btn_addSchedule);
            this.Controls.Add(this.txt_searchPayment);
            this.Controls.Add(this.dgv_schedule);
            this.Name = "ScheduleDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScheduleDoctor";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_schedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_timeslot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_schedule;
        private System.Windows.Forms.TextBox txt_searchPayment;
        private System.Windows.Forms.Button btn_addSchedule;
        private System.Windows.Forms.DataGridView dgv_timeslot;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSlotID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}