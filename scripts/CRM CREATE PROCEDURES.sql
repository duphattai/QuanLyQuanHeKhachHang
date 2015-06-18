USE QUANLYQUANHEKHACHHANG

/****** Object:  StoredProcedure [dbo].[GetGIAODICH]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGIAODICH]
@_MA_GD varchar(10)
AS
BEGIN
	SELECT * FROM GIAODICH WHERE MA_GD = @_MA_GD
END
GO
/****** Object:  StoredProcedure [dbo].[GetGUI_MAIL]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetGUI_MAIL]
@_MA_GM varchar(10)
AS
BEGIN
	SELECT * FROM GUI_MAIL WHERE MA_GM = @_MA_GM
END
GO
/****** Object:  StoredProcedure [dbo].[GetHOPDONG]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetHOPDONG]
@_MAHD varchar(10)
AS
BEGIN
	SELECT * FROM HOPDONG WHERE MAHD = @_MAHD
END
GO
/****** Object:  StoredProcedure [dbo].[GetHOTRO]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetHOTRO]
@_MAHT varchar(10)
AS
BEGIN
	SELECT * FROM HOTRO WHERE MAHT = @_MAHT
END
GO

/****** Object:  StoredProcedure [dbo].[GetKHACHHANG]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetKHACHHANG]
@_MAKH varchar(10)
AS
BEGIN
	SELECT * FROM KHACHHANG WHERE MAKH = @_MAKH
END
GO
/****** Object:  StoredProcedure [dbo].[GetLICHHEN]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLICHHEN]
@_MA_LH varchar(10)
AS
BEGIN
	SELECT * FROM LICHHEN WHERE MA_LH = @_MA_LH
END
GO
/****** Object:  StoredProcedure [dbo].[GetNGUOIDUNG]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNGUOIDUNG]
@_TEN_ND varchar(10)
AS
BEGIN
	SELECT * FROM NGUOIDUNG WHERE TEN_ND = @_TEN_ND
END
GO
/****** Object:  StoredProcedure [dbo].[GetNHANVIEN]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNHANVIEN]
@_MANV varchar(10)
AS
BEGIN
	SELECT * FROM NHANVIEN WHERE MANV = @_MANV
END
GO
/****** Object:  StoredProcedure [dbo].[GetNHOM_KH]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNHOM_KH]
@_MANHOMKH varchar(10)
AS
BEGIN
	SELECT * FROM CTHD WHERE @_MANHOMKH = @_MANHOMKH
END
GO
/****** Object:  StoredProcedure [dbo].[GetNHOM_ND]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetNHOM_ND]
@_MANHOMND varchar(10)
AS
BEGIN
	SELECT * FROM NHOM_ND WHERE MANHOMND = @_MANHOMND
END
GO
/****** Object:  StoredProcedure [dbo].[GetSANPHAM]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSANPHAM]
@_MASP varchar(10)
AS
BEGIN
	SELECT * FROM SANPHAM WHERE MASP = @_MASP
END
GO
/****** Object:  StoredProcedure [dbo].[GetTHUCHI]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTHUCHI]
@_MAKHOAN varchar(10)
AS
BEGIN
	SELECT * FROM THUCHI WHERE MAKHOAN = @_MAKHOAN
END
GO
/****** Object:  StoredProcedure [dbo].[GetTopGiaoDich]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTopGiaoDich]

	@_MaGD varchar(10) output
	
AS
BEGIN
	SET @_MaGD =(
	SELECT TOP(1) MA_GD FROM GIAODICH
	ORDER BY MA_GD DESC);
	END
GO
/****** Object:  StoredProcedure [dbo].[GetTopGuiMail]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[GetTopGuiMail]
	@_MaGM varchar(10) output
	
AS
BEGIN
	SET @_MaGM =(
	SELECT TOP(1) MA_GM FROM GUI_MAIL
	ORDER BY MA_GM DESC);
	END
GO

/****** Object:  StoredProcedure [dbo].[GetTopMaHopDong]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[GetTopMaHopDong]
	@_MaHD varchar(10) output
	
AS
BEGIN
	SET @_MaHD =(
	SELECT TOP(1) MAHD FROM HOPDONG
	ORDER BY MAHD DESC);
	END
GO
/****** Object:  StoredProcedure [dbo].[GetTopMaHoTro]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[GetTopMaHoTro]
	@_MaHT varchar(10) output
	
AS
BEGIN
	SET @_MaHT =(
	SELECT TOP(1) MAHT FROM HOTRO
	ORDER BY MAHT DESC);
	END
GO
/****** Object:  StoredProcedure [dbo].[GetTopMaKhachHang]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTopMaKhachHang]
	@_MaKH varchar(10) output
	
AS
BEGIN
	SET @_MaKH =(
	SELECT TOP(1) MAKH FROM KHACHHANG
	ORDER BY MAKH DESC);
	END
GO
/****** Object:  StoredProcedure [dbo].[GetTopMaLH]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[GetTopMaLH]
	@_MaLH varchar(10) output
	
AS
BEGIN
	SET @_MaLH =(
	SELECT TOP(1) MA_LH FROM LICHHEN
	ORDER BY MA_LH DESC);
	END
GO
/****** Object:  StoredProcedure [dbo].[GetTopMaNhomKhachHang]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[GetTopMaNhomKhachHang]
	@_MaNKH varchar(10) output
	
AS
BEGIN
	SET @_MaNKH =(
	SELECT TOP(1) MANHOMKH FROM NHOM_KH
	ORDER BY MANHOMKH DESC);
	END
GO
/****** Object:  StoredProcedure [dbo].[GetTopMaNhomNguoiDung]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[GetTopMaNhomNguoiDung]
	@_MaNGD varchar(10) output
	
AS
BEGIN
	SET @_MaNGD =(
	SELECT TOP(1) MANHOMND FROM NHOM_ND
	ORDER BY MANHOMND DESC);
	END
GO
/****** Object:  StoredProcedure [dbo].[GetTopMaNV]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTopMaNV]
	@_MaNV varchar(10) output
	
AS
BEGIN
	SET @_MaNV =(
	SELECT TOP(1) MANV FROM NHANVIEN
	ORDER BY MANV DESC);
	END

GO
/****** Object:  StoredProcedure [dbo].[GetTopMaSanPham]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTopMaSanPham]
	@_MaSP varchar(10) output
	
AS
	begin
	Set @_MaSP=(Select top(1) MASP from SANPHAM
				order by MASP DESC);
	end
GO
/****** Object:  StoredProcedure [dbo].[GetTopMaThuChi]    Script Date: 6/6/2015 8:31:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[GetTopMaThuChi]
	@_MaTC varchar(10) output
	
AS
BEGIN
	SET @_MaTC =(
	SELECT TOP(1) MAKHOAN FROM THUCHI
	ORDER BY MAKHOAN DESC);
	END
GO