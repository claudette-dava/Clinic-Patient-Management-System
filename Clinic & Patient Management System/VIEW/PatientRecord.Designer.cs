namespace Clinic___Patient_Management_System.VIEW
{
    partial class PatientRecord
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
            this.dgv_patientRecord = new System.Windows.Forms.DataGridView();
            this.btn_addPatient = new System.Windows.Forms.Button();
            this.txt_searchPatient = new System.Windows.Forms.TextBox();
            this.patientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewMH = new System.Windows.Forms.DataGridViewButtonColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patientRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_patientRecord
            // 
            this.dgv_patientRecord.AllowUserToAddRows = false;
            this.dgv_patientRecord.ColumnHeadersHeight = 40;
            this.dgv_patientRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patientID,
            this.name,
            this.age,
            this.address,
            this.sex,
            this.contactNo,
            this.email,
            this.ViewMH,
            this.edit,
            this.delete});
            this.dgv_patientRecord.Location = new System.Drawing.Point(12, 67);
            this.dgv_patientRecord.Name = "dgv_patientRecord";
            this.dgv_patientRecord.Size = new System.Drawing.Size(1580, 561);
            this.dgv_patientRecord.TabIndex = 0;
            this.dgv_patientRecord.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_patientRecord_CellContentClick);
            // 
            // btn_addPatient
            // 
            this.btn_addPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addPatient.Location = new System.Drawing.Point(1360, 12);
            this.btn_addPatient.Name = "btn_addPatient";
            this.btn_addPatient.Size = new System.Drawing.Size(223, 33);
            this.btn_addPatient.TabIndex = 1;
            this.btn_addPatient.Text = "ADD A PATIENT";
            this.btn_addPatient.UseVisualStyleBackColor = true;
            this.btn_addPatient.Click += new System.EventHandler(this.btn_addPatient_Click);
            // 
            // txt_searchPatient
            // 
            this.txt_searchPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchPatient.Location = new System.Drawing.Point(14, 12);
            this.txt_searchPatient.Multiline = true;
            this.txt_searchPatient.Name = "txt_searchPatient";
            this.txt_searchPatient.Size = new System.Drawing.Size(751, 33);
            this.txt_searchPatient.TabIndex = 2;
            this.txt_searchPatient.Enter += new System.EventHandler(this.txt_searchPatient_Enter);
            this.txt_searchPatient.Leave += new System.EventHandler(this.txt_searchPatient_Leave);
            // 
            // patientID
            // 
            this.patientID.HeaderText = "PatientID";
            this.patientID.Name = "patientID";
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.Width = 350;
            // 
            // age
            // 
            this.age.HeaderText = "Age";
            this.age.Name = "age";
            this.age.Width = 35;
            // 
            // address
            // 
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            this.address.Width = 350;
            // 
            // sex
            // 
            this.sex.HeaderText = "Sex";
            this.sex.Name = "sex";
            this.sex.Width = 50;
            // 
            // contactNo
            // 
            this.contactNo.HeaderText = "Contact No.";
            this.contactNo.Name = "contactNo";
            this.contactNo.Width = 200;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.Width = 300;
            // 
            // ViewMH
            // 
            this.ViewMH.HeaderText = "Medical History";
            this.ViewMH.Name = "ViewMH";
            this.ViewMH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ViewMH.Width = 60;
            // 
            // edit
            // 
            this.edit.HeaderText = "Edit";
            this.edit.Name = "edit";
            this.edit.Width = 50;
            // 
            // delete
            // 
            this.delete.HeaderText = "Delete";
            this.delete.Name = "delete";
            this.delete.Width = 50;
            // 
            // PatientRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 663);
            this.Controls.Add(this.txt_searchPatient);
            this.Controls.Add(this.btn_addPatient);
            this.Controls.Add(this.dgv_patientRecord);
            this.Name = "PatientRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientRecord";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patientRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_patientRecord;
        private System.Windows.Forms.Button btn_addPatient;
        private System.Windows.Forms.TextBox txt_searchPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewButtonColumn ViewMH;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}