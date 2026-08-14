USE QL_ChiTieu;
GO

-- 1. Bảng VayNo: Quản lý Vay & Cho mượn tiền, Nợ thẻ tín dụng
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'VayNo')
BEGIN
    CREATE TABLE VayNo (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        AccountID INT NOT NULL,
        WalletID INT NOT NULL,
        LoaiVayNo NVARCHAR(50) NOT NULL, -- N'Cho Mượn', N'Đi Vay', N'Nợ Thẻ Tín Dụng'
        DoiTac NVARCHAR(100) NOT NULL, -- Tên bạn bè / Tên Ngân Hàng
        SoTienGoc DECIMAL(18,2) NOT NULL,
        SoTienDaTra DECIMAL(18,2) DEFAULT 0,
        LaiSuatThang DECIMAL(5,2) DEFAULT 0,
        NgayVay DATE NOT NULL DEFAULT GETDATE(),
        HanTra DATE NULL,
        TrangThai NVARCHAR(50) DEFAULT N'Đang Nợ', -- N'Đang Nợ', N'Đã Thanh Toán'
        GhiChu NVARCHAR(250) NULL,
        FOREIGN KEY (AccountID) REFERENCES Account(ID),
        FOREIGN KEY (WalletID) REFERENCES Wallet(ID)
    );
END
GO

-- 2. Bảng DauTu: Theo dõi Chứng Khoán, Vàng, Bất Động Sản, Crypto, Tiết Kiệm
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DauTu')
BEGIN
    CREATE TABLE DauTu (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        AccountID INT NOT NULL,
        WalletID INT NOT NULL,
        LoaiDauTu NVARCHAR(50) NOT NULL, -- N'Chứng Khoán', N'Vàng', N'Bất Động Sản', N'Tiết Kiệm', N'Crypto'
        TenTaiSan NVARCHAR(150) NOT NULL, -- VD: Cổ phiếu HPG, Vàng SJC, Căn hộ A...
        SoLuong DECIMAL(18,4) DEFAULT 1,
        GiaVonBanDau DECIMAL(18,2) NOT NULL,
        GiaTriHienTai DECIMAL(18,2) NOT NULL,
        NgayDauTu DATE NOT NULL DEFAULT GETDATE(),
        GhiChu NVARCHAR(250) NULL,
        FOREIGN KEY (AccountID) REFERENCES Account(ID),
        FOREIGN KEY (WalletID) REFERENCES Wallet(ID)
    );
END
GO

-- 3. Stored Procedure: Kiểm tra cảnh báo ngân sách tự động (Cảnh báo 80% và 100%)
CREATE OR ALTER PROCEDURE sp_NganSach_KiemTraCanhBao
    @WalletID INT,
    @DanhMuc NVARCHAR(150)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Thang INT = MONTH(GETDATE());
    DECLARE @Nam INT = YEAR(GETDATE());

    DECLARE @SoTienGioiHan DECIMAL(18,2) = 0;
    DECLARE @DaChi DECIMAL(18,2) = 0;

    SELECT @SoTienGioiHan = ISNULL(SoTienGioiHan, 0)
    FROM NganSach
    WHERE WalletID = @WalletID AND DanhMuc = @DanhMuc AND Thang = @Thang AND Nam = @Nam;

    SELECT @DaChi = ISNULL(SUM(SoTien), 0)
    FROM ChiTieu
    WHERE WalletID = @WalletID AND DanhMuc = @DanhMuc AND MONTH(Ngay) = @Thang AND YEAR(Ngay) = @Nam;

    DECLARE @TyLe DECIMAL(18,2) = 0;
    IF @SoTienGioiHan > 0
    BEGIN
        SET @TyLe = (@DaChi / @SoTienGioiHan) * 100;
    END

    SELECT 
        @SoTienGioiHan AS SoTienGioiHan,
        @DaChi AS DaChi,
        @TyLe AS TyLe,
        CASE 
            WHEN @SoTienGioiHan > 0 AND @TyLe >= 100 THEN 2 -- Vượt ngân sách (Đỏ)
            WHEN @SoTienGioiHan > 0 AND @TyLe >= 80 THEN 1  -- Cảnh báo 80% (Vàng/Cam)
            ELSE 0                                          -- An toàn
        END AS LevelCanhBao,
        CASE 
            WHEN @SoTienGioiHan > 0 AND @TyLe >= 100 
                THEN N'🚨 CẢNH BÁO: Danh mục "' + @DanhMuc + N'" đã VƯỢT NGÂN SÁCH! Đã chi ' + FORMAT(@DaChi, 'N0') + N' / Hạn mức ' + FORMAT(@SoTienGioiHan, 'N0') + N' đ (' + CAST(CAST(@TyLe AS DECIMAL(10,1)) AS NVARCHAR(20)) + N'%).'
            WHEN @SoTienGioiHan > 0 AND @TyLe >= 80 
                THEN N'⚠️ CẢNH BÁO NGÂN SÁCH: Bạn đã chi ' + FORMAT(@DaChi, 'N0') + N' / Hạn mức ' + FORMAT(@SoTienGioiHan, 'N0') + N' đ (' + CAST(CAST(@TyLe AS DECIMAL(10,1)) AS NVARCHAR(20)) + N'%) cho danh mục "' + @DanhMuc + N'"!'
            ELSE N'OK'
        END AS ThongBao;
