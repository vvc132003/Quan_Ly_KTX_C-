using ketnoicsdllan1;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataAccessLayer
{
    internal class ThuePhonhDAL
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public void ThuePhong(ThuePhong thuePhong)
        {
            connection.Open();
            string query = "INSERT INTO ThuePhong (idnguoidung, idphong, trangthai, idsinhvien, ngaythue) " +
                           "VALUES (@idnguoidung, @idphong, @trangthai, @idsinhvien, @ngaythue)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idnguoidung", thuePhong.idnguoidung);
                command.Parameters.AddWithValue("@idphong", thuePhong.idphong);
                command.Parameters.AddWithValue("@trangthai", thuePhong.trangthai);
                command.Parameters.AddWithValue("@idsinhvien", thuePhong.idsinhvien);
                command.Parameters.AddWithValue("@ngaythue", thuePhong.ngaythue);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public List<ThuePhong> GetAllTinThuePhong()
        {
            List<ThuePhong> danhSachThuePhong = new List<ThuePhong>();

            connection.Open();

            string query = "SELECT * FROM ThuePhong";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ThuePhong thuePhong = new ThuePhong
                        {
                            id = Convert.ToInt32(reader["id"]),
                            idsinhvien = reader["idsinhvien"].ToString(),
                            idphong = Convert.ToInt32(reader["idphong"]),
                            ngaythue = (DateTime)reader["ngaythue"],
                            trangthai = reader["trangthai"].ToString()
                        };
                        danhSachThuePhong.Add(thuePhong);
                    }
                }
            }

            // Đóng kết nối
            connection.Close();

            return danhSachThuePhong;
        }
    }
}
