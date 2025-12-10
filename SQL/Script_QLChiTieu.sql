CREATE DATABASE QL_ChiTieu;
GO

USE QL_ChiTieu;
GO

CREATE TABLE Account
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TaiKhoan VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(200) NOT NULL
);

CREATE TABLE Tien
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TienHienCo DECIMAL(18,2) NOT NULL DEFAULT 0,
    AccountID INT NOT NULL,
    FOREIGN KEY (AccountID) REFERENCES Account(ID)
);

CREATE TABLE ThuNhap
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Luong DECIMAL(18,2) DEFAULT 0,
    Thuong DECIMAL(18,2) DEFAULT 0,
    Khac DECIMAL(18,2) DEFAULT 0,
    Ngay DATE,
    AccountID INT NOT NULL,
    FOREIGN KEY (AccountID) REFERENCES Account(ID)
);

CREATE TABLE ChiTieu
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DanhMuc NVARCHAR(150) NOT NULL,
    SoTien DECIMAL(18,2) NOT NULL,
    NoiDung NVARCHAR(250),
    Ngay DATE,
    AccountID INT NOT NULL,
    FOREIGN KEY (AccountID) REFERENCES Account(ID)
);
go

CREATE TRIGGER trg_ThuNhap_Add
ON ThuNhap
AFTER INSERT
AS
BEGIN
    UPDATE Tien
    SET TienHienCo = Tien.TienHienCo 
                      + (INSERTED.Luong + INSERTED.Thuong + INSERTED.Khac)
    FROM Tien
    INNER JOIN INSERTED 
        ON Tien.AccountID = INSERTED.AccountID;
END;
go

CREATE TRIGGER trg_ChiTieu_Add
ON ChiTieu
AFTER INSERT
AS
BEGIN
    UPDATE Tien
    SET TienHienCo = Tien.TienHienCo - INSERTED.SoTien
    FROM Tien
    INNER JOIN INSERTED
        ON Tien.AccountID = INSERTED.AccountID;
END;
go 

CREATE TRIGGER trg_ThuNhap_Update
ON ThuNhap
AFTER UPDATE
AS
BEGIN
    UPDATE t
    SET t.TienHienCo = t.TienHienCo 
        + ((i.Luong + i.Thuong + i.Khac) 
        - (d.Luong + d.Thuong + d.Khac))
    FROM Tien t
    JOIN inserted i ON t.AccountID = i.AccountID
    JOIN deleted d ON d.ID = i.ID;
END;
GO

CREATE TRIGGER trg_ChiTieu_Update
ON ChiTieu
AFTER UPDATE
AS
BEGIN
    UPDATE t
    SET t.TienHienCo = t.TienHienCo 
        - (i.SoTien - d.SoTien)
    FROM Tien t
    JOIN inserted i ON t.AccountID = i.AccountID
    JOIN deleted d ON d.ID = i.ID;
END;
GO

CREATE TRIGGER trg_ThuNhap_Delete
ON ThuNhap
AFTER DELETE
AS
BEGIN
    UPDATE Tien
    SET TienHienCo = Tien.TienHienCo
                      - (DELETED.Luong + DELETED.Thuong + DELETED.Khac)
    FROM Tien
    INNER JOIN DELETED ON Tien.AccountID = DELETED.AccountID;
END;
GO

CREATE TRIGGER trg_ChiTieu_Delete
ON ChiTieu
AFTER DELETE
AS
BEGIN
    UPDATE Tien
    SET TienHienCo = Tien.TienHienCo + DELETED.SoTien
    FROM Tien
    INNER JOIN DELETED ON Tien.AccountID = DELETED.AccountID;
END;
GO

Exec sp_Account_Them @TaiKhoan ='TanHeo123',@MatKhau ='Admin123@'

go
CREATE PROCEDURE sp_Account_Check
    @TaiKhoan VARCHAR(50),
    @MatKhau VARCHAR(200)
AS
BEGIN
    SELECT ID, TaiKhoan
    FROM Account
    WHERE TaiKhoan = @TaiKhoan
      AND MatKhau = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2);
END;
GO

CREATE PROCEDURE sp_Account_Them
    @TaiKhoan VARCHAR(50),
    @MatKhau VARCHAR(200)
