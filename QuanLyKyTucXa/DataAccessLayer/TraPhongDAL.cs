using ketnoicsdllan1;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
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
            using (SqlCommand command = new SqlCommand("TraPhongs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
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
            using (SqlCommand command = new SqlCommand("GetAllTinTraPhong", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    command.CommandType = CommandType.StoredProcedure;
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
