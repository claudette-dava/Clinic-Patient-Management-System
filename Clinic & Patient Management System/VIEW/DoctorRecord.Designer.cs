namespace Clinic___Patient_Management_System.VIEW
{
    partial class DoctorRecord
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
            this.dgv_doctorRecord = new System.Windows.Forms.DataGridView();
            this.doctorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_searchDoctor = new System.Windows.Forms.TextBox();
            this.c = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_doctorRecord)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_doctorRecord
            // 
            this.dgv_doctorRecord.AllowUserToAddRows = false;
            this.dgv_doctorRecord.AllowUserToDeleteRows = false;
            this.dgv_doctorRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_doctorRecord.BackgroundColor = System.Drawing.Color.White;
            this.dgv_doctorRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_doctorRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.doctorID,
            this.doctorName,
            this.specialization,
            this.phoneNumber,
            this.email,
            this.status,
            this.edit,
            this.delete});
            this.dgv_doctorRecord.Location = new System.Drawing.Point(12, 114);
            this.dgv_doctorRecord.Name = "dgv_doctorRecord";
            this.dgv_doctorRecord.ReadOnly = true;
            this.dgv_doctorRecord.Size = new System.Drawing.Size(1245, 184);
            this.dgv_doctorRecord.TabIndex = 0;
            this.dgv_doctorRecord.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_doctorRecord_CellContentClick);
            // 
            // doctorID
            // 
            this.doctorID.HeaderText = "DoctorID";
            this.doctorID.Name = "doctorID";
            this.doctorID.ReadOnly = true;
            // 
            // doctorName
            // 
            this.doctorName.HeaderText = "Name";
            this.doctorName.Name = "doctorName";
            this.doctorName.ReadOnly = true;
            // 
            // specialization
            // 
            this.specialization.HeaderText = "Specialization";
            this.specialization.Name = "specialization";
            this.specialization.ReadOnly = true;
            // 
            // phoneNumber
            // 
            this.phoneNumber.HeaderText = "PhoneNumber";
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.ReadOnly = true;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // edit
            // 
            this.edit.HeaderText = "Edit";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "Delete";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            // 
            // txt_searchDoctor
            // 
            this.txt_searchDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchDoctor.Location = new System.Drawing.Point(12, 74);
            this.txt_searchDoctor.Multiline = true;
            this.txt_searchDoctor.Name = "txt_searchDoctor";
            this.txt_searchDoctor.Size = new System.Drawing.Size(611, 33);
            this.txt_searchDoctor.TabIndex = 4;
            this.txt_searchDoctor.TextChanged += new System.EventHandler(this.txt_searchDoctor_TextChanged);
            this.txt_searchDoctor.Enter += new System.EventHandler(this.txt_searchDoctor_Enter);
            this.txt_searchDoctor.Leave += new System.EventHandler(this.txt_searchDoctor_Leave);
            // 
            // c
            // 
            this.c.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c.Location = new System.Drawing.Point(1034, 74);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(223, 33);
            this.c.TabIndex = 3;
            this.c.Text = "ADD A DOCTOR";
            this.c.UseVisualStyleBackColor = true;
            this.c.Click += new System.EventHandler(this.c_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-8, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1287, 68);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1235, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "DOCTOR RECORD";
            // 
            // DoctorRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1266, 310);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_searchDoctor);
            this.Controls.Add(this.c);
            this.Controls.Add(this.dgv_doctorRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DoctorRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor Record";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_doctorRecord)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_doctorRecord;
        private System.Windows.Forms.TextBox txt_searchDoctor;
        private System.Windows.Forms.Button c;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn specialization;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}