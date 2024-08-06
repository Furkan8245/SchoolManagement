//using System;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;

//namespace SchoolManagementSystem.Models
//{
//    public class CommonFn
//    {
//        public class Commonfnx
//        {
//            private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SchoolCS"].ConnectionString;

//            public void Query(string query, SqlParameter parameter)
//            {
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        con.Open();
//                        cmd.ExecuteNonQuery();
//                    }
//                }
//            }

//            public DataTable Fetch(string query)
//            {
//                DataTable dt = new DataTable();
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
//                        {
//                            con.Open();
//                            sda.Fill(dt);
//                        }
//                    }
//                }
//                return dt;
//            }

//            // Parametreli Fetch metodunu ekleyin
//            public DataTable Fetch(string query, SqlParameter[] parameters)
//            {
//                DataTable dt = new DataTable();
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        cmd.Parameters.AddRange(parameters);
//                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
//                        {
//                            con.Open();
//                            sda.Fill(dt);
//                        }
//                    }
//                }
//                return dt;
//            }

//            internal void Query(string query, SqlParameter[] parameters)
//            {
//                using (SqlConnection con = new SqlConnection(_connectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand(query, con))
//                    {
//                        cmd.Parameters.AddRange(parameters);
//                        con.Open();
//                        cmd.ExecuteNonQuery();
//                    }
//                }
//            }

//            internal void Query(string v)
//            {
//                throw new NotImplementedException();
//            }
//        }
//    }
//}

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
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCS"].ConnectionString);
            public void Query(string query)
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            public DataTable Fetch(string query)
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }

            internal DataTable Fetch(string query, SqlParameter[] parameters)
            {
                throw new NotImplementedException();
            }

            internal void Query(string insertQuery, SqlParameter[] parameters)
            {
                throw new NotImplementedException();
            }
        }
    }
}
