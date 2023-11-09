using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.BusinessLogicLayer
{
    internal class ChuyenPhonhBLL
    {
        private ChuyenPhonhDAL chuyenPhonhDAL = new ChuyenPhonhDAL();

        public void ChuyenPhong(ChuyenPhong chuyenPhong, int idphongcu, int idphongmoi, string masv)
        {
            chuyenPhong.NhapThongTinChuyenPhong();
            chuyenPhong.idnguoidung = 1;
            chuyenPhong.idphongcu = idphongcu;
            chuyenPhong.idphongmoi = idphongmoi;
            chuyenPhong.idsinhvien = masv;
            chuyenPhonhDAL.ChuyenPhong(chuyenPhong, idphongcu, idphongmoi);
            Console.WriteLine("Chuyen phong thanh cong!");
        }
    }
}
