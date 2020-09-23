using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementWebApp.Gateway
{
    public class BaseGateway
    {
        private string connectionString = WebConfigurationManager.
                                         ConnectionStrings["universityManagementDBConString"].
                                         ConnectionString;
        public SqlConnection Connection { get; set; }

        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public BaseGateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}