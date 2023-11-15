using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using QuanLyKyTucXa.BusinessLogicLayer;
using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
        public bool KiemTraTonTaiMaSinhVien(string masv)
        {
            return studentDAL.KiemTraTonTaiMaSinhVien(masv);
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
        public Tuple<int, DateTime, string,int> LayThongTinPhongVaNgayThue(string idsv)
        {
            Tuple<int, DateTime,string,int> thongTin = studentDAL.LayThongTinPhongVaNgayThue(idsv);
            return thongTin;
        }


        public void CapNhatPhongChoSinhVien(string id, int idphong)
        {
            studentDAL.CapNhatPhongChoSinhVien(id, idphong);
        }

        public void CapNhatSoLanViPhamChoSinhVien(string id, int solanvipham)
        {
            studentDAL.CapNhatSoLanViPhamChoSinhVien (id, solanvipham);
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

        public void ExportAllDichVuToExcel()
        {
            List<SinhVien> sinhviens = studentDAL.GetAllStudents();
            string filePath = "C:\\Users\\vvc13\\OneDrive\\Documents\\sinhvien.xlsx";

            IWorkbook workbook = new XSSFWorkbook();
            ISheet worksheet = workbook.CreateSheet("DanhSachSinhVien");

            IRow headerRow = worksheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Id");
            headerRow.CreateCell(1).SetCellValue("Tên sinh viên");
            headerRow.CreateCell(2).SetCellValue("Khóa học");
            headerRow.CreateCell(3).SetCellValue("Ngành học");
            headerRow.CreateCell(4).SetCellValue("Email");
            headerRow.CreateCell(5).SetCellValue("Số điện thoại");
            headerRow.CreateCell(6).SetCellValue("Id phòng");
            headerRow.CreateCell(7).SetCellValue("Giới tính");
            headerRow.CreateCell(8).SetCellValue("Quê quán");
            headerRow.CreateCell(9).SetCellValue("Trạng thái");
            headerRow.CreateCell(10).SetCellValue("Số lần vi phạm");
            headerRow.CreateCell(11).SetCellValue("Ngày vào");
            headerRow.CreateCell(12).SetCellValue("Ngày sinh");


            int rowIndex = 1;
            foreach (var sinhvien in sinhviens)
            {
                IRow dataRow = worksheet.CreateRow(rowIndex);
                dataRow.CreateCell(0).SetCellValue(sinhvien.id);
                dataRow.CreateCell(1).SetCellValue(sinhvien.tensinhvien);
                dataRow.CreateCell(2).SetCellValue(sinhvien.khoahoc);
                dataRow.CreateCell(3).SetCellValue(sinhvien.nganhhoc);
                dataRow.CreateCell(4).SetCellValue(sinhvien.email);
                dataRow.CreateCell(5).SetCellValue(sinhvien.sodienthoai);
                dataRow.CreateCell(6).SetCellValue(sinhvien.idphong); 
                dataRow.CreateCell(7).SetCellValue(sinhvien.gioitinh);
                dataRow.CreateCell(8).SetCellValue(sinhvien.quequan);
                dataRow.CreateCell(9).SetCellValue(sinhvien.trang_thai);
                dataRow.CreateCell(10).SetCellValue(sinhvien.solanvipham); 
                dataRow.CreateCell(11).SetCellValue(sinhvien.ngayvao.ToString("yyyy-MM-dd")); 
                dataRow.CreateCell(12).SetCellValue(sinhvien.ngaysinh.ToString("yyyy-MM-dd")); 
                rowIndex++;
            }

            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
            }
        }


        public void GuiEmail(string email,string masv,string tensinhvien,int sophong,DateTime ngayvao)
        {
            try
            {
                string fromEmail = "vvc132003@gmail.com";
                string password = "qyqgwwjbbajzrrex"; 
                string toEmail = email;
                MailMessage message = new MailMessage(fromEmail, toEmail);
                message.Subject = "Ban da thue phong thanh cong";
                StringBuilder bodyBuilder = new StringBuilder();
                bodyBuilder.AppendLine($"Ma sinh vien: {masv}");
                bodyBuilder.AppendLine($"Ten sinh vien: {tensinhvien}");
                bodyBuilder.AppendLine($"So phong: {sophong}");
                bodyBuilder.AppendLine($"Ngay vao: {ngayvao}");

                message.Body = bodyBuilder.ToString();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
        }

    }

}