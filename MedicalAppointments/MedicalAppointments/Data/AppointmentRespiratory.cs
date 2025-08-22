using System;
using System.Data;
using System.Data.SqlClient;

namespace MedicalAppointments.Data
{
    public static class AppointmentRepository
    {
        public static bool DoctorIsAvailable(int doctorId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new SqlCommand("SELECT Availability FROM Doctors WHERE DoctorID=@DoctorID", conn))
            {
                cmd.Parameters.Add("@DoctorID", SqlDbType.Int).Direction = ParameterDirection.Input;
                cmd.Parameters["@DoctorID"].Value = doctorId;

                conn.Open();
                var x = cmd.ExecuteScalar();
                return x != null && Convert.ToBoolean(x);
            }
        }

        public static bool SlotIsFree(int doctorId, DateTime when)
        {
            const string sql = @"SELECT COUNT(*) FROM Appointments
                                 WHERE DoctorID=@DoctorID AND AppointmentDate=@When";
            using (var conn = Db.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@DoctorID", SqlDbType.Int).Value = doctorId;
                cmd.Parameters.Add("@When", SqlDbType.DateTime).Value = when;

                conn.Open();
                return (int)cmd.ExecuteScalar() == 0;
            }
        }

        public static int InsertAppointment(int doctorId, int patientId, DateTime when, string notes)
        {
            const string sql = @"INSERT INTO Appointments(DoctorID, PatientID, AppointmentDate, Notes)
                                 VALUES(@DoctorID, @PatientID, @When, @Notes)";
            using (var conn = Db.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@DoctorID", SqlDbType.Int).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@PatientID", SqlDbType.Int).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@When", SqlDbType.DateTime).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@Notes", SqlDbType.VarChar, 500).Direction = ParameterDirection.Input;

                cmd.Parameters["@DoctorID"].Value = doctorId;
                cmd.Parameters["@PatientID"].Value = patientId;
                cmd.Parameters["@When"].Value = when;
                cmd.Parameters["@Notes"].Value = (object)notes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Display with DataAdapter + DataSet (as required)
        public static DataSet GetAppointmentsForPatient(int patientId)
        {
            const string sql = @"SELECT a.AppointmentID,
                                        d.FullName AS Doctor,
                                        d.Specialty,
                                        a.AppointmentDate,
                                        a.Notes
                                 FROM Appointments a
                                 JOIN Doctors d ON d.DoctorID=a.DoctorID
                                 WHERE a.PatientID=@PatientID
                                 ORDER BY a.AppointmentDate DESC";

            using (var conn = Db.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@PatientID", SqlDbType.Int).Value = patientId;
                using (var da = new SqlDataAdapter(cmd))
                {
                    var ds = new DataSet();
                    da.Fill(ds, "Appointments");
                    return ds;
                }
            }
        }

        public static int UpdateAppointmentDate(int appointmentId, DateTime newDate)
        {
            const string sql = "UPDATE Appointments SET AppointmentDate=@NewDate WHERE AppointmentID=@Id";
            using (var conn = Db.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@NewDate", SqlDbType.DateTime).Value = newDate;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = appointmentId;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int DeleteAppointment(int appointmentId)
        {
            const string sql = "DELETE FROM Appointments WHERE AppointmentID=@Id";
            using (var conn = Db.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = appointmentId;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
