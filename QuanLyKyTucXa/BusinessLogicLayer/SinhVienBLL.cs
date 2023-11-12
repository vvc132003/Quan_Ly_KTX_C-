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
        public void UpdateStudent(SinhVien sinhVien)
        {
            studentDAL.UpdateSinhVien(sinhVien);
        }
        public void UpdateTrangThaiStudent(SinhVien sinhVien, string masv)
        {
            sinhVien.trang_thai = "Đã trả";
            studentDAL.UpdateTrangThaiStudent(sinhVien, masv);
        }

        public void ThemSinhVien(SinhVien student)
        {
            studentDAL.ThemSinhVien(student);
        }
        public Tuple<int, DateTime> LayThongTinPhongVaNgayThue(string idsv)
        {
            Tuple<int, DateTime> thongTin = studentDAL.LayThongTinPhongVaNgayThue(idsv);
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


        /* public void UpdateStudent(Student student)
         {
             if (student.StudentID > 0 && !string.IsNullOrWhiteSpace(student.Name) && student.Age > 0)
             {
                 studentDAL.UpdateStudent(student);
                 Console.WriteLine("Thông tin sinh viên đã được cập nhật.");
             }
             else
             {
                 Console.WriteLine("Thông tin sinh viên không hợp lệ.");
             }
         }

         public void DeleteStudent(int studentID)
         {
             studentDAL.DeleteStudent(studentID);
         }

         public List<Student> SearchStudentsByName()
         {
             Console.Write("Nhập tên sinh viên cần tìm: ");
             string searchName = Console.ReadLine();
             List<Student> searchResults = studentDAL.SearchStudentsByName(searchName);
             if (searchResults.Count > 0)
             {
                 Console.WriteLine("Kết quả tìm kiếm:");
                 Console.WriteLine("{0, -5} {1, -20} {2, 5}", "ID", "Tên", "Tuổi");
                 foreach (var foundStudent in searchResults)
                 {
                     Console.WriteLine("{0, -5} {1, -20} {2, 5}", foundStudent.StudentID, foundStudent.Name, foundStudent.Age);
                 }
             }
             else
             {
                 Console.WriteLine("Không tìm thấy sinh viên với tên này.");
             }
             return searchResults;
         }
         public List<Student> GetStudentsSortedByNameDescending()
         {
             List<Student> sapxeptang = studentDAL.GetStudentsSortedByNameDescending();

             if (sapxeptang.Count > 0)
             {
                 Console.WriteLine("Danh sách sinh viên theo tên giảm dần:");
                 Console.WriteLine("{0, -5} {1, -20} {2, 5}", "ID", "Tên", "Tuổi");
                 foreach (var foundStudent in sapxeptang)
                 {
                     Console.WriteLine("{0, -5} {1, -20} {2, 5}", foundStudent.StudentID, foundStudent.Name, foundStudent.Age);
                 }
             }
             else
             {
                 Console.WriteLine("Không có sinh viên nào trong danh sách.");
             }

             return sapxeptang;
         }


         public List<Student> GetStudentsSortedByNameAscending()
         {
             List<Student> sapxepgiam = studentDAL.GetStudentsSortedByNameAscending();

             if (sapxepgiam.Count > 0)
             {
                 Console.WriteLine("Kết quả tìm kiếm:");
                 Console.WriteLine("{0, -5} {1, -20} {2, 5}", "ID", "Tên", "Tuổi");
                 foreach (var foundStudent in sapxepgiam)
                 {
                     Console.WriteLine("{0, -5} {1, -20} {2, 5}", foundStudent.StudentID, foundStudent.Name, foundStudent.Age);
                 }
             }
             else
             {
                 Console.WriteLine("Không tìm thấy sinh viên với tên này.");
             }

             return sapxepgiam;

         }*/

    }

}