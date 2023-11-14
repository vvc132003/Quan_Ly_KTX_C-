using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.BusinessLogicLayer
{
    internal class ThueDichVuBLL
    {
        ThueDichVuDAL thueDichVuDAL = new ThueDichVuDAL();
        public void ThemThueDichVu(ThueDichVu thueDichVu, int idNguoiDung, int idThuePhong, int idDichVu, double thanhTien, string idSinhVien)
        {
            thueDichVu.trangthai = "Đã thuê";
            thueDichVuDAL.ThemThueDichVu(thueDichVu, idNguoiDung,  idThuePhong,  idDichVu,  thanhTien,  idSinhVien);
        }
    }
}