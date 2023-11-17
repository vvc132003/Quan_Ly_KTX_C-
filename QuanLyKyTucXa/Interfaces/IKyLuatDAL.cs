using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.DataAccessLayer
{
    internal interface IKyLuatDAL
    {
        void ThemKyLuat(KyLuat kyLuat, int idNguoiDung, string idSinhVien);
    }
}