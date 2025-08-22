using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace PharmacyApp
{
    public partial class MainForm : Form
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["PharmacyDb"].ConnectionString;

        public MainForm()
        {
            InitializeComponent();

          
            btnAddMedicine.Click += btnAddMedicine_Click;
            btnSearch.Click += btnSearch_Click;
            btnViewAll.Click += btnViewAll_Click;
            btnUpdateStock.Click += btnUpdateStock_Click;
            btnRecordSale.Click += btnRecordSale_Click;

           
            LoadAllMedicines();
        }

       
        private void LoadAllMedicines()
        {
            try
            {
                using (var con = new SqlConnection(_connString))
                using (var cmd = new SqlCommand("GetAllMedicines", con) { CommandType = CommandType.StoredProcedure })
                {
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);                 
                        dgvMedicines.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load medicines.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Fill Name, Category, Price, and Quantity.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out var price) || price < 0)
            {
                MessageBox.Show("Price must be a non-negative number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out var qty) || qty < 0)
            {
                MessageBox.Show("Quantity must be a non-negative integer.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var con = new SqlConnection(_connString))
                using (var cmd = new SqlCommand("AddMedicine", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = txtName.Text.Trim();
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = txtCategory.Text.Trim();
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = qty;

                   
                    var pOut = cmd.Parameters.Add("@NewId", SqlDbType.Int);
                    pOut.Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    var newId = (int)pOut.Value;
                    MessageBox.Show($"Medicine added. New ID = {newId}", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllMedicines();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var term = (txtSearch.Text ?? "").Trim();

            try
            {
                using (var con = new SqlConnection(_connString))
                using (var cmd = new SqlCommand("SearchMedicine", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@SearchTerm", SqlDbType.VarChar, 100).Value = term;

                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        dgvMedicines.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e) => LoadAllMedicines();

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                MessageBox.Show("Select a medicine in the grid first.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out var newQty) || newQty < 0)
            {
                MessageBox.Show("Enter a valid non-negative Quantity.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var medId = Convert.ToInt32(dgvMedicines.CurrentRow.Cells["MedicineID"].Value);

            try
            {
                using (var con = new SqlConnection(_connString))
                using (var cmd = new SqlCommand("UpdateStock", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@MedicineID", SqlDbType.Int).Value = medId;
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = newQty;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Stock updated.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllMedicines();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecordSale_Click(object sender, EventArgs e)
        {
            if (dgvMedicines.CurrentRow == null)
            {
                MessageBox.Show("Select a medicine in the grid first.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out var qtySold) || qtySold <= 0)
            {
                MessageBox.Show("Enter a positive Quantity to sell.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var medId = Convert.ToInt32(dgvMedicines.CurrentRow.Cells["MedicineID"].Value);

            try
            {
                using (var con = new SqlConnection(_connString))
                using (var cmd = new SqlCommand("RecordSale", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@MedicineID", SqlDbType.Int).Value = medId;
                    cmd.Parameters.Add("@QuantitySold", SqlDbType.Int).Value = qtySold;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sale recorded.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllMedicines();
                }
            }
            catch (SqlException ex) 
            {
                MessageBox.Show("Sale failed.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sale failed.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }

        private void btnMainForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

