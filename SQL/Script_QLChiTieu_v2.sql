USE QL_ChiTieu;
GO

-- 1. Bảng Wallet (Ví tài chính - Cá nhân / Gia đình dùng chung)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Wallet')
BEGIN
    CREATE TABLE Wallet
    (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        TenVi NVARCHAR(100) NOT NULL,
        LoaiVi NVARCHAR(50) NOT NULL DEFAULT N'Cá Nhân', -- 'Cá Nhân' hoặc 'Gia Đình'
        MaChiaSe VARCHAR(20) UNIQUE NOT NULL,            -- Mã 6 ký tự để người khác nhập chung ví
        TienBanDau DECIMAL(18,2) NOT NULL DEFAULT 0,
        NgayTao DATETIME DEFAULT GETDATE()
    );
END
GO

-- 2. Bảng WalletMember (Thành viên ví)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'WalletMember')
BEGIN
    CREATE TABLE WalletMember
    (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        WalletID INT NOT NULL,
        AccountID INT NOT NULL,
        VaiTro NVARCHAR(50) NOT NULL DEFAULT N'Thành Viên', -- 'Chủ Ví', 'Thành Viên'
        NgayThamGia DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (WalletID) REFERENCES Wallet(ID) ON DELETE CASCADE,
        FOREIGN KEY (AccountID) REFERENCES Account(ID) ON DELETE CASCADE
    );
END
GO

-- 3. Cập nhật bảng Tien nếu chưa có WalletID
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Tien') AND name = 'WalletID')
BEGIN
    ALTER TABLE Tien ADD WalletID INT NULL;
END
GO

-- 4. Cập nhật bảng ChiTieu & ThuNhap để gắn với WalletID
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('ChiTieu') AND name = 'WalletID')
BEGIN
    ALTER TABLE ChiTieu ADD WalletID INT NULL;
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('ThuNhap') AND name = 'WalletID')
BEGIN
    ALTER TABLE ThuNhap ADD WalletID INT NULL;
END
GO

-- 5. Bảng Category (Danh mục chi tiêu / thu nhập)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Category')
BEGIN
    CREATE TABLE Category
    (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        TenDanhMuc NVARCHAR(100) NOT NULL,
        Loai NVARCHAR(20) NOT NULL, -- 'ChiTieu' hoặc 'ThuNhap'
        Icon NVARCHAR(50) DEFAULT 'default'
    );

    -- Seed danh mục mặc định
    INSERT INTO Category (TenDanhMuc, Loai) VALUES 
    (N'Ăn Uống', 'ChiTieu'),
    (N'Di Chuyển', 'ChiTieu'),
    (N'Mua Sắm', 'ChiTieu'),
    (N'Hóa Đơn & Tiện Ích', 'ChiTieu'),
    (N'Giải Trí', 'ChiTieu'),
    (N'Y Tế & Sức Khỏe', 'ChiTieu'),
    (N'Giáo Dục', 'ChiTieu'),
    (N'Khác (Chi)', 'ChiTieu'),
    (N'Lương', 'ThuNhap'),
    (N'Thưởng', 'ThuNhap'),
    (N'Đầu Tư', 'ThuNhap'),
    (N'Khác (Thu)', 'ThuNhap');
END
GO

-- 6. Bảng NganSach (Ngân sách chi tiêu theo danh mục)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NganSach')
BEGIN
    CREATE TABLE NganSach
    (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        WalletID INT NOT NULL,
        DanhMuc NVARCHAR(150) NOT NULL,
        SoTienGioiHan DECIMAL(18,2) NOT NULL,
        Thang INT NOT NULL,
        Nam INT NOT NULL,
        FOREIGN KEY (WalletID) REFERENCES Wallet(ID) ON DELETE CASCADE
    );
END
GO

