using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace QuanLyKyTucXa.BusinessLogicLayer
{
    internal class DichVuBLL
    {
        DichVuDAL dichVuDAL = new DichVuDAL();
        public void ThemDichVu(DichVu dichVu)
        {
            dichVuDAL.ThemDichVu(dichVu);
        }
       
        public void GetAllDichVu()
        {
            List<DichVu> dichVus = dichVuDAL.GetAllDichVu();
            if (dichVus.Count > 0)
            {
                dichVus[0].HienThiTieuDedichvu();
                foreach (var dichVu in dichVus)
                {
                    dichVu.HienThiThongTinDichVu();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Khong co dich vu nao trong ds.");
            }
        }

        public void CapNhatSoLuongConChoDV(int iddv, int soluongcon)
        {
            dichVuDAL.CapNhatSoLuongConChoDV(iddv, soluongcon);
        }
        public void SuaDichVu(DichVu dichVu)
        {
            dichVuDAL.SuaDichVu(dichVu);
        }

        public void XoaDichVu(int id)
        {
            dichVuDAL.XoaDichVu(id);
        }
        public DichVu LayDichVuTheoTen(string tendichvu)
        {
            return dichVuDAL.LayDichVuTheoTen(tendichvu);
        }
        
    }
}