using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagementSystem.Models
{
    public class CommonFn
    {
        public class Commonfnx
        {
            private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SchoolCS"].ConnectionString;

            public void Query(string query)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public DataTable Fetch(string query)
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            con.Open();
                            sda.Fill(dt);
                        }
                    }
                }
                return dt;
            }


            internal void Query(string query, SqlParameter[] parameters)
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddRange(parameters);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
