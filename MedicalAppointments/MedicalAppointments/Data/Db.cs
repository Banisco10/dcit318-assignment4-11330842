using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace MedicalAppointments.Data
{
    public static class Db
    {
        public static SqlConnection GetConnection()
            => new SqlConnection(ConfigurationManager.ConnectionStrings["MedicalDb"].ConnectionString);
    }
}
