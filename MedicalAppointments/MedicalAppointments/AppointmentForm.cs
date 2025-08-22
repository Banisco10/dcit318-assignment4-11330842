using System;
using System.Data;
using System.Windows.Forms;
using MedicalAppointments.Data;

namespace MedicalAppointments
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            LoadCombos();
            btnBook.Click += BtnBook_Click;
        }

        private void LoadCombos()
        {
            try
            {
                var doctors = DoctorRepository.GetAllDoctorsTable();
                cboDoctor.DataSource = doctors;
                cboDoctor.DisplayMember = "FullName";
                cboDoctor.ValueMember = "DoctorID";

                var patients = PatientRepository.GetAllPatientsTable();
                cboPatient.DataSource = patients;
                cboPatient.DisplayMember = "FullName";
                cboPatient.ValueMember = "PatientID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load lists.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboDoctor.SelectedValue == null || cboPatient.SelectedValue == null)
                {
                    MessageBox.Show("Select a doctor and a patient.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int doctorId = Convert.ToInt32(cboDoctor.SelectedValue);
                int patientId = Convert.ToInt32(cboPatient.SelectedValue);
                DateTime when = dtpWhen.Value;
                string notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();

                if (when < DateTime.Now.AddMinutes(-1))
                {
                    MessageBox.Show("Appointment must be in the future.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!AppointmentRepository.DoctorIsAvailable(doctorId))
                {
                    MessageBox.Show("Doctor is not available.", "Unavailable",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!AppointmentRepository.SlotIsFree(doctorId, when))
                {
                    MessageBox.Show("This time slot is already taken.", "Conflict",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int rows = AppointmentRepository.InsertAppointment(doctorId, patientId, when, notes);
                if (rows == 1)
                {
                    MessageBox.Show("Appointment booked.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("No changes made.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Booking failed.\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpWhen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {

        }

        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