AS
BEGIN
    INSERT INTO Account (TaiKhoan, MatKhau)
    VALUES (
        @TaiKhoan,
        CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2)
    );

    INSERT INTO Tien (TienHienCo, AccountID)
    VALUES (0, SCOPE_IDENTITY());
END;
GO

CREATE PROCEDURE sp_Account_Sua
    @ID INT,
    @MatKhau VARCHAR(200)
AS
BEGIN
    UPDATE Account
    SET 
        MatKhau = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MatKhau), 2)
    WHERE ID = @ID;
END;
GO

CREATE PROCEDURE sp_Account_SelectAll
AS
BEGIN
    SELECT 
            ID,
            TaiKhoan as [Tài Khoản]
    FROM Account;
END;
go

CREATE PROCEDURE sp_ThuNhap_Insert
    @Luong DECIMAL(18,2),
    @Thuong DECIMAL(18,2),
    @Khac DECIMAL(18,2),
    @Ngay DATE,
    @AccountID INT
AS
BEGIN
    INSERT INTO ThuNhap (Luong, Thuong, Khac, Ngay, AccountID)
    VALUES (@Luong, @Thuong, @Khac, @Ngay, @AccountID);
END;
go

CREATE PROCEDURE sp_ThuNhap_Update
    @ID INT,
    @Luong DECIMAL(18,2),
    @Thuong DECIMAL(18,2),
    @Khac DECIMAL(18,2),
    @Ngay DATE
AS
BEGIN
    UPDATE ThuNhap
    SET Luong = @Luong,
        Thuong = @Thuong,
        Khac = @Khac,
        Ngay = @Ngay
    WHERE ID = @ID;
END;
go

CREATE PROCEDURE sp_ThuNhap_Delete
    @ID INT
AS
BEGIN
    DELETE FROM ThuNhap WHERE ID = @ID;
END;
go

Create PROCEDURE sp_ThuNhap_Select
    @AccountID INT
AS
BEGIN
    SELECT 
            ID,
            Luong as [Lương],
            Thuong as [Thưởng],
            Khac as [Thu Nhập Khác],
            Ngay as [Ngày]
    FROM ThuNhap WHERE AccountID = @AccountID ORDER BY Ngay DESC;
END;
go

CREATE PROCEDURE sp_ChiTieu_Insert
    @DanhMuc NVARCHAR(150),
    @SoTien DECIMAL(18,2),
    @NoiDung NVARCHAR(250),
    @Ngay DATE,
    @AccountID INT
AS
BEGIN
    INSERT INTO ChiTieu (DanhMuc, SoTien, NoiDung, Ngay, AccountID)
    VALUES (@DanhMuc, @SoTien, @NoiDung, @Ngay, @AccountID);
END;
go

CREATE PROCEDURE sp_ChiTieu_Update
    @ID INT,
    @DanhMuc NVARCHAR(150),
    @SoTien DECIMAL(18,2),
    @NoiDung NVARCHAR(250),
    @Ngay DATE
AS
BEGIN
    UPDATE ChiTieu
    SET DanhMuc = @DanhMuc,
        SoTien = @SoTien,
        NoiDung = @NoiDung,
        Ngay = @Ngay
    WHERE ID = @ID;
END;
go

CREATE PROCEDURE sp_ChiTieu_Delete
    @ID INT
AS
BEGIN
    DELETE FROM ChiTieu WHERE ID = @ID;
END;
go

CREATE PROCEDURE sp_ChiTieu_SelectByAccount
    @AccountID INT
AS
BEGIN
    SELECT * FROM ChiTieu WHERE AccountID = @AccountID ORDER BY Ngay DESC;
END;
go

CREATE PROCEDURE sp_ChiTieu_Xem
    @AccountID INT
AS
BEGIN
    SELECT 
        ID,
        DanhMuc as [Danh Mục],
        SoTien as [Số Tiền],
        NoiDung as [Nội Dung],
        Ngay as [Ngày]
    FROM ChiTieu
    WHERE AccountID = @AccountID
    ORDER BY Ngay DESC, ID DESC;
END;
GO

CREATE PROCEDURE sp_CanhBaoTieuTien
    @AccountID INT
