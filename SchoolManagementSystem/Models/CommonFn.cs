////using System;
////using System.Configuration;
////using System.Data;
////using System.Data.SqlClient;

////namespace SchoolManagementSystem.Models
////{
////    public class CommonFn
////    {
////        public class Commonfnx
////        {
////            private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SchoolCS"].ConnectionString;

////            public void Query(string query, SqlParameter parameter)
////            {
////                using (SqlConnection con = new SqlConnection(_connectionString))
////                {
////                    using (SqlCommand cmd = new SqlCommand(query, con))
////                    {
////                        con.Open();
////                        cmd.ExecuteNonQuery();
////                    }
////                }
////            }

////            public DataTable Fetch(string query)
////            {
////                DataTable dt = new DataTable();
////                using (SqlConnection con = new SqlConnection(_connectionString))
////                {
////                    using (SqlCommand cmd = new SqlCommand(query, con))
////                    {
////                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
////                        {
////                            con.Open();
////                            sda.Fill(dt);
////                        }
////                    }
////                }
////                return dt;
////            }

////            // Parametreli Fetch metodunu ekleyin
////            public DataTable Fetch(string query, SqlParameter[] parameters)
////            {
////                DataTable dt = new DataTable();
////                using (SqlConnection con = new SqlConnection(_connectionString))
////                {
////                    using (SqlCommand cmd = new SqlCommand(query, con))
////                    {
////                        cmd.Parameters.AddRange(parameters);
////                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
////                        {
////                            con.Open();
////                            sda.Fill(dt);
////                        }
////                    }
////                }
////                return dt;
////            }

////            internal void Query(string query, SqlParameter[] parameters)
////            {
////                using (SqlConnection con = new SqlConnection(_connectionString))
////                {
////                    using (SqlCommand cmd = new SqlCommand(query, con))
////                    {
////                        cmd.Parameters.AddRange(parameters);
////                        con.Open();
////                        cmd.ExecuteNonQuery();
////                    }
////                }
////            }

////            internal void Query(string v)
////            {
////                throw new NotImplementedException();
////            }
////        }
////    }
////}

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
//            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCS"].ConnectionString);
//            public void Query(string query)
//            {
//                if (conn.State == ConnectionState.Closed)
//                {
//                    conn.Open();
//                }
//                SqlCommand cmd = new SqlCommand(query, conn);
//                cmd.ExecuteNonQuery();
//                conn.Close();
//            }
//            public DataTable Fetch(string query)
//            {
//                DataTable dt = new DataTable();
//                string connectionString = ConfigurationManager.ConnectionStrings["SchoolCS"].ConnectionString;

//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand(query, conn))
//                    {
//                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
//                        {
//                            try
//                            {
//                                conn.Open();
//                                sda.Fill(dt);
//                            }
//                            catch (SqlException ex)
//                            {
//                                // Hata mesajını loglayın veya yönetin
//                                Console.WriteLine("SQL Hatası: " + ex.Message);
//                            }
//                        }
//                    }
//                }
//                return dt;
//            }




//            internal void Query(string insertQuery, SqlParameter[] parameters)
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
            private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SchoolCS"].ConnectionString;

            public void Query(string query)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Hata mesajını loglayın veya yönetin
                        Console.WriteLine("SQL Hatası: " + ex.Message);
                    }
                }
            }

            public DataTable Fetch(string query)
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                conn.Open();
                                sda.Fill(dt);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Hata mesajını loglayın veya yönetin
                        Console.WriteLine("SQL Hatası: " + ex.Message);
                    }
                }
                return dt;
            }

            public void Query(string query, SqlParameter[] parameters)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddRange(parameters);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Hata mesajını loglayın veya yönetin
                        Console.WriteLine("SQL Hatası: " + ex.Message);
                    }
                }
            }

            // Parametreli Fetch metodu
            public DataTable Fetch(string query, SqlParameter[] parameters)
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddRange(parameters);
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                conn.Open();
                                sda.Fill(dt);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Hata mesajını loglayın veya yönetin
                        Console.WriteLine("SQL Hatası: " + ex.Message);
                    }
                }
                return dt;
            }
        }
    }
}

