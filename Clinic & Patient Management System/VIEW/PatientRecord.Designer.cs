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
            this.btn_addPatient = new System.Windows.Forms.Button();
            this.txt_searchPatient = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patientRecord)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_patientRecord
            // 
            this.dgv_patientRecord.AllowUserToAddRows = false;
            this.dgv_patientRecord.AllowUserToDeleteRows = false;
            this.dgv_patientRecord.BackgroundColor = System.Drawing.Color.White;
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
            this.dgv_patientRecord.Location = new System.Drawing.Point(12, 139);
            this.dgv_patientRecord.Name = "dgv_patientRecord";
            this.dgv_patientRecord.ReadOnly = true;
            this.dgv_patientRecord.Size = new System.Drawing.Size(1580, 545);
            this.dgv_patientRecord.TabIndex = 0;
            this.dgv_patientRecord.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_patientRecord_CellContentClick);
            this.dgv_patientRecord.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_patientRecord_CellPainting);
            // 
            // patientID
            // 
            this.patientID.HeaderText = "PatientID";
            this.patientID.Name = "patientID";
            this.patientID.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 350;
            // 
            // age
            // 
            this.age.HeaderText = "Age";
            this.age.Name = "age";
            this.age.ReadOnly = true;
            this.age.Width = 35;
            // 
            // address
            // 
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 350;
            // 
            // sex
            // 
            this.sex.HeaderText = "Sex";
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            this.sex.Width = 50;
            // 
            // contactNo
            // 
            this.contactNo.HeaderText = "Contact No.";
            this.contactNo.Name = "contactNo";
            this.contactNo.ReadOnly = true;
            this.contactNo.Width = 200;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 300;
            // 
            // ViewMH
            // 
            this.ViewMH.HeaderText = "Medical History";
            this.ViewMH.Name = "ViewMH";
            this.ViewMH.ReadOnly = true;
            this.ViewMH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ViewMH.Width = 60;
            // 
            // edit
            // 
            this.edit.HeaderText = "Edit";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Width = 50;
            // 
            // delete
            // 
            this.delete.HeaderText = "Delete";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Width = 50;
            // 
            // btn_addPatient
            // 
            this.btn_addPatient.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_addPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addPatient.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_addPatient.Location = new System.Drawing.Point(1369, 87);
            this.btn_addPatient.Name = "btn_addPatient";
            this.btn_addPatient.Size = new System.Drawing.Size(223, 33);
            this.btn_addPatient.TabIndex = 1;
            this.btn_addPatient.Text = "ADD NEW PATIENT";
            this.btn_addPatient.UseVisualStyleBackColor = false;
            this.btn_addPatient.Click += new System.EventHandler(this.btn_addPatient_Click);
            // 
            // txt_searchPatient
            // 
            this.txt_searchPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchPatient.Location = new System.Drawing.Point(14, 84);
            this.txt_searchPatient.Multiline = true;
            this.txt_searchPatient.Name = "txt_searchPatient";
            this.txt_searchPatient.Size = new System.Drawing.Size(831, 38);
            this.txt_searchPatient.TabIndex = 2;
            this.txt_searchPatient.TextChanged += new System.EventHandler(this.txt_searchPatient_TextChanged);
            this.txt_searchPatient.Enter += new System.EventHandler(this.txt_searchPatient_Enter);
            this.txt_searchPatient.Leave += new System.EventHandler(this.txt_searchPatient_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-5, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1621, 72);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(369, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "PATIENT INFORMATION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1566, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PatientRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1604, 696);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_searchPatient);
            this.Controls.Add(this.btn_addPatient);
            this.Controls.Add(this.dgv_patientRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatientRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatientRecord";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patientRecord)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}