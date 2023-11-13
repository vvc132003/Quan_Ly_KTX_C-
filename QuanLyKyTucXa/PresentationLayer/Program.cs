using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;
using ketnoicsdllan1.BusinessLogicLayer;
using ketnoicsdllan1.PresentationLayer;
using QuanLyKyTucXa.BusinessLogicLayer;
using QuanLyKyTucXa.DataAccessLayer;
using QuanLyKyTucXa.DataTransferObjects;
using QuanLyKyTucXa.PresentationLayer;

namespace ketnoicsdllan1.PresentationLayer
{
    internal class Program
    {
        private static PhongBLL phongBLL = new PhongBLL();
        private static SinhVienBLL studentBLL = new SinhVienBLL();
        private static ThuePhongBll thuePhongBll = new ThuePhongBll();
        private static TraPhongBLL traPhongBLL = new TraPhongBLL();
        private static ChuyenPhongBLL chuyenPhonhBLL = new ChuyenPhongBLL();
        private static NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();
        private static Menu menu = new Menu();
        static void Main(string[] args)
        {
            string tendangnhap;
            do
            {
                tendangnhap = nguoiDungBLL.CheckThongTinDangNhap();
                if (tendangnhap != null)
                {
                    int chon;
                    do
                    {
                        menu.menuktx();
                        while (true)
                        {
                            try
                            {
                                chon = int.Parse(Console.ReadLine());
                                if (chon >= 0 && chon <= 9)
                                    break;
                                else
                                    Console.WriteLine("Ban da chon sai vui long chon lai!!");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ban da chon sai vui long chon lai!!");
                            }
                        }

                        switch (chon)
                        {
                            case 1:
                                // Quản lý phòng
                                int luachonPhong;
                                do
                                {
                                    menu.menuPHONG();
                                    while (true)
                                    {
                                        try
                                        {
                                            luachonPhong = int.Parse(Console.ReadLine());
                                            if (luachonPhong >= 0 && luachonPhong <= 5)
                                                break;
                                            else
                                                Console.WriteLine("Ban da chon sai vui long chon lai!!!");
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Ban da chon sai vui long chon lai!!!");
                                        }
                                    }
                                    switch (luachonPhong)
                                    {
                                        case 1:
                                            Phong phong = new Phong();
                                            phong.NhapThongTinPhong();
                                            phong.songuoio = 0;
                                            phongBLL.ThemPhong(phong);
                                            Console.WriteLine("Phong da duoc them vao CSDL.");
                                            break;
                                        case 2:
                                            phongBLL.GetAllPhong();
                                            break;
                                        case 3:
                                            Console.Write("Nhap id phong ban muon cap nhat: ");
                                            Phong phongupdate = new Phong();
                                            if (int.TryParse(Console.ReadLine(), out int id))
                                            {
                                                phongupdate.id = id;
                                                phongupdate.NhapThongTinPhong();
                                                phongBLL.CapNhatPhong(phongupdate);
                                                Console.WriteLine("Phong da duoc cap nhat vao CSDL.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("loi.");
                                            }
                                            break;
                                        case 4:
                                            Console.Write("Nhap id phong ma ban muon xoa: ");
                                            if (int.TryParse(Console.ReadLine(), out int idp))
                                            {
                                                phongBLL.XoaPhong(idp);
                                                Console.WriteLine("Phong da duoc xoa khoi CSDL.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("loi.");
                                            }
                                            break;
                                        case 0:
                                            Console.WriteLine("off");
                                            break;
                                    }
                                } while (luachonPhong != 0);
                                break;

                            case 2:
                                // Quản lý sinh viên
                                int luachonSinhVien;
                                do
                                {
                                    menu.menuSINHVIEN();
                                    while (true)
                                    {
                                        try
                                        {
                                            luachonSinhVien = int.Parse(Console.ReadLine());
                                            if (luachonSinhVien >= 0 && luachonSinhVien <= 4)
                                                break;
                                            else
                                                Console.WriteLine("Bạn đã chọn sai, vui lòng chọn lại!!!");
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Bạn đã chọn sai, vui lòng chọn lại!!!");
                                        }
                                    }

                                    switch (luachonSinhVien)
                                    {
                                        case 1:
                                            studentBLL.GetAllStudents();
                                            break;
                                        case 2:
                                            Console.Write("Nhap idssv sinh vien ban muon cap nhat: ");
                                            string idssv = Console.ReadLine();
                                            SinhVien sinhvienupdate = new SinhVien();
                                            if (!string.IsNullOrWhiteSpace(idssv))
                                            {
                                                sinhvienupdate.id = idssv;
                                                sinhvienupdate.NhapThongTinSinhVien();
                                                studentBLL.UpdateStudent(sinhvienupdate);
                                                Console.WriteLine("Sinh vien da duoc cap nhat vao CSDL.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("loi.");
                                            }
                                            break;
                                        case 3:
                                            // Hàm tìm kiếm sinh vien
                                            studentBLL.TimKiemSinhVienTheoTen();
                                            break;
                                        case 4:
                                            // Sắp xếp danh sách sinh viên
                                            /*menusapxepsv();
                                            */
                                            int sapXepOption;
                                            while (true)
                                            {
                                                try
                                                {
                                                    sapXepOption = int.Parse(Console.ReadLine());
                                                    if (sapXepOption >= 0 && sapXepOption <= 3)
                                                        break;
                                                    else
                                                        Console.WriteLine("Bạn đã chọn sai, vui lòng chọn lại!!!");
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("Bạn đã chọn sai, vui lòng chọn lại!!!");
                                                }
                                            }

                                            switch (sapXepOption)
                                            {
                                                case 1:
                                                    // Sắp xếp theo tên
                                                    break;
                                                case 2:
                                                    // Sắp xếp tăng dần theo số phòng
                                                    break;
                                                case 0:
                                                    Console.WriteLine("off");
                                                    break;
                                            }
                                            break;
                                    }
                                } while (luachonSinhVien != 0);
                                break;

                            case 3:
                                // Quản lý thuê phòng
                                int luachonThuePhong;
                                do
                                {
                                    menu.menuthuePHONG();
                                    while (true)
                                    {
                                        try
                                        {
                                            luachonThuePhong = int.Parse(Console.ReadLine());
                                            if (luachonThuePhong >= 0 && luachonThuePhong <= 3)
                                                break;
                                            else
                                                Console.WriteLine("Ban da chon sai vui long chon lai!!!");
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Ban da chon sai vui long chon lai!!!");
                                        }
                                    }

                                    switch (luachonThuePhong)
                                    {
                                        case 1:
                                            Console.Write("Ma phong muon thue: ");
                                            int id = int.Parse(Console.ReadLine());
                                            Phong phong = phongBLL.LayPhongTheoMa(id);
                                            SinhVien sinhVien = new SinhVien();
                                            sinhVien.NhapThongTinSinhVien();
                                            if (phong != null && phong.songuoio < phong.sogiuong)
                                            {
                                                if(phong.loaiphong == sinhVien.gioitinh)
                                                {
                                                    sinhVien.idphong = id;
                                                    sinhVien.trang_thai = "Đã thuê";
                                                    studentBLL.ThemSinhVien(sinhVien);
                                                    phongBLL.CapNhatSoNguoiO(phong, phong.songuoio + 1);
                                                    int idnguoidung = nguoiDungBLL.LayIDNguoiDung(tendangnhap);
                                                    thuePhongBll.ThuePhong(sinhVien.id, id, idnguoidung, sinhVien.ngayvao);
                                                    Console.WriteLine("Thue phong thanh cong!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Loai phong do la danh cho" + phong.loaiphong + "chu khong phai la " + sinhVien.gioitinh);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Phong khong ton tai hoac da day.");
                                            }
                                            break;
                                        case 2:
                                            thuePhongBll.GetAllThuePhongs();
                                            break;
                                        case 3:
                                            break;
                                        case 0:
                                            Console.WriteLine("off");
                                            break;
                                    }
                                } while (luachonThuePhong != 0);
                                break;
                            case 4:
                                // Đổi mật khẩu
                                nguoiDungBLL.CapNhatMatKhau();
                                break;
                            case 5:
                                // Chuyển phòng
                                Console.WriteLine("Nhap thong tin chuyen phong:");
                                Console.Write("Nhap ma sinh vien muon chuyen: ");
                                string masv = Console.ReadLine();
                                Console.Write("Nhap ID Phong Moi: ");
                                int idphongmoi = int.Parse(Console.ReadLine());
                                Phong phongmoi = phongBLL.LayPhongTheoMa(idphongmoi);
                                ChuyenPhong chuyenPhong = new ChuyenPhong();
                                chuyenPhong.NhapThongTinChuyenPhong();
                                if (phongmoi != null && phongmoi.songuoio < phongmoi.sogiuong)
                                {
                                    Tuple<int, DateTime,string> st = studentBLL.LayThongTinPhongVaNgayThue(masv);
                                    int idphongcu = st.Item1;  
                                    DateTime ngaynhaphoc = st.Item2;
                                    string gioiTinh = st.Item3;
                                    if(phongmoi.loaiphong == gioiTinh)
                                    {
                                        if (idphongcu != 0 && (chuyenPhong.ngaychuyen.Month > ngaynhaphoc.Month 
                                            || (chuyenPhong.ngaychuyen.Month == ngaynhaphoc.Month 
                                            && chuyenPhong.ngaychuyen.Day > ngaynhaphoc.Day)))
                                        {
                                            Phong phongupdatecu = phongBLL.LayPhongTheoMa(idphongcu);
                                            phongBLL.CapNhatSoNguoiO(phongmoi, phongmoi.songuoio + 1);
                                            phongBLL.CapNhatSoNguoiO(phongupdatecu, phongupdatecu.songuoio - 1);
                                            int idnguoidung2 = nguoiDungBLL.LayIDNguoiDung(tendangnhap);
                                            chuyenPhonhBLL.ChuyenPhong(chuyenPhong, idphongcu, idphongmoi, masv, idnguoidung2);
                                            studentBLL.CapNhatPhongChoSinhVien(masv, idphongmoi);
                                            Console.WriteLine("Chuyen phong thanh cong.");  
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ngay chuyen khong duojc nho hon ngay nhap hoc!.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Loai phong do la danh cho" + phongmoi.loaiphong + "chu khong phai la " + gioiTinh);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Phong khong ton tai hoac da day.");
                                }
                                break;
                            case 6:
                                // Trả phòng
                                SinhVien sinhvien = new SinhVien();
                                Console.Write("Nhap ma sinh vien muon tra: ");
                                string masvtraphong = Console.ReadLine();
                                studentBLL.UpdateTrangThaiStudent(sinhvien, masvtraphong);
                                TraPhong traphong = new TraPhong();
                                Tuple<int, DateTime,string> sts = studentBLL.LayThongTinPhongVaNgayThue(masvtraphong);
                                int idphong = sts.Item1;
                                int idnguoidung3 = nguoiDungBLL.LayIDNguoiDung(tendangnhap);
                                if (idphong !=0)
                                {
                                    traPhongBLL.TraPhong(traphong, idphong, masvtraphong, idnguoidung3);
                                    Phong phongupdates = phongBLL.LayPhongTheoMa(idphong);
                                    phongBLL.CapNhatSoNguoiO(phongupdates, phongupdates.songuoio - 1);
                                    Console.WriteLine("Tra phong thanh cong!");
                                }
                                else
                                {
                                    Console.WriteLine("Sinh vien chua duoc phan phong hoac phong khong ton tai.");
                                }
                                break;
                            case 7:
                                // Đăng xuất
                                if (tendangnhap != null)
                                {
                                    Console.WriteLine("Dang xuat thanh cong. Tam biet: " + tendangnhap);
                                    tendangnhap = null;
                                }
                                else
                                {
                                    Console.WriteLine("Chua co nguoi dang nhap.");
                                }
                                tendangnhap = nguoiDungBLL.CheckThongTinDangNhap();
                                break;
                        }
                    } while (chon != 0);
                }
            } while (tendangnhap == null);
        }
    }
}