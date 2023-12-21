create Database QL_VeXe
go


use QL_VeXe
go

create table dbo_TuyenDuong(
 MaTuyen char(20)primary key,
 TenTuyenDuong nvarchar(max),
 QuangDuong char(10) 
)
go



create table dbo_NhanVien(
	MaNhanVien char(10)primary key ,
	Pass nvarchar(max),
	TenNV nvarchar(max),
	Img image,
	Tuoi int ,
	Luong decimal(18,2),
	Brithday date,
	Role char(20),
	CCCD char(20),
	NgayVaoLam DATE
)
go



Create table dbo_BangLichTrinh(
	MaBangLichTrinh char(20)primary key ,
	TenLichTrinh nvarchar(max),
	NgayKhoiHanh Date  ,
	MaXe char(12),
	 SoGhe int,
	 GiaVe decimal(18,2),
	 Gio Time
)
go

Create table dbo_BangVeXe(
	MaVe char(10) primary key ,
	NgayMua datetime,
	GiaVe decimal(18,2),
	SoLuong int ,
	TrangThai char(50),

	MaBangLichTrinh char(20),
	MaXe char(12),
	MaNhanVien char(10),
	NgayKhoiHanh Date,
	IdKhach char(11),
	Gio Time
)
go


alter table dbo_BangVeXe
add constraint BangVeXetoBangLichTrinh
foreign key (MaBangLichTrinh)
references dbo_BangLichTrinh


Create table dbo_Xe(
	MaXe char(12)primary key ,
	SoGhe int ,
	MaNhanVien char(10),
	
)
go


create table dbo_History(
	MaHis char(100)primary key ,
	NoiDung nvarchar(max),
	MaNhanVien char(10),
	NgaySua datetime,
)
go





create table dbo_KhachHang(
IdKhach char(11)  primary key, 
TenKhach nvarchar(max),
SoLuong int 
)
go



-----------------------------------------------------------------------FK-----------------------------------------------------------
alter table dbo_BangVeXe
add constraint BangVeXetoNhanVien
foreign key (MaNhanVien)
references dbo_NhanVien


alter table dbo_BangVeXe
add constraint BangVeXetoKhachHang
foreign key (IdKhach)
references dbo_KhachHang

alter table dbo_BangVeXe
add constraint BangVeXetoBangLichTrinh
foreign key (MaBangLichTrinh)
references dbo_BangLichTrinh



alter table dbo_Xe
add constraint XetoNhanVien
foreign key (MaNhanVien)
references dbo_NhanVien



alter table dbo_History
add constraint HistorytoNhanVien
foreign key (MaNhanVien)
references dbo_NhanVien


alter table dbo_BangVeXe
add constraint BangVeXetoXe
foreign key (MaXe)
references dbo_Xe



-----------------------------------------------------------------------DATA-----------------------------------------------------------
insert into dbo_NhanVien values('ad123',N'admin',N'Gia Thuận',(SELECT * FROM OPENROWSET(BULK 'D:\sent.png', SINGLE_BLOB) AS Image),21,'125000.00','2002/11/17','admin','0123456',GETDATE())
insert into dbo_NhanVien values('TX0012',N'khanghet',N'Ngọc Khang',(SELECT * FROM OPENROWSET(BULK 'D:\sent.png', SINGLE_BLOB) AS Image),21,'125000.00','2002/10/16','TaiXe','567689',GETDATE())
insert into dbo_NhanVien values('NV003',N'thanhan',N'Thành An',(SELECT * FROM OPENROWSET(BULK 'D:\sent.png', SINGLE_BLOB) AS Image),21,'125000.00','2002/10/16','NhanVien','357954',GETDATE())
insert into dbo_NhanVien values('NV004',N'thanhan',N'Thành An',(SELECT * FROM OPENROWSET(BULK 'D:\sent.png', SINGLE_BLOB) AS Image),21,'125000.00','2002/10/16','NhanVien','357954',GETDATE())
insert into dbo_NhanVien values('NV005',N'thanhan',N'Thành An',(SELECT * FROM OPENROWSET(BULK 'D:\sent.png', SINGLE_BLOB) AS Image),21,'125000.00','2002/10/16','NhanVien','357954',GETDATE())
insert into dbo_NhanVien values('TX123',N'thanhan',N'Văn Tèo',(SELECT * FROM OPENROWSET(BULK 'D:\sent.png', SINGLE_BLOB) AS Image),21,'125000.00','2002/10/16','NhanVien','357954',GETDATE())
insert into dbo_NhanVien values('TX789',N'thanhan',N'Văn hai',(SELECT * FROM OPENROWSET(BULK 'D:\sent.png', SINGLE_BLOB) AS Image),21,'125000.00','2002/10/16','NhanVien','357954',GETDATE())
insert into dbo_NhanVien values('TX999',N'thanhan',N'Văn Tài',(SELECT * FROM OPENROWSET(BULK 'D:\sent.png', SINGLE_BLOB) AS Image),21,'125000.00','2002/10/16','NhanVien','357954',GETDATE())

