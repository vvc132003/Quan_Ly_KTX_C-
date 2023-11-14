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
    internal class ThueDichVuDAL
    {
        private SqlConnection connection = DBUtils.GetDBConnection();
        public void ThemThueDichVu(ThueDichVu thueDichVu ,int idNguoiDung, int idThuePhong, int idDichVu,double thanhTien, string idSinhVien)
        {
            connection.Open();
            string query = "INSERT INTO ThueDichVu (idnguoidung, idthuephong, iddichvu, soluongthue, thanhtien, idsinhvien, trangthai, ngaythue) " +
                           "VALUES (@IdNguoiDung, @IdThuePhong, @IdDichVu, @SoLuongThue, @ThanhTien, @IdSinhVien, @TrangThai, @NgayThue)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdNguoiDung", idNguoiDung);
                command.Parameters.AddWithValue("@IdThuePhong", idThuePhong);
                command.Parameters.AddWithValue("@IdDichVu", idDichVu);
                command.Parameters.AddWithValue("@SoLuongThue", thueDichVu.soluongthue);
                command.Parameters.AddWithValue("@ThanhTien", thanhTien);
                command.Parameters.AddWithValue("@IdSinhVien", idSinhVien);
                command.Parameters.AddWithValue("@TrangThai", thueDichVu.trangthai);
                command.Parameters.AddWithValue("@NgayThue", thueDichVu.ngaythue);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

    }
}
