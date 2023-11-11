using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.BusinessLogicLayer
{
    internal class ChuyenPhongBLL
    {
        private ChuyenPhongDAL chuyenPhonhDAL = new ChuyenPhongDAL();

        public void ChuyenPhong(ChuyenPhong chuyenPhong, int idphongcu, int idphongmoi, string masv, int idnguoidung)
        {
            chuyenPhong.idnguoidung = idnguoidung;
            chuyenPhong.idphongcu = idphongcu;
            chuyenPhong.idphongmoi = idphongmoi;
            chuyenPhong.idsinhvien = masv;
            chuyenPhonhDAL.ChuyenPhong(chuyenPhong, idphongcu, idphongmoi);
            Console.WriteLine("Chuyen phong thanh cong!");
        }
    }
}