select * from dbo_NhanVien



insert into dbo_History values('H001',N'Thay đổi hệ thống','ad123',GetDate())
select * from dbo_History



insert into dbo_Xe values('51B02345',45,'TX0012')
insert into dbo_Xe values('51B02456',45,'TX0012')
insert into dbo_Xe values('51B02789',45,'TX0012')
insert into dbo_Xe values('71D12345',45,'TX0012')
select * from dbo_Xe







insert into dbo_BangLichTrinh values('LT001',N'Sài Gòn - Bến Tre','2023/10/26','51B02345',45,'250000.00',' 9:20')
insert into dbo_BangLichTrinh values('LT002',N'Sài Gòn - Tiền Giang','2023/10/26 ','51B02456',45,'250000.00','10:20')
insert into dbo_BangLichTrinh values('LT005',N'Tiền Giang - Bến Tre','2023/10/26 ','51B02789',45,'250000.00','11:26')
insert into dbo_BangLichTrinh values('LT006',N'Tiền Giang - Bến Tre','2023/10/26 ','51B02789',45,'250000.00','11:26')
insert into dbo_BangLichTrinh values('LT003',N'Tiền Giang - Sài Gòn','2023/10/26 ','51B02789',45,'250000.00',' 10:20')
insert into dbo_BangLichTrinh values('LT089',N'Tiền Giang - Sài Gòn','2023/10/27 ','51B02789',45,'250000.00','23:11')
insert into dbo_BangLichTrinh values('LT030',N'Tiền Giang - Sài Gòn','2023/10/27 ','51B02789',45,'250000.00','23:16')
insert into dbo_BangLichTrinh values('LT0000',N'Sài Gòn - Tiền Giang','2023/10/28 ','51B02345',45,'250000.00','1:30')

insert into dbo_BangLichTrinh values('LT1234',N'Cần Thơ - Tiền Giang','2023/10/29 ','71D12345',45,'250000.00','13:30')

select * from dbo_BangLichTrinh where NgayKhoiHanh ='2023/10/27 '
delete from dbo_BangLichTrinh where MaBangLichTrinh ='LT1234'

delete from dbo_BangLichTrinh where MaBangLichTrinh ='LT1234'

insert into dbo_BangLichTrinh values('LT151',N'Bảo Lộc - Đà Nẵng','2023/10/27 23:16','51B02789',45,'250000.00')

insert into dbo_KhachHang values('0329867771',N'Minh Won',32)
insert into dbo_KhachHang values('0123456789',N'Thành An',1)
insert into dbo_KhachHang values('0987456123',N'Minh Lộc',3)
insert into dbo_KhachHang values('0123',N'Thành An',3)
select * from dbo_KhachHang 



insert into dbo_BangVeXe values('V001',GETDATE(),'320000.00',2,'onl','LT005','51B02789','NV003','2023/10/26','0329867771',' 20:15')
insert into dbo_BangVeXe values('V002',GETDATE(),'320000.00',2,'onl','LT005','51B02789','NV003','2023/10/26','0329867771',' 20:15')
insert into dbo_BangVeXe values('V003',GETDATE(),'320000.00',2,'onl','LT005','51B02789','NV003','2023/10/26','0329867771',' 20:15')
insert into dbo_BangVeXe values('V015',GETDATE(),'320000.00',2,'onl','LT005','51B02789','NV003','2023/10/26','0329867771',' 20:15')



select * from dbo_BangVeXe where MaVe ='v0013'


insert into dbo_TuyenDuong values ('TD0001',N'Bảo Lộc - Đà Nẵng','756km')
insert into dbo_TuyenDuong values ('TD0002',N'Tiền Giang - Sài Gòn','56km')
insert into dbo_TuyenDuong values ('TD0003',N'Sài Gòn - Tiền Giang','56km')
insert into dbo_TuyenDuong values ('TD0004',N'Sài Gòn - Bến Tre','95km')
insert into dbo_TuyenDuong values ('TD0005',N'Cần Thơ - Tiền Giang','195km')
select * from dbo_TuyenDuong

-------------------------------------------------PROC
CREATE PROCEDURE TruSoGhe
    @MaLichTrinh char(10),
    @SoLuongTru INT
