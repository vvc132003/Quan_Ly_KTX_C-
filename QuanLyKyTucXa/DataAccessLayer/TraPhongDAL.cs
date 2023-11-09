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
    internal class TraPhongDAL
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public void TraPhong(TraPhong traPhong, int idphong)
        {
            connection.Open();
            string query = "INSERT INTO TraPhong (idsinhvien, idnguoidung, idphong, lydo, ngaytra) " +
                           "VALUES (@idsinhvien, @idnguoidung, @idphong, @lydo, @ngaytra)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idsinhvien", traPhong.idsinhvien);
                command.Parameters.AddWithValue("@idnguoidung", traPhong.idnguoidung);
                command.Parameters.AddWithValue("@idphong", idphong);
                command.Parameters.AddWithValue("@lydo", traPhong.lydo);
                command.Parameters.AddWithValue("@ngaytra", traPhong.ngaytra);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public List<TraPhong> GetAllTinTraPhong()
        {
            List<TraPhong> danhSachTraPhong = new List<TraPhong>();

            connection.Open();

            string query = "SELECT * FROM TraPhong";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TraPhong traPhong = new TraPhong
                        {
                            id = Convert.ToInt32(reader["id"]),
                            idsinhvien = reader["idsinhvien"].ToString(),
                            idphong = Convert.ToInt32(reader["idphong"]),
                            ngaytra = (DateTime)reader["ngaytra"],
                            lydo = reader["lydo"].ToString(),
                        };
                        danhSachTraPhong.Add(traPhong);
                    }
                }
            }

            // Đóng kết nối
            connection.Close();

            return danhSachTraPhong;
        }

    }
}
