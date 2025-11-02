namespace Clinic___Patient_Management_System.VIEW
{
    partial class Payment
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
            this.dgv_payment = new System.Windows.Forms.DataGridView();
            this.paymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consultationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.paymentMethod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.paymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_searchPayment = new System.Windows.Forms.TextBox();
            this.btn_addPayment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_payment)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_payment
            // 
            this.dgv_payment.AllowUserToAddRows = false;
            this.dgv_payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_payment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paymentID,
            this.consultationID,
            this.receiptNumber,
            this.paymentStatus,
            this.paymentMethod,
            this.paymentDate,
            this.amount});
            this.dgv_payment.Location = new System.Drawing.Point(12, 58);
            this.dgv_payment.Name = "dgv_payment";
            this.dgv_payment.Size = new System.Drawing.Size(946, 380);
            this.dgv_payment.TabIndex = 0;
            // 
            // paymentID
            // 
            this.paymentID.HeaderText = "PaymentID";
            this.paymentID.Name = "paymentID";
            // 
            // consultationID
            // 
            this.consultationID.HeaderText = "ConsultationID";
            this.consultationID.Name = "consultationID";
            // 
            // receiptNumber
            // 
            this.receiptNumber.HeaderText = "ReceiptNumber";
            this.receiptNumber.Name = "receiptNumber";
            this.receiptNumber.Width = 150;
            // 
            // paymentStatus
            // 
            this.paymentStatus.HeaderText = "PaymentStatus";
            this.paymentStatus.Name = "paymentStatus";
            // 
            // paymentMethod
            // 
            this.paymentMethod.HeaderText = "PaymentMethod";
            this.paymentMethod.Name = "paymentMethod";
            this.paymentMethod.Width = 150;
            // 
            // paymentDate
            // 
            this.paymentDate.HeaderText = "PaymentDate";
            this.paymentDate.Name = "paymentDate";
            this.paymentDate.Width = 150;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.Width = 150;
            // 
            // txt_searchPayment
            // 
            this.txt_searchPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchPayment.Location = new System.Drawing.Point(12, 12);
            this.txt_searchPayment.Multiline = true;
            this.txt_searchPayment.Name = "txt_searchPayment";
            this.txt_searchPayment.Size = new System.Drawing.Size(486, 33);
            this.txt_searchPayment.TabIndex = 9;
            this.txt_searchPayment.Enter += new System.EventHandler(this.txt_searchPayment_Enter);
            this.txt_searchPayment.Leave += new System.EventHandler(this.txt_searchPayment_Leave);
            // 
            // btn_addPayment
            // 
            this.btn_addPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addPayment.Location = new System.Drawing.Point(794, 11);
            this.btn_addPayment.Name = "btn_addPayment";
            this.btn_addPayment.Size = new System.Drawing.Size(164, 33);
            this.btn_addPayment.TabIndex = 8;
            this.btn_addPayment.Text = "ADD A BILL";
            this.btn_addPayment.UseVisualStyleBackColor = true;
            this.btn_addPayment.Click += new System.EventHandler(this.btn_addPayment_Click);
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 450);
            this.Controls.Add(this.txt_searchPayment);
            this.Controls.Add(this.btn_addPayment);
            this.Controls.Add(this.dgv_payment);
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_payment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn consultationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn paymentStatus;
        private System.Windows.Forms.DataGridViewComboBoxColumn paymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.TextBox txt_searchPayment;
        private System.Windows.Forms.Button btn_addPayment;
    }
}