AS
BEGIN
    UPDATE dbo_BangLichTrinh
    SET SoGhe = SoGhe - @SoLuongTru
    WHERE MaBangLichTrinh = @MaLichTrinh;
END


--EXEC TruSoGhe @MaLichTrinh = 'LT001', @SoLuongTru =2




CREATE PROCEDURE CongSoGhe
    @MaLichTrinh char(10),
    @SoLuongCong INT
AS
BEGIN
    UPDATE dbo_BangLichTrinh
    SET SoGhe = SoGhe + @SoLuongCong
    WHERE MaBangLichTrinh = @MaLichTrinh;
END

--EXEC CongSoGhe @MaLichTrinh = 'LT001', @SoLuongCong =2




CREATE PROCEDURE LoadVeSauNgayHomNay
AS
BEGIN
    DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay

    SELECT * FROM dbo_BangLichTrinh
    WHERE NgayKhoiHanh >= @HomNay;
END

--EXEC LoadVeSauNgayHomNay 


CREATE PROCEDURE TimVeSauNgayHomNay
  @Gio Time,
    @TenLichTrinh nvarchar(max)
AS
BEGIN
    DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay

    SELECT * FROM dbo_BangLichTrinh
    WHERE NgayKhoiHanh >= @HomNay and Gio=@Gio and TenLichTrinh=@TenLichTrinh ;
END



CREATE PROCEDURE XuatMaXeNgoaiKhungGio
    @NgayKhoiHanh DATE,
    @Gio TIME
AS
BEGIN
    SELECT MaXe
    FROM dbo_BangLichTrinh
    WHERE NgayKhoiHanh != @NgayKhoiHanh AND Gio != @Gio;
END

--exec XuatMaXeNgoaiKhungGio @NgayKhoiHanh='2023-10-26',@Gio='10:20:00.0000000'

-----------------------------------------------------------------PROC DBO_BANGLICHTRINH
CREATE PROCEDURE LayVeSauNgayHomNay
   
AS
BEGIN
    DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay

    SELECT * FROM dbo_BangLichTrinh
    WHERE NgayKhoiHanh = @HomNay ;
END

--EXEC LayVeSauNgayHomNay

CREATE PROCEDURE TimGioSauNgayHomNay
    @TenLichTrinh nvarchar(max)
AS
BEGIN
    DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay

    SELECT * FROM dbo_BangLichTrinh
    WHERE NgayKhoiHanh >= @HomNay and TenLichTrinh=@TenLichTrinh ;
END

--EXEC TimGioSauNgayHomNay   @TenLichTrinh=N'Cần Thơ - Tiền Giang'

CREATE PROCEDURE TimVeTheoNgay
    @TenLichTrinh nvarchar(max),
	@NgayKhoiHanh date
AS
BEGIN
    DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay

    SELECT * FROM dbo_BangLichTrinh
    WHERE NgayKhoiHanh >= @HomNay and TenLichTrinh=@TenLichTrinh  and NgayKhoiHanh=@NgayKhoiHanh;
END

--EXEC TimVeTheoNgay   @TenLichTrinh=N'Cần Thơ - Tiền Giang' , @NgayKhoiHanh='2023-11-01'
CREATE PROCEDURE XuatLichTrinhTrongNgayHomNay
   
AS
BEGIN
    DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay

    SELECT * FROM dbo_BangLichTrinh
    WHERE NgayKhoiHanh = @HomNay ;
END

EXEC XuatLichTrinhTrongNgayHomNay  


create PROC XuatLichTrinhTrong7Ngay
AS
BEGIN
	DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay
	
	DECLARE @NgayTruoc7Ngay DATE--7 nGÀY
    SET @NgayTruoc7Ngay = DATEADD(DAY, -7, @HomNay)

	 SELECT * FROM dbo_BangLichTrinh
    WHERE NgayKhoiHanh <= @HomNay and NgayKhoiHanh>=@NgayTruoc7Ngay ;

END

--EXEC XuatLichTrinhTrong7Ngay  


CREATE PROCEDURE XuatLichTrinhTrongThangHienTai
AS
BEGIN
    DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay

    -- Trích xuất tháng từ ngày hiện tại
    DECLARE @ThangHienTai INT
    SET @ThangHienTai = DATEPART(MONTH, @HomNay)

    -- Sử dụng truy vấn để lấy lịch trình trong tháng hiện tại
    SELECT * FROM dbo_BangLichTrinh
    WHERE DATEPART(MONTH, NgayKhoiHanh) = @ThangHienTai;
END

--EXEC XuatLichTrinhTrongThangHienTai 