-- Synchronize existing Accounts to have default personal wallets
DECLARE @AccountID INT;
DECLARE acc_cursor CURSOR FOR SELECT ID FROM Account;
OPEN acc_cursor;
FETCH NEXT FROM acc_cursor INTO @AccountID;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF NOT EXISTS (SELECT 1 FROM WalletMember WHERE AccountID = @AccountID)
    BEGIN
        DECLARE @NewWalletID INT;
        DECLARE @Code VARCHAR(20) = 'W' + CAST(@AccountID AS VARCHAR(10)) + RIGHT(CAST(CHECKSUM(NEWID()) AS VARCHAR(20)), 4);
        
        INSERT INTO Wallet (TenVi, LoaiVi, MaChiaSe, TienBanDau)
        VALUES (N'Ví Cá Nhân', N'Cá Nhân', @Code, 0);

        SET @NewWalletID = SCOPE_IDENTITY();

        INSERT INTO WalletMember (WalletID, AccountID, VaiTro)
        VALUES (@NewWalletID, @AccountID, N'Chủ Ví');

        -- Link existing Tien
        IF EXISTS (SELECT 1 FROM Tien WHERE AccountID = @AccountID AND WalletID IS NULL)
        BEGIN
            UPDATE Tien SET WalletID = @NewWalletID WHERE AccountID = @AccountID AND WalletID IS NULL;
        END
        ELSE
        BEGIN
            INSERT INTO Tien (TienHienCo, AccountID, WalletID) VALUES (0, @AccountID, @NewWalletID);
        END

        -- Update existing transactions to link to this default wallet
        UPDATE ChiTieu SET WalletID = @NewWalletID WHERE AccountID = @AccountID AND WalletID IS NULL;
        UPDATE ThuNhap SET WalletID = @NewWalletID WHERE AccountID = @AccountID AND WalletID IS NULL;
    END
    FETCH NEXT FROM acc_cursor INTO @AccountID;
END

CLOSE acc_cursor;
DEALLOCATE acc_cursor;
GO

-- ===================================================
-- STORED PROCEDURES
-- ===================================================

-- Stored Procedure: Tạo Ví Mới (Cá Nhân / Gia Đình)
CREATE OR ALTER PROCEDURE sp_Wallet_Create
    @AccountID INT,
    @TenVi NVARCHAR(100),
    @LoaiVi NVARCHAR(50),
    @TienBanDau DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MaChiaSe VARCHAR(20) = UPPER(LEFT(NEWID(), 6));
    DECLARE @WalletID INT;

    INSERT INTO Wallet (TenVi, LoaiVi, MaChiaSe, TienBanDau)
    VALUES (@TenVi, @LoaiVi, @MaChiaSe, @TienBanDau);

    SET @WalletID = SCOPE_IDENTITY();

    INSERT INTO WalletMember (WalletID, AccountID, VaiTro)
    VALUES (@WalletID, @AccountID, N'Chủ Ví');

    INSERT INTO Tien (TienHienCo, AccountID, WalletID)
    VALUES (@TienBanDau, @AccountID, @WalletID);

    SELECT @WalletID AS WalletID, @MaChiaSe AS MaChiaSe;
END;
GO

-- Stored Procedure: Thêm người dùng vào Ví dùng chung bằng Mã Chia Sẻ
CREATE OR ALTER PROCEDURE sp_Wallet_JoinByCode
    @AccountID INT,
    @MaChiaSe VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @WalletID INT = (SELECT TOP 1 ID FROM Wallet WHERE MaChiaSe = @MaChiaSe);

    IF @WalletID IS NULL
    BEGIN
        RAISERROR(N'Mã chia sẻ ví không hợp lệ!', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM WalletMember WHERE WalletID = @WalletID AND AccountID = @AccountID)
    BEGIN
        RAISERROR(N'Bạn đã là thành viên của ví này rồi!', 16, 1);
        RETURN;
    END

    INSERT INTO WalletMember (WalletID, AccountID, VaiTro)
    VALUES (@WalletID, @AccountID, N'Thành Viên');

    SELECT @WalletID AS WalletID, (SELECT TenVi FROM Wallet WHERE ID = @WalletID) AS TenVi;
END;
GO

-- Stored Procedure: Lấy danh sách ví của 1 người dùng
CREATE OR ALTER PROCEDURE sp_Wallet_GetByUser
    @AccountID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        w.ID AS WalletID,
        w.TenVi,
        w.LoaiVi,
        w.MaChiaSe,
        w.TienBanDau,
        wm.VaiTro,
        ISNULL((SELECT SUM(TienHienCo) FROM Tien WHERE WalletID = w.ID), w.TienBanDau) AS TienHienCo,
        (SELECT COUNT(*) FROM WalletMember WHERE WalletID = w.ID) AS SoThanhVien
    FROM Wallet w
    INNER JOIN WalletMember wm ON w.ID = wm.WalletID
    WHERE wm.AccountID = @AccountID
    ORDER BY w.ID ASC;
