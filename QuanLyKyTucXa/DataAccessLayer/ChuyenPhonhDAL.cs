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
    internal class ChuyenPhonhDAL
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public void ChuyenPhong(ChuyenPhong chuyenPhong, int idphongcu , int idphongmoi)
        {
            connection.Open();
            string query = "INSERT INTO ChuyenPhong (idsinhvien, idnguoidung, idphongcu, idphongmoi, lydo, ngaychuyen) " +
                           "VALUES (@idsinhvien, @idnguoidung, @idphongcu, @idphongmoi, @lydo, @ngaychuyen)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idsinhvien", chuyenPhong.idsinhvien);
                command.Parameters.AddWithValue("@idnguoidung", chuyenPhong.idnguoidung);
                command.Parameters.AddWithValue("@idphongcu",  idphongcu);
                command.Parameters.AddWithValue("@idphongmoi", idphongmoi);
                command.Parameters.AddWithValue("@lydo", chuyenPhong.lydo);
                command.Parameters.AddWithValue("@ngaychuyen", chuyenPhong.ngaychuyen);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
