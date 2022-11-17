create database QLBanHang

use QLBanHang

create table LoaiSanPham(
	MaLoai nvarchar(10) primary key,
	TenLoai nvarchar(50)
)

create table SanPham(
	MaSP nvarchar(10) primary key,
	TenSP nvarchar(50),
	MaLoai nvarchar(10),
	SoLuong int,
	DonGia int,
	foreign key (MaLoai) references LoaiSanPham (MaLoai)
	)

	select *from SanPham