END;
GO

-- Stored Procedure: Cập nhật Tiền Ban Đầu cho Ví
CREATE OR ALTER PROCEDURE sp_Tien_SetInitialBalance
    @WalletID INT,
    @TienBanDau DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Wallet SET TienBanDau = @TienBanDau WHERE ID = @WalletID;
    
    -- Cập nhật lại Số Tiền Hiện Có = Tiền Ban Đầu + Tổng Thu - Tổng Chi
    DECLARE @TongThu DECIMAL(18,2) = ISNULL((SELECT SUM(Luong + Thuong + Khac) FROM ThuNhap WHERE WalletID = @WalletID), 0);
    DECLARE @TongChi DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID), 0);
    DECLARE @TienMoi DECIMAL(18,2) = @TienBanDau + @TongThu - @TongChi;

    UPDATE Tien SET TienHienCo = @TienMoi WHERE WalletID = @WalletID;
END;
GO

-- Stored Procedure: Thêm Khoản Chi Tiêu theo WalletID
CREATE OR ALTER PROCEDURE sp_ChiTieu_InsertV2
    @DanhMuc NVARCHAR(150),
    @SoTien DECIMAL(18,2),
    @NoiDung NVARCHAR(250),
    @Ngay DATE,
    @AccountID INT,
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ChiTieu (DanhMuc, SoTien, NoiDung, Ngay, AccountID, WalletID)
    VALUES (@DanhMuc, @SoTien, @NoiDung, @Ngay, @AccountID, @WalletID);

    UPDATE Tien 
    SET TienHienCo = TienHienCo - @SoTien 
    WHERE WalletID = @WalletID;
END;
GO

-- Stored Procedure: Thêm Khoản Thu Nhập theo WalletID
CREATE OR ALTER PROCEDURE sp_ThuNhap_InsertV2
    @Luong DECIMAL(18,2),
    @Thuong DECIMAL(18,2),
    @Khac DECIMAL(18,2),
    @Ngay DATE,
    @AccountID INT,
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ThuNhap (Luong, Thuong, Khac, Ngay, AccountID, WalletID)
    VALUES (@Luong, @Thuong, @Khac, @Ngay, @AccountID, @WalletID);

    DECLARE @TongThu DECIMAL(18,2) = @Luong + @Thuong + @Khac;
    UPDATE Tien 
    SET TienHienCo = TienHienCo + @TongThu 
    WHERE WalletID = @WalletID;
END;
GO

-- Stored Procedure: Xem Chi Tiêu theo WalletID
CREATE OR ALTER PROCEDURE sp_ChiTieu_SelectByWallet
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        c.ID,
        c.DanhMuc AS [Danh Mục],
        c.SoTien AS [Số Tiền],
        c.NoiDung AS [Nội Dung],
        c.Ngay AS [Ngày],
        a.TaiKhoan AS [Người Chi]
    FROM ChiTieu c
    LEFT JOIN Account a ON c.AccountID = a.ID
    WHERE c.WalletID = @WalletID
    ORDER BY c.Ngay DESC, c.ID DESC;
END;
GO

-- Stored Procedure: Xem Thu Nhập theo WalletID
CREATE OR ALTER PROCEDURE sp_ThuNhap_SelectByWallet
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        t.ID,
        t.Luong AS [Lương],
        t.Thuong AS [Thưởng],
        t.Khac AS [Thu Nhập Khác],
        (t.Luong + t.Thuong + t.Khac) AS [Tổng Thu],
        t.Ngay AS [Ngày],
        a.TaiKhoan AS [Người Nhập]
    FROM ThuNhap t
    LEFT JOIN Account a ON t.AccountID = a.ID
    WHERE t.WalletID = @WalletID
    ORDER BY t.Ngay DESC, t.ID DESC;
END;
GO

