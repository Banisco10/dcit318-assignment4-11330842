namespace PharmacyApp
{
    partial class MainForm
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
            this.btnAddMedicine = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnUpdateStock = new System.Windows.Forms.Button();
            this.btnRecordSale = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddMedicine
            // 
            this.btnAddMedicine.Location = new System.Drawing.Point(489, 81);
            this.btnAddMedicine.Name = "btnAddMedicine";
            this.btnAddMedicine.Size = new System.Drawing.Size(109, 30);
            this.btnAddMedicine.TabIndex = 0;
            this.btnAddMedicine.Text = "Add Medicine";
            this.btnAddMedicine.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(489, 190);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(98, 378);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(102, 30);
            this.btnViewAll.TabIndex = 2;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            // 
            // btnUpdateStock
            // 
            this.btnUpdateStock.Location = new System.Drawing.Point(277, 378);
            this.btnUpdateStock.Name = "btnUpdateStock";
            this.btnUpdateStock.Size = new System.Drawing.Size(102, 30);
            this.btnUpdateStock.TabIndex = 3;
            this.btnUpdateStock.Text = "Update Stock";
            this.btnUpdateStock.UseVisualStyleBackColor = true;
            // 
            // btnRecordSale
            // 
            this.btnRecordSale.Location = new System.Drawing.Point(443, 378);
            this.btnRecordSale.Name = "btnRecordSale";
            this.btnRecordSale.Size = new System.Drawing.Size(98, 30);
            this.btnRecordSale.TabIndex = 4;
            this.btnRecordSale.Text = "Record Sale";
            this.btnRecordSale.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(195, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(263, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(195, 63);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(263, 20);
            this.txtCategory.TabIndex = 7;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(195, 101);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(263, 20);
            this.txtPrice.TabIndex = 8;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(195, 136);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(263, 20);
            this.txtQuantity.TabIndex = 9;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(195, 196);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(263, 20);
            this.txtSearch.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(55, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Medicine Name";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(55, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(118, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "Category";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(54, 101);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(118, 20);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "Price";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(54, 136);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(118, 20);
            this.textBox4.TabIndex = 14;
            this.textBox4.Text = "Quantity";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(54, 196);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(118, 20);
            this.textBox5.TabIndex = 15;
            this.textBox5.Text = "Search";
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.Location = new System.Drawing.Point(54, 255);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.Size = new System.Drawing.Size(543, 107);
            this.dgvMedicines.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnRecordSale);
            this.Controls.Add(this.btnUpdateStock);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddMedicine);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.btnMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddMedicine;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnUpdateStock;
        private System.Windows.Forms.Button btnRecordSale;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DataGridView dgvMedicines;
    }
}

