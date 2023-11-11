using ketnoicsdllan1.BusinessLogicLayer;
using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKyTucXa.BusinessLogicLayer
{
    internal class NguoiDungBLL
    {
        private NguoiDungDAL nguoiDungDAL = new NguoiDungDAL();

        public string CheckThongTinDangNhap()
        {
            Console.WriteLine("Nhap thong tin dang nhap:");
            Console.Write("Ten dang nhap: ");
            string tendangnhap = Console.ReadLine();
            Console.Write("Mat khau: ");
            string matkhau = Console.ReadLine();
            if (nguoiDungDAL.CheckThongTinDangNhap(matkhau, tendangnhap) != null)
            {
                return tendangnhap;
            }
            else
            {
                Console.WriteLine("Ten dang nhap hoac mat khau bi sai!!!");
                return null;
            }
        }

        public int LayIDNguoiDung(string tendangnhap)
        {
            int idnguoidung = nguoiDungDAL.LayIDNguoiDung(tendangnhap);
            return idnguoidung;
        }
        public void CapNhatMatKhau()
        {
            Console.Write("Nhap ten dang nhap: ");
            string tendangnhap = Console.ReadLine();
            Console.Write("Nhap mat khau cu: ");
            string matkhaucu = Console.ReadLine();
            Console.Write("Nhap mat khau moi: ");
            string matkhaumoi = Console.ReadLine();
            Console.Write("Nhap lai mat khau moi: ");
            string nhaplaimatkhaumoi = Console.ReadLine();
            if (nguoiDungDAL.CheckThongTinDangNhap(matkhaucu, tendangnhap) != null)
            {
                if(matkhaumoi == nhaplaimatkhaumoi)
                {
                    nguoiDungDAL.CapNhatMatKhau(tendangnhap, matkhaumoi);
                    Console.WriteLine("Doi mat khau thanh cong!!!");
                }
                else
                {
                    Console.WriteLine("Ban nhap lai mat khau moi khong dung!!!");
                }
            }
            else
            {
                Console.WriteLine("Ten dang nhap hoac mat khau bi sai!!!");
            }
        }

    }
}