using System;
using System.Data;
using System.Windows.Forms;
using MedicalAppointments.Data;

namespace MedicalAppointments
{
    public partial class DoctorListForm : Form
    {
        private DataTable _dt;

        public DoctorListForm()
        {
            InitializeComponent();
            LoadGrid();

            btnSearch.Click += (s, e) => ApplyFilter();
            btnReset.Click += (s, e) => { txtSearchName.Clear(); txtSearchSpecialty.Clear(); ApplyFilter(); };

            txtSearchName.TextChanged += (s, e) => ApplyFilter();
            txtSearchSpecialty.TextChanged += (s, e) => ApplyFilter();
        }

        private void LoadGrid()
        {
            try
            {
                _dt = DoctorRepository.GetAllDoctorsTable(); // reader → table
                dgvDoctors.DataSource = _dt;
                dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load doctors.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            if (_dt == null) return;
            var name = txtSearchName.Text.Replace("'", "''");
            var spec = txtSearchSpecialty.Text.Replace("'", "''");
            _dt.DefaultView.RowFilter = $"FullName LIKE '%{name}%' AND Specialty LIKE '%{spec}%'";
        }

        private void DoctorListForm_Load(object sender, EventArgs e)
        {

        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchSpecialty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
