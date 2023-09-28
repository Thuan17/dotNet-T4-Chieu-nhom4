create Database QL_VeXe
go


use QL_VeXe
go



create table NhanVien(
	MaNV char(10)primary key ,
	Pass nvarchar(max),
	TenNV nvarchar(max),
	Img nvarchar(max),
	Tuoi int ,
	ChucVu char(10) ,
	Luong float,
	Brithday date,
)
go



create table KhachHang (
	Sdt int primary key ,
	TenKhachHang nvarchar(max),
)
go

create table Xe(
	MaXe char(10)primary key ,
	SoGhe int ,
	LoaiXe char(10),
	BienSo char(10),
	MaNV char(10),
)
go
create table BenXe(
	MaBen char(10)primary key ,
	TenBen nvarchar(max),
)
go

create table BenDen(
	MaBen char(10) ,
	TenBenDen nvarchar(200)primary key ,
)
go
create table BenDi(
	MaBen char(10) ,
	TenBenDi nvarchar(200)primary key ,
)
go




create table Ve(
	MaVe nvarchar(20)primary key,
	ThoiGian DateTime ,
	TenBenDi nvarchar(200),
	TenBenDen nvarchar(200),
	GiaVe float,
	NgayBanVe DateTime,
	MaNV char(10) ,
	Sdt int ,
)
go

------fk-------
alter table NhanVien
add constraint NVtoX
foreign key (MaNV)
references Xe

alter table Ve
add constraint NVtoVe
foreign key (MaNV)
references NhanVien

alter table Ve
add constraint KhtoVe
foreign key (Sdt)
references KhachHang

alter table Ve
add constraint BDtoVe
foreign key (TenBenDi)
references BenDi


alter table Ve
add constraint BDetoVe
foreign key (TenBenDen)
references BenDen
-