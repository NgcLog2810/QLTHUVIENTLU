using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYTHUVIENTLU
{
    public static class DataAccess
    {
        private static string connectionString = @"Data Source=LAPTOP-SODI0Q1O;Initial Catalog=QLTV;Integrated Security=True;TrustServerCertificate=True";

        // 1. Hàm lấy dữ liệu (SELECT) → trả về DataTable
        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm parameters nếu có (an toàn chống SQL Injection)
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thực hiện truy vấn:\n" + ex.Message);
                    }
                }
            }

            return dt;
        }

        // 2. Hàm thực thi lệnh không trả dữ liệu (INSERT, UPDATE, DELETE) → trả về số dòng bị ảnh hưởng
        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thực thi lệnh:\n" + ex.Message);
                    }
                }
            }
        }

        // 3. Hàm lấy giá trị đơn (ví dụ: COUNT(*), MAX(maSach), ...)
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi lấy giá trị đơn:\n" + ex.Message);
                    }
                }
            }
        }
    }
}
