using System;
using System.Windows.Forms;

namespace MedicalAppointments
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnDoctors.Click += (s, e) => { using (var f = new DoctorListForm()) f.ShowDialog(); };
            btnBook.Click += (s, e) => { using (var f = new AppointmentForm()) f.ShowDialog(); };
            btnManage.Click += (s, e) => { using (var f = new ManageAppointmentsForm()) f.ShowDialog(); };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {

        }

        private void btnBook_Click(object sender, EventArgs e)
        {

        }

        private void btnManage_Click(object sender, EventArgs e)
        {

        }
    }
}
