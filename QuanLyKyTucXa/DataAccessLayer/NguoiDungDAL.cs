using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ketnoicsdllan1;

namespace QuanLyKyTucXa.DataAccessLayer
{
    internal class NguoiDungDAL
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public NguoiDung CheckThongTinDangNhap(string matkhau, string tendangnhap)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string query = "SELECT matkhau, tendangnhap FROM NguoiDung WHERE tendangnhap = @tendangnhap AND matkhau = @matkhau";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                command.Parameters.AddWithValue("@matkhau", matkhau);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NguoiDung { tendangnhap = reader["tendangnhap"].ToString() };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void CapNhatMatKhau(string tendangnhap, string matkhaumoi)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string updateQuery = "UPDATE NguoiDung SET matkhau = @matkhau WHERE tendangnhap = @tendangnhap";
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@matkhau", matkhaumoi);
                command.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
