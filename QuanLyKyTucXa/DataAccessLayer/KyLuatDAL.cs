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
    internal class KyLuatDAL : IKyLuatDAL
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public void ThemKyLuat(KyLuat kyLuat,int idNguoiDung, string idSinhVien)
        {
            connection.Open();
            string query = "INSERT INTO KyLuat (loaivipham, mota, phuongphapxuphat, idnguoidung, idsinhvien, ngayvipham) " +
                              "VALUES (@loaivipham, @mota, @phuongphapxuphat, @idnguoidung, @idsinhvien, @ngayvipham)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@loaivipham", kyLuat.loaivipham);
                command.Parameters.AddWithValue("@mota", kyLuat.mota);
                command.Parameters.AddWithValue("@phuongphapxuphat", kyLuat.phuongphapxuphat);
                command.Parameters.AddWithValue("@idnguoidung", idNguoiDung);
                command.Parameters.AddWithValue("@idsinhvien", idSinhVien);
                command.Parameters.AddWithValue("@ngayvipham", kyLuat.ngayvipham);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
