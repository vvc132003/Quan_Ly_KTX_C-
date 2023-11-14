using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.BusinessLogicLayer
{
    internal class ThuePhongBll
    {
        private ThuePhonhDAL thuePhonhDAL = new ThuePhonhDAL();

        public void ThuePhong(String masv, int idphong, int idnguoidung, DateTime ngaythue)
        {
            ThuePhong thuePhong = new ThuePhong();
            thuePhong.idsinhvien = masv;
            thuePhong.ngaythue = ngaythue;
            thuePhong.trangthai = "Đã thuê";
            thuePhong.idnguoidung = idnguoidung;
            thuePhong.idphong = idphong;
            thuePhonhDAL.ThuePhong(thuePhong);
            Console.WriteLine("Thue phong thanh cong!");
        }

        public void GetAllThuePhongs()
        {
            List<ThuePhong> thuephongs = thuePhonhDAL.GetAllTinThuePhong();
            if (thuephongs.Count > 0)
            {
                thuephongs[0].HienThiTieuDeThuePhong();
                foreach (var thuephong in thuephongs)
                {
                    thuephong.HienThiThongTinThuePhong();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào trong danh sách.");
            }
        }
        public int LayMaThuePhongTheoIDSV(string masv)
        {
            int idthuephong = thuePhonhDAL.LayMaThuePhongTheoIDSV(masv);
            return idthuephong;
        }

    }

}
