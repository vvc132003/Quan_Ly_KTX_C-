using ketnoicsdllan1.BusinessLogicLayer;
using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.BusinessLogicLayer
{
    internal class PhongBLL
    {
        private PhongDAL phongDAL = new PhongDAL();


        public void GetAllPhong()
        {
            List<Phong> phongs = phongDAL.GetAllPhong();
            if (phongs.Count > 0)
            {
                phongs[0].HienThiTieuDePhong();
                foreach (var phong in phongs)
                {
                    phong.HienThiThongTinPhong();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Không có thông tin phòng nào cả.");
            }
        }

        public void ThemPhong(Phong phong)
        {
            phongDAL.ThemPhong(phong);
        }
        public void CapNhatPhong(Phong phong)
        {
            phongDAL.CapNhatPhong(phong);
        }
        public void XoaPhong(int id)
        {
            phongDAL.XoaPhong(id);
        }
        public Phong LayPhongTheoMa(int id)
        {
            return phongDAL.LayPhongTheoMa(id);
        }
        public void CapNhatSoNguoiO(Phong phong, int songuoio)
        {
            phongDAL.CapNhatSoNguoiO(phong, songuoio);
        }

     }
}