-- Stored Procedure: Báo cáo tài chính chuyên sâu cho 1 ví
CREATE OR ALTER PROCEDURE sp_BaoCaoChuyenSau
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TienBanDau DECIMAL(18,2) = ISNULL((SELECT TienBanDau FROM Wallet WHERE ID = @WalletID), 0);
    DECLARE @TongThu DECIMAL(18,2) = ISNULL((SELECT SUM(Luong + Thuong + Khac) FROM ThuNhap WHERE WalletID = @WalletID), 0);
    DECLARE @TongChi DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID), 0);
    DECLARE @TienHienCo DECIMAL(18,2) = @TienBanDau + @TongThu - @TongChi;
    DECLARE @ThangNayChi DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID AND MONTH(Ngay) = MONTH(GETDATE()) AND YEAR(Ngay) = YEAR(GETDATE())), 0);
    DECLARE @ThangNayThu DECIMAL(18,2) = ISNULL((SELECT SUM(Luong + Thuong + Khac) FROM ThuNhap WHERE WalletID = @WalletID AND MONTH(Ngay) = MONTH(GETDATE()) AND YEAR(Ngay) = YEAR(GETDATE())), 0);

    SELECT 
        @TienBanDau AS TienBanDau,
        @TienHienCo AS TienHienCo,
        @TongThu AS TongThu,
        @TongChi AS TongChi,
        (@TongThu - @TongChi) AS ThangDu,
        @ThangNayThu AS ThangNayThu,
        @ThangNayChi AS ThangNayChi;
END;
GO

-- Stored Procedure: Xem Danh Sách Khách Mời Hỷ Sự
CREATE OR ALTER PROCEDURE sp_XemDSKhachMoi
    @AccountID INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID,
        Ten AS [Tên],
        TienMung AS [Tiền Mừng],
        GhiChu AS [Ghi Chú],
        CASE 
            WHEN ThamGia = 1 THEN N'Có'
            ELSE N'Không'
        END AS [Tham Gia],
        DiaChi AS [Địa Chỉ]
    FROM DamCuoi
    WHERE @AccountID IS NULL OR AccountID = @AccountID;
END;
GO

-- Stored Procedure: Dự đoán chi tiêu & số ngày sống sót theo Burn Rate
CREATE OR ALTER PROCEDURE sp_DuDoanChiTieu
    @WalletID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TienHienCo DECIMAL(18,2);
    DECLARE @TienBanDau DECIMAL(18,2) = ISNULL((SELECT TienBanDau FROM Wallet WHERE ID = @WalletID), 0);
    DECLARE @TongThu DECIMAL(18,2) = ISNULL((SELECT SUM(Luong + Thuong + Khac) FROM ThuNhap WHERE WalletID = @WalletID), 0);
    DECLARE @TongChi DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID), 0);
    SET @TienHienCo = @TienBanDau + @TongThu - @TongChi;

    -- Tính số tiền chi trong 30 ngày gần nhất
    DECLARE @TongChi30Ngay DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID AND Ngay >= DATEADD(day, -30, GETDATE())), 0);
    DECLARE @BurnRateNgay DECIMAL(18,2) = @TongChi30Ngay / 30.0;

    DECLARE @SoNgayConLai INT = CASE WHEN @BurnRateNgay > 0 THEN CAST(@TienHienCo / @BurnRateNgay AS INT) ELSE 999 END;
    DECLARE @DuDoanCuoiThangChi DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @WalletID AND MONTH(Ngay) = MONTH(GETDATE()) AND YEAR(Ngay) = YEAR(GETDATE())), 0);
    DECLARE @NgayTrongThang INT = DAY(GETDATE());
    DECLARE @TongNgayThang INT = DAY(EOMONTH(GETDATE()));

    IF @NgayTrongThang > 0 AND @DuDoanCuoiThangChi > 0
    BEGIN
        SET @DuDoanCuoiThangChi = (@DuDoanCuoiThangChi / @NgayTrongThang) * @TongNgayThang;
    END

    SELECT 
        @TienHienCo AS TienHienCo,
        @BurnRateNgay AS ChiTrungBinhNgay,
        @SoNgayConLai AS SoNgayDuyTri,
        @DuDoanCuoiThangChi AS DuDoanChiCuoiThang;
END;
GO
