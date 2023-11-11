using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.BusinessLogicLayer
{
    internal class TraPhongBLL
    {
        private TraPhongDAL traPhongDAL = new TraPhongDAL();

        public void TraPhong(TraPhong traPhong, int idphong,string masv ,int idnguoidung)
        {
            traPhong.NhapThongTinTraPhong();
            traPhong.idnguoidung = idnguoidung;
            traPhong.idphong = idphong;
            traPhong.idsinhvien = masv;
            traPhongDAL.TraPhong(traPhong, idphong);
            Console.WriteLine("Thue phong thanh cong!");
        }

        /*public void GetAllThuePhongs()
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
        }*/
    }
}
