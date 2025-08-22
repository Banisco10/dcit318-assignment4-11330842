namespace MedicalAppointments
{
    partial class AppointmentForm
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
            this.btnBook = new System.Windows.Forms.Button();
            this.cboPatient = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.dtpWhen = new System.Windows.Forms.DateTimePicker();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(288, 317);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(147, 35);
            this.btnBook.TabIndex = 0;
            this.btnBook.Text = "Book Appointment";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click_1);
            // 
            // cboPatient
            // 
            this.cboPatient.FormattingEnabled = true;
            this.cboPatient.Location = new System.Drawing.Point(86, 56);
            this.cboPatient.Name = "cboPatient";
            this.cboPatient.Size = new System.Drawing.Size(121, 21);
            this.cboPatient.TabIndex = 1;
            this.cboPatient.Text = "Select Your Name";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(86, 93);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(536, 200);
            this.txtNotes.TabIndex = 2;
            this.txtNotes.Text = "Write Notes here";
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // dtpWhen
            // 
            this.dtpWhen.Location = new System.Drawing.Point(415, 57);
            this.dtpWhen.Name = "dtpWhen";
            this.dtpWhen.Size = new System.Drawing.Size(207, 20);
            this.dtpWhen.TabIndex = 3;
            this.dtpWhen.ValueChanged += new System.EventHandler(this.dtpWhen_ValueChanged);
            // 
            // cboDoctor
            // 
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(229, 56);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(121, 21);
            this.cboDoctor.TabIndex = 4;
            this.cboDoctor.Text = "Select Doctor";
            this.cboDoctor.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Select Your Name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(229, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Select Doctor";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(415, 31);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(207, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Select Your Appointment Date";
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cboDoctor);
            this.Controls.Add(this.dtpWhen);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cboPatient);
            this.Controls.Add(this.btnBook);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.ComboBox cboPatient;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.DateTimePicker dtpWhen;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}