CREATE PROCEDURE XuatLichTrinhChuaCoKhach
AS
BEGIN
    -- Tạo bảng tạm thời để lưu trữ khóa chính đã được sử dụng
    CREATE TABLE #DaSuDung (MaKhoaChinh char(10) PRIMARY KEY);

    -- Insert các khóa chính đã được sử dụng vào bảng tạm thời
    INSERT INTO #DaSuDung (MaKhoaChinh)
    SELECT DISTINCT MaBangLichTrinh
    FROM dbo_BangVeXe; -- Thay TenBangKhac bằng tên bảng chứa khóa chính đã sử dụng

    -- Lấy danh sách các khóa chính chưa được sử dụng
    SELECT * FROM dbo_BangLichTrinh
    WHERE MaBangLichTrinh NOT IN (SELECT MaKhoaChinh FROM #DaSuDung); -- Thay TenBangGoc bằng tên bảng gốc

    -- Xóa bảng tạm thời
    DROP TABLE #DaSuDung;
END
--exec XuatLichTrinhChuaCoKhach


---------------------------------Proc dbo_BangVeXe
create PROC XuatBangVeTrong7Ngay
AS
BEGIN
	DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay
	
	DECLARE @NgayTruoc7Ngay DATE--7 nGÀY
    SET @NgayTruoc7Ngay = DATEADD(DAY, -7, @HomNay)

	 SELECT * FROM dbo_BangVeXe
    WHERE NgayMua <= @HomNay and NgayMua>=@NgayTruoc7Ngay ;

END

EXEC XuatBangVeTrong7Ngay 

CREATE PROCEDURE XuatVeTrongNgayHomNay
   
AS
BEGIN
    DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay

    SELECT * FROM dbo_BangVeXe
    WHERE NgayMua = @HomNay ;
END

EXEC XuatVeTrongNgayHomNay  


CREATE PROCEDURE XuatVeTrongThangHienTai
AS
BEGIN
    DECLARE @HomNay DATE
    SET @HomNay = GETDATE() -- Lấy ngày hôm nay

    -- Trích xuất tháng từ ngày hiện tại
    DECLARE @ThangHienTai INT
    SET @ThangHienTai = DATEPART(MONTH, @HomNay)

    -- Sử dụng truy vấn để lấy lịch trình trong tháng hiện tại
    SELECT * FROM dbo_BangVeXe
    WHERE DATEPART(MONTH, NgayMua) = @ThangHienTai;
END

--EXEC XuatVeTrongThangHienTai 

--------------------------------------------dbo_Xe
CREATE PROCEDURE XuatMaTaiXeChuaCoXe
AS
BEGIN
    -- Tạo bảng tạm thời để lưu trữ khóa chính đã được sử dụng
    CREATE TABLE #DaSuDung (MaKhoaChinh char(10) PRIMARY KEY);

    -- Insert các khóa chính đã được sử dụng vào bảng tạm thời
    INSERT INTO #DaSuDung (MaKhoaChinh)
    SELECT DISTINCT MaNhanVien
    FROM dbo_Xe; -- Thay TenBangKhac bằng tên bảng chứa khóa chính đã sử dụng

    -- Lấy danh sách các khóa chính chưa được sử dụng
    SELECT MaNhanVien
    FROM dbo_NhanVien
    WHERE MaNhanVien LIKE 'TX%' 
	AND MaNhanVien NOT IN (SELECT MaKhoaChinh FROM #DaSuDung); -- Thay TenBangGoc bằng tên bảng gốc

    -- Xóa bảng tạm thời
    DROP TABLE #DaSuDung;
END

--exec XuatMaTaiXeChuaCoXe


CREATE PROCEDURE XuatCacXeChuaCoLich
AS
BEGIN
    -- Tạo bảng tạm thời để lưu trữ khóa chính đã được sử dụng
    CREATE TABLE #DaSuDung (MaKhoaChinh char(10) PRIMARY KEY);

    -- Insert các khóa chính đã được sử dụng vào bảng tạm thời
    INSERT INTO #DaSuDung (MaKhoaChinh)
    SELECT DISTINCT MaXe
    FROM dbo_BangLichTrinh; -- Thay TenBangKhac bằng tên bảng chứa khóa chính đã sử dụng

    -- Lấy danh sách các khóa chính chưa được sử dụng
    SELECT *  FROM dbo_Xe
    WHERE MaXe NOT IN (SELECT MaKhoaChinh FROM #DaSuDung); -- Thay TenBangGoc bằng tên bảng gốc

    -- Xóa bảng tạm thời
    DROP TABLE #DaSuDung;
END

--exec XuatCacXeChuaCoLich


select * from dbo_BangLichTrinh