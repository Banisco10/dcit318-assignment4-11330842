using System;
using System.Data;
using System.Windows.Forms;
using MedicalAppointments.Data;

namespace MedicalAppointments
{
    public partial class ManageAppointmentsForm : Form
    {
        private DataSet _ds;

        public ManageAppointmentsForm()
        {
            InitializeComponent();
            LoadPatients();

            btnLoad.Click += (s, e) => LoadAppointments();
            btnUpdateDate.Click += (s, e) => UpdateSelected();
            btnDelete.Click += (s, e) => DeleteSelected();
        }

        private void LoadPatients()
        {
            try
            {
                var patients = PatientRepository.GetAllPatientsTable();
                cboPatient.DataSource = patients;
                cboPatient.DisplayMember = "FullName";
                cboPatient.ValueMember = "PatientID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load patients.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAppointments()
        {
            if (cboPatient.SelectedValue == null) return;
            int patientId = Convert.ToInt32(cboPatient.SelectedValue);
            try
            {
                _ds = AppointmentRepository.GetAppointmentsForPatient(patientId); // DataAdapter → DataSet
                dgvAppts.DataSource = _ds.Tables["Appointments"];
                dgvAppts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load appointments.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? SelectedAppointmentId()
        {
            if (dgvAppts.CurrentRow == null) return null;
            var cell = dgvAppts.CurrentRow.Cells["AppointmentID"];
            return cell?.Value == null ? (int?)null : Convert.ToInt32(cell.Value);
        }

        private void UpdateSelected()
        {
            try
            {
                var id = SelectedAppointmentId();
                if (id == null)
                {
                    MessageBox.Show("Select an appointment.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DateTime newDate = dtpNewDate.Value;
                if (newDate < DateTime.Now.AddMinutes(-1))
                {
                    MessageBox.Show("New date must be in the future.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rows = AppointmentRepository.UpdateAppointmentDate(id.Value, newDate);
                if (rows == 1)
                {
                    MessageBox.Show("Updated.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteSelected()
        {
            try
            {
                var id = SelectedAppointmentId();
                if (id == null)
                {
                    MessageBox.Show("Select an appointment.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Delete this appointment?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rows = AppointmentRepository.DeleteAppointment(id.Value);
                    if (rows == 1)
                    {
                        MessageBox.Show("Deleted.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAppointments();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageAppointmentsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