AS
BEGIN
    DECLARE @TienHienCo DECIMAL(18,2) =
    (
        SELECT TienHienCo
        FROM Tien
        WHERE AccountID = @AccountID
    );

    -- Tổng chi từ đầu tháng đến hiện tại
    DECLARE @TongChi DECIMAL(18,2) =
    (
        SELECT ISNULL(SUM(SoTien), 0)
        FROM ChiTieu
        WHERE AccountID = @AccountID
          AND Ngay >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
          AND Ngay <= GETDATE()
    );

    -- Ngày hiện tại trong tháng
    DECLARE @SoNgay INT = DAY(GETDATE());

    -- Chi trung bình mỗi ngày
    DECLARE @TrungBinhNgay DECIMAL(18,2);

    IF @TongChi = 0 OR @SoNgay = 0
        SET @TrungBinhNgay = 0;
    ELSE
        SET @TrungBinhNgay = @TongChi / @SoNgay;

    -- Số ngày còn sống
    DECLARE @SoNgayCon DECIMAL(18,2);

    IF @TrungBinhNgay = 0
        SET @SoNgayCon = NULL; 
    ELSE
        SET @SoNgayCon = @TienHienCo / @TrungBinhNgay;

    -- Thông báo
    DECLARE @ThongBao NVARCHAR(200);

    IF @SoNgayCon IS NULL
        SET @ThongBao = N'Bạn chưa tiêu gì → không có nguy cơ hết tiền.';
    ELSE IF @SoNgayCon < 7
        SET @ThongBao = N'🔥 Nguy hiểm! Với mức chi hiện tại bạn sẽ hết tiền trong dưới 7 ngày.';
    ELSE IF @SoNgayCon < 15
        SET @ThongBao = N'⚠ Cảnh báo! Bạn chỉ còn tiền tiêu khoảng dưới 15 ngày nữa.';
    ELSE
        SET @ThongBao = N'✔ Mức tiêu hợp lý, chưa có nguy cơ hết tiền.';

    SELECT 
        @TienHienCo AS [Tiền Hiện Có],
        @TongChi AS [Tổng Chi],
        @TrungBinhNgay AS [Chi Trung Bình],
        @SoNgayCon AS [Số Ngày Hết Tiền],   
        @ThongBao AS [Cảnh Báo];
END;
GO

CREATE PROCEDURE sp_BaoCaoTongQuat
    @AccountID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE 
        @TongThu       DECIMAL(18,2),
        @ThuTB         DECIMAL(18,2),
        @ThuMax        DECIMAL(18,2),
        @ThuMin        DECIMAL(18,2),

        @TongChi       DECIMAL(18,2),
        @ChiTB         DECIMAL(18,2),
        @ChiMax        DECIMAL(18,2),
        @ChiMin        DECIMAL(18,2),

        @TienHienCo    DECIMAL(18,2);

    -- Thu
    SELECT 
        @TongThu = SUM(ISNULL(Luong,0)+ISNULL(Thuong,0)+ISNULL(Khac,0)),
        @ThuTB   = AVG(ISNULL(Luong,0)+ISNULL(Thuong,0)+ISNULL(Khac,0)),
        @ThuMax  = MAX(ISNULL(Luong,0)+ISNULL(Thuong,0)+ISNULL(Khac,0)),
        @ThuMin  = MIN(ISNULL(Luong,0)+ISNULL(Thuong,0)+ISNULL(Khac,0))
    FROM ThuNhap
    WHERE AccountID = @AccountID;

    -- Chi
    SELECT 
        @TongChi = SUM(SoTien),
        @ChiTB   = AVG(SoTien),
        @ChiMax  = MAX(SoTien),
        @ChiMin  = MIN(SoTien)
    FROM ChiTieu
    WHERE AccountID = @AccountID;

    -- Tiền hiện có
    SELECT @TienHienCo = TienHienCo
    FROM Tien
    WHERE AccountID = @AccountID;

    -- TRẢ VỀ 1 BẢNG DUY NHẤT
    SELECT
        @TongThu     AS TongThu,
        @ThuTB       AS ThuTrungBinh,
        @ThuMax      AS ThuNhieuNhat,
        @ThuMin      AS ThuItNhat,

        @TongChi     AS TongChi,
        @ChiTB       AS ChiTrungBinh,
        @ChiMax      AS ChiNhieuNhat,
        @ChiMin      AS ChiItNhat,

        @TienHienCo  AS TienHienCo;
END
GO

