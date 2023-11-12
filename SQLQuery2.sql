create database QuanLyKTX;
use QuanLyKTX;

-- Bảng Người Dùng
CREATE TABLE NguoiDung (
    id INT IDENTITY(1,1) PRIMARY KEY,
    hoten VARCHAR(255),
    sodienthoai VARCHAR(20),
    diachi VARCHAR(255),
    chucvu VARCHAR(50),
    matkhau VARCHAR(255),
    tendangnhap VARCHAR(50)
);

-- Bảng Phòng
CREATE TABLE Phong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    loaiphong VARCHAR(50),
    sogiuong INT,
    songuoio INT,
    giaphong FLOAT
);

-- Bảng Sinh Viên
CREATE TABLE SinhVien (
    id VARCHAR(255) PRIMARY KEY,
    tensinhvien VARCHAR(255),
    khoahoc VARCHAR(255),
    nganhhoc VARCHAR(255),
    email VARCHAR(50),
    sodienthoai VARCHAR(20),
    idphong INT,
    gioitinh VARCHAR(10),
    quequan VARCHAR(255),
    trang_thai VARCHAR(20),
    solanvipham INT,
    ngaynhaphoc DATE,
    ngaysinh DATE,
    FOREIGN KEY (idphong) REFERENCES Phong(id)
);

-- Bảng Chuyển Phòng
CREATE TABLE ChuyenPhong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idsinhvien VARCHAR(255),
    idnguoidung INT,
    idphongcu INT,
    idphongmoi INT,
    lydo VARCHAR(255),
    ngaychuyen DATE,
    FOREIGN KEY (idsinhvien) REFERENCES SinhVien(id),
    FOREIGN KEY (idnguoidung) REFERENCES NguoiDung(id),
    FOREIGN KEY (idphongcu) REFERENCES Phong(id),
    FOREIGN KEY (idphongmoi) REFERENCES Phong(id)
);

-- Bảng Thuê Phòng
CREATE TABLE ThuePhong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idnguoidung INT,
    idphong INT,
    trangthai VARCHAR(20),
    idsinhvien VARCHAR(255),
    ngaythue DATE,
    FOREIGN KEY (idnguoidung) REFERENCES NguoiDung(id),
    FOREIGN KEY (idphong) REFERENCES Phong(id),
    FOREIGN KEY (idsinhvien) REFERENCES SinhVien(id)
);

-- Bảng Trả Phòng
CREATE TABLE TraPhong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idsinhvien VARCHAR(255),
    idnguoidung INT,
    idphong INT,
    lydo VARCHAR(255),
    ngaytra DATE,
    FOREIGN KEY (idsinhvien) REFERENCES SinhVien(id),
    FOREIGN KEY (idnguoidung) REFERENCES NguoiDung(id),
    FOREIGN KEY (idphong) REFERENCES Phong(id)
);


INSERT INTO NguoiDung (hoten, sodienthoai, diachi, chucvu, matkhau, tendangnhap)
VALUES ('Vo Van Chinh', '0123456789', '123 qt', 'Admin', '123', 'adminn');


SELECT * FROM SinhVien WHERE tensinhvien LIKE 'CHINH' AND trang_thai LIKE 'Ðã thuê'