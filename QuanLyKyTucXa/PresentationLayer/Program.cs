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
using System;
using System.Collections.Generic;
using System.IO;

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
        private static DichVuBLL dichVuBLL = new DichVuBLL();
        private static ThueDichVuBLL thueDichVuBLL = new ThueDichVuBLL();
        private static KyLuatBLL kyLuatBLL = new KyLuatBLL();
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
                                if (chon >= 0 && chon <= 12)
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
                                            Console.Write("Nhap so luong phong ban muon them:");
                                            int soLuongPhong = int.Parse(Console.ReadLine());
                                            for(int i=0; i < soLuongPhong;i++)
                                            {
                                                Phong phong = new Phong();
                                                phong.NhapThongTinPhong();
                                                phong.songuoio = 0;
                                                phongBLL.ThemPhong(phong);
                                                Console.WriteLine("Phong da duoc them vao CSDL.");
                                            }
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
                                            if (luachonSinhVien >= 0 && luachonSinhVien <= 6)
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
                                            // tìm kiếm sinh vien
                                            studentBLL.TimKiemSinhVienTheoTen();
                                            break;
                                        case 4:
                                            // Sắp xếp danh sách sinh viên
                                            menu.menuSapXepSV();
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
                                                    Console.WriteLine("Ban chon tang(Z) hoac giam(Y)");
                                                    string chonyz = Console.ReadLine();
                                                    if(chonyz == "Y") {
                                                        Console.WriteLine("Danh sach sinh vien sau khi sap xep là:");
                                                        studentBLL.SapXepSinhVienGiamDanTheoTen();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Danh sach sinh vien sau khi sap xep là:");
                                                        studentBLL.SapXepSinhVienTangDanTheoTen();
                                                    }
                                                    break;
                                                case 2:
                                                    studentBLL.SapXepSinhVienTangDanTheoMaPhong();
                                                    break;
                                                case 0:
                                                    Console.WriteLine("off");
                                                    break;
                                            }
                                            break;
                                        case 5:
                                            /// kỷ luật sinh viên
                                            Console.Write("Nhap id sinh vien ma ban muon ky luat: ");
                                            string idsinhvienkyluat = Console.ReadLine();
                                            if(studentBLL.KiemTraTonTaiMaSinhVien(idsinhvienkyluat))
                                            {
                                                int idnguoidung = nguoiDungBLL.LayIDNguoiDung(tendangnhap);
                                                Tuple<int, DateTime, string, int> sts = studentBLL.LayThongTinPhongVaNgayThue(idsinhvienkyluat);
                                                int solanvipham = sts.Item4;
                                                KyLuat kyLuat = new KyLuat();
                                                Console.WriteLine("Chon Loai Vi Pham:1. Ngu day muon || 2. Ve sinh || 3. Gio giac || 4. Danh nhau");
                                                int luaChonloaivipham;
                                                do
                                                {
                                                    Console.Write("Lua chon cua ban: ");
                                                    if (!int.TryParse(Console.ReadLine(), out luaChonloaivipham) || luaChonloaivipham < 1 || luaChonloaivipham > 4)
                                                    {
                                                        Console.WriteLine("Vui long nhap lua chon hop le!");
                                                    }
                                                } while (luaChonloaivipham < 1 || luaChonloaivipham > 4);
                                                switch (luaChonloaivipham)
                                                {
                                                    case 1:
                                                        kyLuat.loaivipham = "Ngu day muon";
                                                        break;
                                                    case 2:
                                                        kyLuat.loaivipham = "Ve sinh";
                                                        break;
                                                    case 3:
                                                        kyLuat.loaivipham = "Gio giac";
                                                        break;
                                                    case 4:
                                                        kyLuat.loaivipham = "Danh nhau";
                                                        break;
                                                }
                                                studentBLL.CapNhatSoLanViPhamChoSinhVien(idsinhvienkyluat, solanvipham + 1);
                                                kyLuat.NhapThongTinKyLuat();
                                                kyLuatBLL.ThemKyLuat(kyLuat, idnguoidung, idsinhvienkyluat);
                                                Console.WriteLine("Ky luat sinh vien thanh cong!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Sinh vien khong ton tai trong CSDL!");
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
                                            Console.Write("Nhap so luong sinh vien muon thue phong:");
                                            int soLuongSVThuePhong = int.Parse(Console.ReadLine());
                                            for (int i=0;i<soLuongSVThuePhong;i++)
                                            {
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
                                                        studentBLL.GuiEmail(sinhVien.email, sinhVien.id, sinhVien.tensinhvien, id, sinhVien.ngayvao);
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
                                Console.Write("Nhap so luong sinh vien muon chuyen phong:");
                                int soLuongSVChuyenPhong = int.Parse(Console.ReadLine());
                                for(int i=0;i< soLuongSVChuyenPhong;i++)
                                {
                                    Console.WriteLine("Nhap thong tin chuyen phong:");
                                    Console.Write("Nhap ma sinh vien muon chuyen: ");
                                    string masv = Console.ReadLine();
                                    Console.Write("Nhap id phong moi: ");
                                    int idphongmoi = int.Parse(Console.ReadLine());
                                    Phong phongmoi = phongBLL.LayPhongTheoMa(idphongmoi);
                                    ChuyenPhong chuyenPhong = new ChuyenPhong();
                                    chuyenPhong.NhapThongTinChuyenPhong();
                                    if (phongmoi != null && phongmoi.songuoio < phongmoi.sogiuong)
                                    {
                                        Tuple<int, DateTime,string,int> st = studentBLL.LayThongTinPhongVaNgayThue(masv);
                                        int idphongcu = st.Item1;  
                                        DateTime ngaynhaphoc = st.Item2;
                                        string gioiTinh = st.Item3;
                                        if(phongmoi.loaiphong == gioiTinh)
                                        {
                                            if (idphongcu != 0 && (chuyenPhong.ngaychuyen.Month >= ngaynhaphoc.Month 
                                                || (chuyenPhong.ngaychuyen.Month == ngaynhaphoc.Month 
                                                && chuyenPhong.ngaychuyen.Day >= ngaynhaphoc.Day)))
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
                                }
                                break;
                            case 6:
                                // Trả phòng
                                Console.Write("Nhap so luong sinh vien muon tra phong:");
                                int soLuongSVTraPhong = int.Parse(Console.ReadLine());
                                for (int i = 0;i < soLuongSVTraPhong; i ++){
                                    SinhVien sinhvien = new SinhVien();
                                    Console.Write("Nhap ma sinh vien muon tra: ");
                                    string masvtraphong = Console.ReadLine();
                                    TraPhong traphong = new TraPhong();
                                    Tuple<int, DateTime,string,int> sts = studentBLL.LayThongTinPhongVaNgayThue(masvtraphong);
                                    int idphong = sts.Item1;
                                    int idnguoidung3 = nguoiDungBLL.LayIDNguoiDung(tendangnhap);
                                    if (idphong !=0)
                                    {
                                        sinhvien.trang_thai = "Đã trả";
                                        studentBLL.UpdateTrangThaiStudent(sinhvien, masvtraphong);
                                        traPhongBLL.TraPhong(traphong, idphong, masvtraphong, idnguoidung3);
                                        Phong phongupdates = phongBLL.LayPhongTheoMa(idphong);
                                        phongBLL.CapNhatSoNguoiO(phongupdates, phongupdates.songuoio - 1);
                                        Console.WriteLine("Tra phong thanh cong!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sinh vien chua duoc phan phong hoac phong khong ton tai.");
                                    }
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
                            case 8:
                                // Sinh viên muốn thuê lại
                                Console.WriteLine("Nhap so luong sinh vien muon thue lai:");
                                int soluongsvthuelai = int.Parse(Console.ReadLine());
                                for(int i=0;i<soluongsvthuelai;i++)
                                {
                                    SinhVien sinhvienthuelai = new SinhVien();
                                    Console.WriteLine("Nhap ma sinh vien muon thue lai:");
                                    sinhvienthuelai.id = Console.ReadLine();
                                    Console.WriteLine("Nhap id phong ma sinh vien muon thue lai:");
                                    sinhvienthuelai.idphong = int.Parse(Console.ReadLine());
                                    Console.Write("Ngay vao (dd/MM/yyyy): ");
                                    sinhvienthuelai.ngayvao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Tuple<int, DateTime, string,int> thuelaiphong = studentBLL.LayThongTinPhongVaNgayThue(sinhvienthuelai.id);
                                    string gioiTinhthuelai = thuelaiphong.Item3;
                                    Phong phongthuelai = phongBLL.LayPhongTheoMa(sinhvienthuelai.idphong);
                                    if(phongthuelai != null && phongthuelai.loaiphong == gioiTinhthuelai && phongthuelai.sogiuong > phongthuelai.songuoio)
                                    {
                                        sinhvienthuelai.trang_thai = "Đã thuê";
                                        studentBLL.UpdateTrangThaiStudent(sinhvienthuelai, sinhvienthuelai.id);
                                        studentBLL.CapNhatPhongChoSinhVien(sinhvienthuelai.id, sinhvienthuelai.idphong);
                                        phongBLL.CapNhatSoNguoiO(phongthuelai, phongthuelai.songuoio + 1);
                                        int idnguoidung = nguoiDungBLL.LayIDNguoiDung(tendangnhap);
                                        thuePhongBll.ThuePhong(sinhvienthuelai.id,sinhvienthuelai.idphong,idnguoidung,sinhvienthuelai.ngayvao);
                                        Console.WriteLine("Sinh vien: " + sinhvienthuelai.id + " thue lai phong thanh cong!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Khong the thue lai phong!");
                                    }
                                }
                                break;
                            case 9:
                                int dichvu;
                                do
                                {
                                    menu.menuDichVu();
                                    while (true)
                                    {
                                        try
                                        {
                                            dichvu = int.Parse(Console.ReadLine());
                                            if (dichvu >= 0 && dichvu <= 5)
                                                break;
                                            else
                                                Console.WriteLine("Ban da chon sai vui long chon lai!!!");
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Ban da chon sai vui long chon lai!!!");
                                        }
                                    }
                                    switch (dichvu)
                                    {
                                        case 1:
                                            Console.Write("Nhap so luong dich vu ban muon them:");
                                            int soLuongDV = int.Parse(Console.ReadLine());
                                            for (int i = 0; i < soLuongDV; i++)
                                            {
                                                DichVu dichVu = new DichVu();
                                                dichVu.trangthai = "Còn sử dụng";
                                                dichVu.NhapThongTinDichVu();
                                                dichVuBLL.ThemDichVu(dichVu);
                                                Console.WriteLine("Them dich vu thanh cong!");
                                            }
                                            break;
                                        case 2:
                                            dichVuBLL.GetAllDichVu();
                                            break;
                                        case 3:
                                            Console.Write("Nhap id phong ban muon cap nhat: ");
                                            DichVu dichVucapnhat = new DichVu();
                                            if (int.TryParse(Console.ReadLine(), out int id))
                                            {
                                                dichVucapnhat.id = id;
                                                dichVucapnhat.NhapThongTinDichVu();
                                                dichVuBLL.SuaDichVu(dichVucapnhat);
                                                Console.WriteLine("Dich vu da duoc cap nhat vao CSDL.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("loi.");
                                            }
                                            break;
                                        case 4:
                                            Console.Write("Nhap id dich vu ma ban muon xoa: ");
                                            if (int.TryParse(Console.ReadLine(), out int iddv))
                                            {
                                                dichVuBLL.XoaDichVu(iddv);
                                                Console.WriteLine("Dich vu da duoc xoa khoi CSDL.");
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
                                } while (dichvu != 0);
                                break;
                            case 10:

                                /// thuê dịch vụ
                                Console.WriteLine("Nhap so luong thue dich vu:");
                                int soluongdichvuthue = int.Parse(Console.ReadLine());
                                for (int i=0;i< soluongdichvuthue; i++)
                                {
                                    SinhVien sinhvienthuedichvu = new SinhVien();
                                    Console.WriteLine("Nhap ma sinh vien muon thue dich vu");
                                    sinhvienthuedichvu.id = Console.ReadLine();
                                    if(studentBLL.KiemTraTonTaiMaSinhVien(sinhvienthuedichvu.id))
                                    {
                                        Console.WriteLine("Nhap ten dich vu ban muon thue");
                                        string tendichvu = Console.ReadLine();
                                        int idthuephong = thuePhongBll.LayMaThuePhongTheoIDSV(sinhvienthuedichvu.id);
                                        DichVu  dichVu = dichVuBLL.LayDichVuTheoTen(tendichvu);
                                        if(idthuephong != 0 && tendichvu != null)
                                        {
                                            ThueDichVu thueDichVu = new ThueDichVu();
                                            thueDichVu.NhapThongTinThueDichVu();
                                            float thanhTien = dichVu.giatien * thueDichVu.soluongthue;
                                            int idNguoiDung = nguoiDungBLL.LayIDNguoiDung(tendangnhap);
                                            int soluongcon = dichVu.soluongcon - thueDichVu.soluongthue;
                                            dichVuBLL.CapNhatSoLuongConChoDV(dichVu.id, soluongcon);
                                            thueDichVuBLL.ThemThueDichVu(thueDichVu, idNguoiDung, idthuephong, dichVu.id, thanhTien, sinhvienthuedichvu.id);
                                            Console.WriteLine("Thue dich vu thanh cong!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ten dich vu hoac so phong khong ton tai!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sinh vien khong ton tai trong CSDL!");
                                    }
                                }
                                break;
                            case 11:
                                studentBLL.ExportAllDichVuToExcel();
                                Console.WriteLine("Xuat sinh vien ra excel thanh cong!");
                                break;
                        }
                    } while (chon != 0);
                }
            } while (tendangnhap == null);
        }
    }
}