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
    internal class ChuyenPhongDAL
    {
        private SqlConnection connection = DBUtils.GetDBConnection();

        public void ChuyenPhong(ChuyenPhong chuyenPhong, int idphongcu , int idphongmoi)
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("ChuyenPhongs", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
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