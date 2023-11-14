--- check thông tin đang nhập
CREATE PROCEDURE CheckThongTinDangNhap
    @tendangnhap NVARCHAR(255),
    @matkhau NVARCHAR(255)
AS
BEGIN
    SELECT * FROM NguoiDung WHERE tendangnhap = @tendangnhap AND matkhau = @matkhau
END


---- lấy id người dùng

CREATE PROCEDURE LayIDNguoiDung
    @tendangnhap NVARCHAR(255)
AS
BEGIN
    SELECT id FROM NguoiDung where tendangnhap = @tendangnhap 
END


----cập nhật mật khẩu

CREATE PROCEDURE CapNhatMatKhau
    @tendangnhap NVARCHAR(255),
    @matkhau NVARCHAR(255)
AS
BEGIN
    UPDATE NguoiDung	
    SET matkhau = @matkhau
    WHERE tendangnhap = @tendangnhap;
END


--- thêm phòng

CREATE PROCEDURE ThemPhongs
    @loaiphong VARCHAR(50),
    @sogiuong INT,
    @songuoio INT,
    @giaphong FLOAT
AS
BEGIN
    IF @loaiphong = 'Nam'
    BEGIN
        SET @giaphong = @sogiuong * 200000
    END
    ELSE
    BEGIN
        SET @giaphong = @sogiuong * 100000
    END

    INSERT INTO Phong (loaiphong, sogiuong, songuoio, giaphong) 
    VALUES (@loaiphong, @sogiuong, @songuoio, @giaphong)
END

---- cập nhật phòng

CREATE PROCEDURE CapNhatPhongs
    @id INT ,
    @loaiphong VARCHAR(50),
    @sogiuong INT,
    @songuoio INT,
    @giaphong FLOAT
AS
BEGIN
	UPDATE Phong SET loaiphong = @loaiphong, sogiuong = @sogiuong, 
    songuoio = @songuoio, giaphong = @giaphong WHERE id = @id
END

--- xoá phòng
CREATE PROCEDURE XoaPhongs
    @id INT 
AS
BEGIN
	DELETE FROM Phong  WHERE id = @id
END


--- cập nhật số ngưởi ở
CREATE PROCEDURE CapNhatSoNguoiOs
    @id INT ,
    @songuoio INT
AS
BEGIN
	UPDATE Phong SET songuoio = @songuoio WHERE id = @id
END

--- lấy phòng theo id phòng

CREATE PROCEDURE LayPhongTheoMaS
    @id INT 
AS
BEGIN
	SELECT * FROM Phong WHERE id = @id
END

--- xe phòng
CREATE PROCEDURE GetAllPhongProcedure
AS
BEGIN
    SELECT id, loaiphong, sogiuong, songuoio, giaphong
    FROM Phong
END

--- xem sinh viên 
CREATE PROCEDURE GetAllStudents
AS
BEGIN
    SELECT *
    FROM SinhVien WHERE  trang_thai = 'Ðã thuê'
END
--- thêm sinh viên
CREATE PROCEDURE ThemSinhVienS
	@id VARCHAR(255),
    @tensinhvien VARCHAR(255),
    @khoahoc VARCHAR(255),
    @nganhhoc VARCHAR(255),
    @email VARCHAR(50),
    @sodienthoai VARCHAR(20),
    @idphong INT,
    @gioitinh VARCHAR(10),
    @quequan VARCHAR(255),
    @trang_thai VARCHAR(20),
    @solanvipham INT,
    @ngayvao DATE,
    @ngaysinh DATE
AS
BEGIN
	INSERT INTO SinhVien (id,tensinhvien, khoahoc, nganhhoc, email, sodienthoai, idphong, gioitinh, quequan,trang_thai,solanvipham, ngayvao, ngaysinh) 
    VALUES (@id,@tensinhvien, @khoahoc, @nganhhoc, @email, @sodienthoai, @idphong, @gioitinh, @quequan,@trang_thai,@solanvipham, @ngayvao, @ngaysinh)
END

--- cập nhật sinh viên
CREATE PROCEDURE UpdateSinhViens
	@id VARCHAR(255),
    @tensinhvien VARCHAR(255),
    @khoahoc VARCHAR(255),
    @nganhhoc VARCHAR(255),
    @email VARCHAR(50),
    @sodienthoai VARCHAR(20),
    @idphong INT,
    @gioitinh VARCHAR(10),
    @quequan VARCHAR(255),
    @trang_thai VARCHAR(20),
    @solanvipham INT,
    @ngayvao DATE,
    @ngaysinh DATE
AS
BEGIN
    UPDATE SinhVien SET tensinhvien = @tensinhvien, khoahoc = @khoahoc, nganhhoc = @nganhhoc, 
    email = @email, sodienthoai = @sodienthoai, gioitinh = @gioitinh, quequan = @quequan , 
    ngayvao = @ngayvao, ngaysinh = @ngaysinh WHERE id = @id
END

-- cập nhật trạng thái của sinh viên 
CREATE PROCEDURE UpdateTrangThaiStudents
	@id VARCHAR(255),
    @trang_thai VARCHAR(20)
AS
BEGIN
    UPDATE SinhVien SET  trang_thai = @trang_thai WHERE id = @id
END


--- xem thông tin thuê phòng

CREATE PROCEDURE GetAllThuePhong
AS
BEGIN
    SELECT *
    FROM ThuePhong 
END


--- thêm thông tin thuê phòng

CREATE PROCEDURE ThuePhongs
    @idnguoidung INT,
    @idphong INT,
    @trangthai NVARCHAR(255),
    @idsinhvien NVARCHAR(255),
    @ngaythue DATETIME
AS
BEGIN
    INSERT INTO ThuePhong (idnguoidung, idphong, trangthai, idsinhvien, ngaythue)
    VALUES (@idnguoidung, @idphong, @trangthai, @idsinhvien, @ngaythue)
END



---xem thông tun trả phòng
CREATE PROCEDURE GetAllTinTraPhong
AS
BEGIN
    SELECT *
    FROM TraPhong 
END


--- thêm thông tin trả phòng

CREATE PROCEDURE TraPhongs
    @idsinhvien NVARCHAR(255),
    @idnguoidung INT,
    @idphong INT,
    @lydo NVARCHAR(255),
    @ngaytra DATETIME
AS
BEGIN
    INSERT INTO TraPhong (idsinhvien, idnguoidung, idphong, lydo, ngaytra) 
    VALUES (@idsinhvien, @idnguoidung, @idphong, @lydo, @ngaytra)
END


--- thêm thông tin chuyển phòng

CREATE PROCEDURE ChuyenPhongs
    @idsinhvien NVARCHAR(255),
    @idnguoidung INT,
    @idphongcu INT,
    @idphongmoi INT,
    @lydo NVARCHAR(255),
    @ngaychuyen DATETIME
AS
BEGIN
    INSERT INTO ChuyenPhong (idsinhvien, idnguoidung, idphongcu, idphongmoi, lydo, ngaychuyen)
    VALUES (@idsinhvien, @idnguoidung, @idphongcu, @idphongmoi, @lydo, @ngaychuyen);
END
