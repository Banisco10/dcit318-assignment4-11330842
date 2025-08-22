using System.Data;
using System.Data.SqlClient;

namespace MedicalAppointments.Data
{
    public static class PatientRepository
    {
        public static DataTable GetAllPatientsTable()
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT PatientID, FullName, Email FROM Patients", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }
    }
}
