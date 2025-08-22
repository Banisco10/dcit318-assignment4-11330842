using System.Data;
using System.Data.SqlClient;

namespace MedicalAppointments.Data
{
    public static class DoctorRepository
    {
        // For DataGridView binding
        public static DataTable GetAllDoctorsTable()
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT DoctorID, FullName, Specialty, Availability FROM Doctors", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    var dt = new DataTable();
                    dt.Load(reader); // DataReader used to load
                    return dt;
                }
            }
        }
    }
}
