namespace MedicalAppointments
{
    partial class ManageAppointmentsForm
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnUpdateDate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cboPatient = new System.Windows.Forms.ComboBox();
            this.dgvAppts = new System.Windows.Forms.DataGridView();
            this.dtpNewDate = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(210, 349);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 36);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnUpdateDate
            // 
            this.btnUpdateDate.Location = new System.Drawing.Point(352, 349);
            this.btnUpdateDate.Name = "btnUpdateDate";
            this.btnUpdateDate.Size = new System.Drawing.Size(87, 36);
            this.btnUpdateDate.TabIndex = 1;
            this.btnUpdateDate.Text = "Update";
            this.btnUpdateDate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(479, 349);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // cboPatient
            // 
            this.cboPatient.FormattingEnabled = true;
            this.cboPatient.Location = new System.Drawing.Point(176, 86);
            this.cboPatient.Name = "cboPatient";
            this.cboPatient.Size = new System.Drawing.Size(121, 21);
            this.cboPatient.TabIndex = 3;
            // 
            // dgvAppts
            // 
            this.dgvAppts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppts.Location = new System.Drawing.Point(176, 131);
            this.dgvAppts.Name = "dgvAppts";
            this.dgvAppts.Size = new System.Drawing.Size(411, 199);
            this.dgvAppts.TabIndex = 4;
            // 
            // dtpNewDate
            // 
            this.dtpNewDate.Location = new System.Drawing.Point(387, 87);
            this.dtpNewDate.Name = "dtpNewDate";
            this.dtpNewDate.Size = new System.Drawing.Size(200, 20);
            this.dtpNewDate.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(176, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Select Your Name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(387, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Change your Appointment Date";
            // 
            // ManageAppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dtpNewDate);
            this.Controls.Add(this.dgvAppts);
            this.Controls.Add(this.cboPatient);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdateDate);
            this.Controls.Add(this.btnLoad);
            this.Name = "ManageAppointmentsForm";
            this.Text = "ManageAppointmentForm";
            this.Load += new System.EventHandler(this.ManageAppointmentsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnUpdateDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cboPatient;
        private System.Windows.Forms.DataGridView dgvAppts;
        private System.Windows.Forms.DateTimePicker dtpNewDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}