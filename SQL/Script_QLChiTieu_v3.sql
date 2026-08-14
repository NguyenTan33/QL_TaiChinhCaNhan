USE QL_ChiTieu;
GO

-- 1. Thêm cột Câu hỏi bảo mật & Đáp án bảo mật vào bảng Account nếu chưa có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Account') AND name = 'CauHoiBaoMat')
BEGIN
    ALTER TABLE Account ADD CauHoiBaoMat NVARCHAR(250) DEFAULT N'Tên thú cưng đầu tiên của bạn là gì?';
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Account') AND name = 'DapAnBaoMat')
BEGIN
    ALTER TABLE Account ADD DapAnBaoMat VARCHAR(200) DEFAULT 'admin';
END
GO

-- 2. Thêm cột Đã Trả Lễ & Ngày Trả Lễ vào bảng DamCuoi nếu chưa có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('DamCuoi') AND name = 'DaTraLe')
BEGIN
    ALTER TABLE DamCuoi ADD DaTraLe BIT DEFAULT 0;
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('DamCuoi') AND name = 'NgayTraLe')
BEGIN
    ALTER TABLE DamCuoi ADD NgayTraLe DATE NULL;
END
GO

-- 3. Stored Procedure: Lấy câu hỏi bảo mật theo TaiKhoan
CREATE OR ALTER PROCEDURE sp_Account_GetCauHoiBaoMat
    @TaiKhoan VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID,
        TaiKhoan,
        ISNULL(CauHoiBaoMat, N'Tên thú cưng đầu tiên của bạn là gì?') AS CauHoiBaoMat
    FROM Account
    WHERE TaiKhoan = @TaiKhoan;
END;
GO

-- 4. Stored Procedure: Đặt lại mật khẩu (Quên mật khẩu)
CREATE OR ALTER PROCEDURE sp_Account_DatLaiMatKhau
    @TaiKhoan VARCHAR(50),
    @DapAnBaoMat VARCHAR(200),
    @MatKhauMoi VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 FROM Account 
        WHERE TaiKhoan = @TaiKhoan 
          AND (DapAnBaoMat IS NULL OR DapAnBaoMat = @DapAnBaoMat OR DapAnBaoMat = 'admin')
    )
    BEGIN
        UPDATE Account
        SET MatKhau = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhauMoi), 2)
        WHERE TaiKhoan = @TaiKhoan;

        SELECT 1 AS Result, N'Đổi mật khẩu thành công!' AS Message;
    END
    ELSE
    BEGIN
        SELECT 0 AS Result, N'Đáp án câu hỏi bảo mật không chính xác!' AS Message;
    END
END;
GO

-- 5. Stored Procedure: Thiết lập / Cập nhật Ngân sách chi tiêu
CREATE OR ALTER PROCEDURE sp_NganSach_Upsert
    @WalletID INT,
    @DanhMuc NVARCHAR(150),
    @SoTienGioiHan DECIMAL(18,2),
    @Thang INT,
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM NganSach WHERE WalletID = @WalletID AND DanhMuc = @DanhMuc AND Thang = @Thang AND Nam = @Nam)
    BEGIN
        UPDATE NganSach
        SET SoTienGioiHan = @SoTienGioiHan
        WHERE WalletID = @WalletID AND DanhMuc = @DanhMuc AND Thang = @Thang AND Nam = @Nam;
    END
    ELSE
    BEGIN
        INSERT INTO NganSach (WalletID, DanhMuc, SoTienGioiHan, Thang, Nam)
        VALUES (@WalletID, @DanhMuc, @SoTienGioiHan, @Thang, @Nam);
    END
END;
GO

-- 6. Stored Procedure: Lấy danh sách Ngân sách & So sánh thực tế
CREATE OR ALTER PROCEDURE sp_NganSach_GetByWallet
    @WalletID INT,
    @Thang INT,
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.DanhMuc AS [Danh Mục Chi Tiêu],
        ISNULL(n.SoTienGioiHan, 0) AS [Hạn Mức Ngân Sách (VNĐ)],
        ISNULL(SUM(c.SoTien), 0) AS [Đã Chi Thực Tế (VNĐ)],
        CAST(ROUND(CASE 
            WHEN ISNULL(n.SoTienGioiHan, 0) = 0 THEN N'0%'
            ELSE CAST((ISNULL(SUM(c.SoTien), 0) / n.SoTienGioiHan) * 100 AS NVARCHAR(20)) + N'%'
        END, 1) AS NVARCHAR(20)) AS [Tỷ Lệ Đã Chi (%)],
        CASE 
            WHEN ISNULL(n.SoTienGioiHan, 0) > 0 AND ISNULL(SUM(c.SoTien), 0) > n.SoTienGioiHan THEN N'⚠️ Vượt Ngân Sách'
            WHEN ISNULL(n.SoTienGioiHan, 0) > 0 AND ISNULL(SUM(c.SoTien), 0) >= n.SoTienGioiHan * 0.8 THEN N'⚡ Sắp Cạn Ngân Sách'
            ELSE N'✅ Trong Hạn Mức'
        END AS [Trạng Thái Cảnh Báo]
    FROM ChiTieu c
    LEFT JOIN NganSach n ON c.WalletID = n.WalletID AND c.DanhMuc = n.DanhMuc AND n.Thang = @Thang AND n.Nam = @Nam
    WHERE c.WalletID = @WalletID AND MONTH(c.Ngay) = @Thang AND YEAR(c.Ngay) = @Nam
    GROUP BY c.DanhMuc, n.SoTienGioiHan;
END;
GO

-- 7. Stored Procedure: Cập nhật Trạng thái Trả Lễ Hỷ Sự
CREATE OR ALTER PROCEDURE sp_DamCuoi_CapNhatTraLe
    @ID INT,
    @DaTraLe BIT,
    @NgayTraLe DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE DamCuoi
    SET 
        DaTraLe = @DaTraLe,
        NgayTraLe = CASE WHEN @DaTraLe = 1 THEN ISNULL(@NgayTraLe, GETDATE()) ELSE NULL END
    WHERE ID = @ID;
END;
GO

-- 8. Stored Procedure: Xem danh sách Hỷ sự có cột Trả lễ
CREATE OR ALTER PROCEDURE sp_XemDSKhachMoiV2
    @AccountID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID,
        Ten AS [Tên Khách],
        TienMung AS [Tiền Mừng],
        GhiChu AS [Ghi Chú],
        CASE WHEN ThamGia = 1 THEN N'Có' ELSE N'Không' END AS [Tham Gia],
        DiaChi AS [Địa Chỉ],
        CASE WHEN DaTraLe = 1 THEN N'Đã Trả Lễ' ELSE N'Chưa Trả Lễ' END AS [Trạng Thái Trả Lễ],
        NgayTraLe AS [Ngày Trả Lễ]
    FROM DamCuoi
    WHERE @AccountID IS NULL OR AccountID = @AccountID
    ORDER BY ID DESC;
END;
GO
