using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketnoicsdllan1.BusinessLogicLayer
{
    internal class SinhVienBLL
    {
        private SinhVienDAL studentDAL = new SinhVienDAL();


        public void GetAllStudents()
        {
            List<SinhVien> students = studentDAL.GetAllStudents();
            if (students.Count > 0)
            {
                students[0].HienThiTieuDeSinhVien();
                foreach (var student in students)
                {
                    student.HienThiThongTinSinhVien();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào trong danh sách.");
            }
        }

        public void SapXepSinhVienGiamDanTheoTen()
        {
            List<SinhVien> students = studentDAL.SapXepSinhVienGiamDanTheoTen();
            if (students.Count > 0)
            {
                students[0].HienThiTieuDeSinhVien();
                foreach (var student in students)
                {
                    student.HienThiThongTinSinhVien();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào trong danh sách.");
            }
        }
        public void SapXepSinhVienTangDanTheoTen()
        {
            List<SinhVien> students = studentDAL.SapXepSinhVienTangDanTheoTen();
            if (students.Count > 0)
            {
                students[0].HienThiTieuDeSinhVien();
                foreach (var student in students)
                {
                    student.HienThiThongTinSinhVien();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào trong danh sách.");
            }
        }
        public void SapXepSinhVienTangDanTheoMaPhong()
        {
            List<SinhVien> students = studentDAL.SapXepSinhVienTangDanTheoMaPhong();
            if (students.Count > 0)
            {
                students[0].HienThiTieuDeSinhVien();
                foreach (var student in students)
                {
                    student.HienThiThongTinSinhVien();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào trong danh sách.");
            }
        }
        public void UpdateStudent(SinhVien sinhVien)
        {
            studentDAL.UpdateSinhVien(sinhVien);
        }
        public void UpdateTrangThaiStudent(SinhVien sinhVien, string masv)
        {
            studentDAL.UpdateTrangThaiStudent(sinhVien, masv);
        }

        public void ThemSinhVien(SinhVien student)
        {
            studentDAL.ThemSinhVien(student);
        }
        public Tuple<int, DateTime, string> LayThongTinPhongVaNgayThue(string idsv)
        {
            Tuple<int, DateTime,string> thongTin = studentDAL.LayThongTinPhongVaNgayThue(idsv);
            return thongTin;
        }


        public void CapNhatPhongChoSinhVien(string id, int idphong)
        {
            studentDAL.CapNhatPhongChoSinhVien(id, idphong);
        }

        public List<SinhVien> TimKiemSinhVienTheoTen()
        {
            Console.Write("Nhap ten sinh vien can tim: ");
            string tensinhvien = Console.ReadLine();
            List<SinhVien> sinhviens = studentDAL.TimKiemSinhVienTheoTen(tensinhvien);
            if (sinhviens.Count > 0)
            {
                sinhviens[0].HienThiTieuDeSinhVien();
                foreach (var sinhvien in sinhviens)
                {
                    sinhvien.HienThiThongTinSinhVien();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên với tên này.");
            }
            return sinhviens;
        }


        

    }

}