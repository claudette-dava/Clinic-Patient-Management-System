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
            this.txt_searchDoctor = new System.Windows.Forms.TextBox();
            this.c = new System.Windows.Forms.Button();
            this.doctorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_doctorRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_doctorRecord
            // 
            this.dgv_doctorRecord.AllowUserToAddRows = false;
            this.dgv_doctorRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_doctorRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.doctorID,
            this.doctorName,
            this.specialization,
            this.Column1,
            this.Column2,
            this.Column3,
            this.edit,
            this.delete});
            this.dgv_doctorRecord.Location = new System.Drawing.Point(12, 51);
            this.dgv_doctorRecord.Name = "dgv_doctorRecord";
            this.dgv_doctorRecord.Size = new System.Drawing.Size(1245, 184);
            this.dgv_doctorRecord.TabIndex = 0;
            // 
            // txt_searchDoctor
            // 
            this.txt_searchDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchDoctor.Location = new System.Drawing.Point(12, 12);
            this.txt_searchDoctor.Multiline = true;
            this.txt_searchDoctor.Name = "txt_searchDoctor";
            this.txt_searchDoctor.Size = new System.Drawing.Size(486, 33);
            this.txt_searchDoctor.TabIndex = 4;
            this.txt_searchDoctor.Enter += new System.EventHandler(this.txt_searchDoctor_Enter);
            this.txt_searchDoctor.Leave += new System.EventHandler(this.txt_searchDoctor_Leave);
            // 
            // c
            // 
            this.c.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c.Location = new System.Drawing.Point(1132, 11);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(223, 33);
            this.c.TabIndex = 3;
            this.c.Text = "ADD A DOCTOR";
            this.c.UseVisualStyleBackColor = true;
            this.c.Click += new System.EventHandler(this.c_Click);
            // 
            // doctorID
            // 
            this.doctorID.HeaderText = "DoctorID";
            this.doctorID.Name = "doctorID";
            // 
            // doctorName
            // 
            this.doctorName.HeaderText = "Name";
            this.doctorName.Name = "doctorName";
            this.doctorName.Width = 350;
            // 
            // specialization
            // 
            this.specialization.HeaderText = "Specialization";
            this.specialization.Name = "specialization";
            this.specialization.Width = 250;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "PhoneNumber";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Email";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Status";
            this.Column3.Name = "Column3";
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
            // DoctorRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 247);
            this.Controls.Add(this.txt_searchDoctor);
            this.Controls.Add(this.c);
            this.Controls.Add(this.dgv_doctorRecord);
            this.Name = "DoctorRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoctorRecord";
            this.Load += new System.EventHandler(this.DoctorRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_doctorRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_doctorRecord;
        private System.Windows.Forms.TextBox txt_searchDoctor;
        private System.Windows.Forms.Button c;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn specialization;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}