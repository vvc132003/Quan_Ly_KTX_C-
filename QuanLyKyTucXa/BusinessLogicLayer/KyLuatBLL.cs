using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.BusinessLogicLayer
{
    internal class KyLuatBLL
    {
        KyLuatDAL kyLuatDAL = new KyLuatDAL();
        public void ThemKyLuat(KyLuat kyLuat, int idNguoiDung, string idSinhVien)
        {
            kyLuatDAL.ThemKyLuat(kyLuat, idNguoiDung, idSinhVien);
        }
    }
}