END;
GO

-- 4. Stored Procedure: Thêm / Cập nhật Vay Nợ
CREATE OR ALTER PROCEDURE sp_VayNo_Upsert
    @AccountID INT,
    @WalletID INT,
    @LoaiVayNo NVARCHAR(50),
    @DoiTac NVARCHAR(100),
    @SoTienGoc DECIMAL(18,2),
    @LaiSuatThang DECIMAL(5,2),
    @NgayVay DATE,
    @HanTra DATE = NULL,
    @GhiChu NVARCHAR(250) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO VayNo (AccountID, WalletID, LoaiVayNo, DoiTac, SoTienGoc, SoTienDaTra, LaiSuatThang, NgayVay, HanTra, TrangThai, GhiChu)
    VALUES (@AccountID, @WalletID, @LoaiVayNo, @DoiTac, @SoTienGoc, 0, @LaiSuatThang, @NgayVay, @HanTra, N'Đang Nợ', @GhiChu);
END;
GO

-- 5. Stored Procedure: Lấy danh sách Vay Nợ theo Ví
CREATE OR ALTER PROCEDURE sp_VayNo_GetByWallet
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID,
        LoaiVayNo AS [Loại Vay / Mượn],
        DoiTac AS [Đối Tác / Ngân Hàng],
        SoTienGoc AS [Số Tiền Gốc (VNĐ)],
        SoTienDaTra AS [Đã Thanh Toán (VNĐ)],
        (SoTienGoc - SoTienDaTra) AS [Dư Nợ Còn Lại (VNĐ)],
        LaiSuatThang AS [Lãi Suất (%/Tháng)],
        NgayVay AS [Ngày Phát Sinh],
        HanTra AS [Hạn Thanh Toán],
        TrangThai AS [Trạng Thái],
        GhiChu AS [Ghi Chú]
    FROM VayNo
    WHERE WalletID = @WalletID
    ORDER BY ID DESC;
END;
GO

-- 6. Stored Procedure: Cập nhật Thanh toán Vay Nợ
CREATE OR ALTER PROCEDURE sp_VayNo_ThanhToan
    @ID INT,
    @SoTienThanhToan DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE VayNo
    SET 
        SoTienDaTra = SoTienDaTra + @SoTienThanhToan,
        TrangThai = CASE WHEN (SoTienDaTra + @SoTienThanhToan) >= SoTienGoc THEN N'Đã Thanh Toán' ELSE N'Đang Nợ' END
    WHERE ID = @ID;
END;
GO

-- 7. Stored Procedure: Thêm / Cập nhật khoản Đầu Tư
CREATE OR ALTER PROCEDURE sp_DauTu_Upsert
    @AccountID INT,
    @WalletID INT,
    @LoaiDauTu NVARCHAR(50),
    @TenTaiSan NVARCHAR(150),
    @SoLuong DECIMAL(18,4),
    @GiaVonBanDau DECIMAL(18,2),
    @GiaTriHienTai DECIMAL(18,2),
    @NgayDauTu DATE,
    @GhiChu NVARCHAR(250) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO DauTu (AccountID, WalletID, LoaiDauTu, TenTaiSan, SoLuong, GiaVonBanDau, GiaTriHienTai, NgayDauTu, GhiChu)
    VALUES (@AccountID, @WalletID, @LoaiDauTu, @TenTaiSan, @SoLuong, @GiaVonBanDau, @GiaTriHienTai, @NgayDauTu, @GhiChu);
END;
GO

-- 8. Stored Procedure: Lấy danh sách Đầu Tư & Tỷ Suất Sinh Lời ROI
CREATE OR ALTER PROCEDURE sp_DauTu_GetByWallet
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID,
        LoaiDauTu AS [Loại Đầu Tư],
        TenTaiSan AS [Tên Tài Sản / Mã CP],
        SoLuong AS [Số Lượng],
        GiaVonBanDau AS [Vốn Ban Đầu (VNĐ)],
        GiaTriHienTai AS [Giá Trị Hiện Tại (VNĐ)],
        (GiaTriHienTai - GiaVonBanDau) AS [Lãi / Lỗ (VNĐ)],
        CAST(ROUND(CASE 
            WHEN GiaVonBanDau = 0 THEN 0
            ELSE ((GiaTriHienTai - GiaVonBanDau) / GiaVonBanDau) * 100
        END, 2) AS NVARCHAR(20)) + '%' AS [Tỷ Suất ROI (%)],
        NgayDauTu AS [Ngày Đầu Tư],
        GhiChu AS [Ghi Chú]
    FROM DauTu
    WHERE WalletID = @WalletID
    ORDER BY ID DESC;
END;
GO
