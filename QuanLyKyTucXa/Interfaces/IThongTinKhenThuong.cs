using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.Interfaces
{
    internal interface IThongTinKhenThuong
    {
        void ThemKhenThuong(ThongTinKhenThuong thongTinKhenThuong, string idsinhvien, int idnguoidung);
        void SuaKhenThuong(ThongTinKhenThuong thongTinKhenThuong);
        void XoaKhenThuong(int id);
        List<ThongTinKhenThuong> GetAllKhenThuong();
        List<ThongTinKhenThuong> GetAllKhenThuongID(int id);
    }
}
