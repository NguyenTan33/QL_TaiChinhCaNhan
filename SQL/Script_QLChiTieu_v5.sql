USE QL_ChiTieu;
GO

-- 1. SP: Biểu đồ 1 - Tỷ trọng Chi tiêu Theo Danh Mục
CREATE OR ALTER PROCEDURE sp_PhanTich_DanhMucTyTrong
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TongChi DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID), 0);

    SELECT 
        c.DanhMuc AS [Danh Mục],
        SUM(c.SoTien) AS [Tổng Chi (VNĐ)],
        COUNT(*) AS [Số Lần Chi],
        CAST(ROUND(CASE WHEN @TongChi = 0 THEN 0 ELSE (SUM(c.SoTien) / @TongChi) * 100 END, 1) AS NVARCHAR(20)) + '%' AS [Tỷ Trọng (%)],
        REPLICATE('█', CAST(ROUND(CASE WHEN @TongChi = 0 THEN 0 ELSE (SUM(c.SoTien) / @TongChi) * 20 END, 0) AS INT)) AS [Đồ Thị]
    FROM ChiTieu c
    WHERE c.WalletID = @WalletID
    GROUP BY c.DanhMuc
    ORDER BY [Tổng Chi (VNĐ)] DESC;
END;
GO

-- 2. SP: Biểu đồ 2 - So sánh Thu Nhập vs Chi Tiêu theo Tháng
CREATE OR ALTER PROCEDURE sp_PhanTich_ThuVsChiThang
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        FORMAT(t.Ngay, 'MM/yyyy') AS [Tháng/Năm],
        ISNULL(SUM(t.Luong + t.Thuong + t.Khac), 0) AS [Tổng Thu (VNĐ)],
        ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID AND FORMAT(Ngay, 'MM/yyyy') = FORMAT(t.Ngay, 'MM/yyyy')), 0) AS [Tổng Chi (VNĐ)],
        (ISNULL(SUM(t.Luong + t.Thuong + t.Khac), 0) - ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID AND FORMAT(Ngay, 'MM/yyyy') = FORMAT(t.Ngay, 'MM/yyyy')), 0)) AS [Thặng Dư (VNĐ)]
    FROM ThuNhap t
    WHERE t.WalletID = @WalletID
    GROUP BY FORMAT(t.Ngay, 'MM/yyyy')
    ORDER BY MIN(t.Ngay) DESC;
END;
GO

-- 3. SP: Biểu đồ 3 - Burn Rate & Số ngày sống sót
CREATE OR ALTER PROCEDURE sp_PhanTich_BurnRate
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;

    EXEC sp_DuDoanChiTieu @WalletID = @WalletID;
END;
GO

-- 4. SP: Biểu đồ 4 - Thực tế Chi tiêu vs Hạn mức Ngân sách
CREATE OR ALTER PROCEDURE sp_PhanTich_NganSachUtilization
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Thang INT = MONTH(GETDATE());
    DECLARE @Nam INT = YEAR(GETDATE());

    EXEC sp_NganSach_GetByWallet @WalletID = @WalletID, @Thang = @Thang, @Nam = @Nam;
END;
GO

-- 5. SP: Biểu đồ 5 - Phân phối dòng tiền Quy tắc 50/30/20
CREATE OR ALTER PROCEDURE sp_PhanTich_QuyTac503020
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TongThu DECIMAL(18,2) = ISNULL((SELECT SUM(Luong + Thuong + Khac) FROM ThuNhap WHERE WalletID = @WalletID), 0);
    DECLARE @TongChi DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID), 0);

    -- Nhu cầu thiết yếu (Ăn uống, Di chuyển, Hóa đơn, Y tế, Giáo dục)
    DECLARE @ThietYeu DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID AND DanhMuc IN (N'Ăn Uống', N'Di Chuyển', N'Hóa Đơn & Tiện Ích', N'Y Tế & Sức Khỏe', N'Giáo Dục')), 0);
    
    -- Sở thích cá nhân (Giải trí, Mua sắm, Khác)
    DECLARE @SoThich DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID AND DanhMuc IN (N'Giải Trí', N'Mua Sắm', N'Khác (Chi)')), 0);

    -- Tiết kiệm / Thặng dư tích lũy
    DECLARE @TietKiem DECIMAL(18,2) = CASE WHEN (@TongThu - @TongChi) > 0 THEN (@TongThu - @TongChi) ELSE 0 END;

    SELECT 
        N'Nhu Cầu Thiết Yếu (Target 50%)' AS [Hạng Mục Quy Tắc],
        @ThietYeu AS [Số Tiền (VNĐ)],
        CAST(ROUND(CASE WHEN @TongThu = 0 THEN 0 ELSE (@ThietYeu / @TongThu) * 100 END, 1) AS NVARCHAR(20)) + '%' AS [Tỷ Lệ Thực Tế (%)],
        N'50%' AS [Mục Tiêu Chuẩn],
        REPLICATE('█', CAST(ROUND(CASE WHEN @TongThu = 0 THEN 0 ELSE (@ThietYeu / @TongThu) * 20 END, 0) AS INT)) AS [Đồ Thị]

    UNION ALL

    SELECT 
        N'Sở Thích Cá Nhân (Target 30%)' AS [Hạng Mục Quy Tắc],
        @SoThich AS [Số Tiền (VNĐ)],
        CAST(ROUND(CASE WHEN @TongThu = 0 THEN 0 ELSE (@SoThich / @TongThu) * 100 END, 1) AS NVARCHAR(20)) + '%' AS [Tỷ Lệ Thực Tế (%)],
        N'30%' AS [Mục Tiêu Chuẩn],
        REPLICATE('█', CAST(ROUND(CASE WHEN @TongThu = 0 THEN 0 ELSE (@SoThich / @TongThu) * 20 END, 0) AS INT)) AS [Đồ Thị]

    UNION ALL

    SELECT 
        N'Tiết Kiệm & Đầu Tư (Target 20%)' AS [Hạng Mục Quy Tắc],
        @TietKiem AS [Số Tiền (VNĐ)],
        CAST(ROUND(CASE WHEN @TongThu = 0 THEN 0 ELSE (@TietKiem / @TongThu) * 100 END, 1) AS NVARCHAR(20)) + '%' AS [Tỷ Lệ Thực Tế (%)],
        N'20%' AS [Mục Tiêu Chuẩn],
        REPLICATE('█', CAST(ROUND(CASE WHEN @TongThu = 0 THEN 0 ELSE (@TietKiem / @TongThu) * 20 END, 0) AS INT)) AS [Đồ Thị];
END;
GO

-- 6. SP: Biểu đồ 6 - Hiệu suất Đầu tư & ROI
CREATE OR ALTER PROCEDURE sp_PhanTich_DauTuROI
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;

    EXEC sp_DauTu_GetByWallet @WalletID = @WalletID;
END;
GO
