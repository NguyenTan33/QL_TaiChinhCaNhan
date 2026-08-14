# 💎 HỆ THỐNG QUẢN LÝ TÀI CHÍNH CÁ NHÂN & GIA ĐÌNH TOÀN DIỆN
> **Personal & Family Financial Management System with AI Financial Advisor**  
> *Phát triển trên nền tảng C# WinForms (.NET 8.0) & Microsoft SQL Server*

---

## 🏆 Giới Thiệu Đồ Án

**Hệ Thống Quản Lý Tài Chính Cá Nhân & Gia Đình** là một giải pháp phần mềm toàn diện đóng vai trò như một **Sổ Thu Chi Thông Minh**, giúp người dùng ghi chép, theo dõi, lập ngân sách và phân tích dòng tiền hằng ngày một cách chuẩn chỉ, chính xác và chuyên nghiệp.

Đặc biệt, hệ thống tích hợp **Ví Gia Đình Dùng Chung**, **Trợ Lý AI Advisor**, **Cảnh Báo Ngân Sách 80% Tự Động**, và **Trung Tâm Phân Tích 6 Biểu Đồ Chuyên Sâu**.

![Báo cáo & Giao diện Dashboard](file:///C:/Users/minht/.gemini/antigravity/brain/84fca820-c40e-42bc-b7fe-3a5aaa038d1e/.user_uploaded/media_1786744466161.png)

---

## ✨ Các Tính Năng Đổi Mới Nổi Bật

### 1. 💼 Quản Lý Ví Cá Nhân & Ví Gia Đình Dùng Chung
- Mỗi tài khoản khởi tạo với một Ví Cá Nhân mặc định.
- Cho phép tạo **Ví Gia Đình** và sinh **Mã Chia Sẻ 6 Ký Tự** (VD: `W16954`). Thành viên trong gia đình chỉ cần nhập mã để dùng chung 1 ví, theo dõi mọi thu chi của tổ ấm.

### 2. 📝 Ghi Nhận Thu Nhập & Chi Tiêu Hằng Ngày
- Ghi nhận chi tiết các khoản chi theo danh mục (Ăn uống, Mua sắm, Di chuyển, Hóa đơn, Y tế, Giáo dục...).
- Cập nhật biến động số dư ví tức thì theo thời gian thực (Real-time Balance Update).

### 3. 🎯 Lập Ngân Sách & Cảnh Báo Tự Động 80% / 100%
- Thiết lập hạn mức chi tiêu cho từng danh mục theo tháng.
- **Tự động bật cảnh báo (Warning Alert)** khi khoản chi mới chạm mốc **>= 80%** hạn mức hoặc **>= 100%** (Vượt ngân sách).

### 4. 📈 Trung Tâm Phân Tích 6 Biểu Đồ & AI Insights
Màn hình phân tích chuyên sâu tích hợp **6 biểu đồ đồ họa** kèm khung **Nhận xét thông minh (AI Insights)** bên dưới từng biểu đồ:
1. 🍰 **Tỷ Trọng Chi Tiêu Theo Danh Mục**: Đánh giá danh mục ngốn tiền nhất.
2. 📈 **Xu Hướng Thu Nhập vs Chi Tiêu Theo Tháng**: Đo lường dòng tiền ròng & thặng dư tích lũy.
3. 🔥 **Tốc Độ Đốt Tiền (Burn Rate) & Số Ngày Sống Sót**: Dự đoán khả năng chịu đựng của ví.
4. 🎯 **Mức Độ Sử Dụng Ngân Sách**: Đối chiếu chi tiêu thực tế với hạn mức đặt ra.
5. ⚖️ **Phân Phối Dòng Tiền 50/30/20**: Đánh giá theo quy tắc tài chính quốc tế (50% Thiết yếu, 30% Sở thích, 20% Tiết kiệm).
6. 💎 **Hiệu Suất Đầu Tư & ROI (%)**: Tính toán Lãi/Lỗ và Tỷ suất sinh lời bình quân.

### 5. 💎 Theo Dõi Đầu Tư & Vay Nợ (Portfolio & Debt Tracking)
- **Tách biệt khỏi dòng tiền sinh hoạt hằng ngày**.
- **Quản lý Vay & Cho Mượn**: Theo dõi tiền cho mượn, đi vay, nợ thẻ tín dụng, tính lãi suất và nút bấm nút `✅ Đã Trả Nợ`.
- **Portfolio Đầu Tư**: Theo dõi Chứng khoán (mã CP), Vàng SJC, Bất động sản, Tiết kiệm, Crypto. Tự động tính **Tỷ suất sinh lời ROI (%)**.

### 6. 🎁 Sổ Hỷ Sự & Trả Lễ Độc Lập
- Sổ ghi chép mừng đám cưới / tiệc hỷ sự.
- Theo dõi danh sách khách mừng và trạng thái **"Đã Trả Lễ"** khi đi đáp lễ sau này mà **không làm sai lệch tiền ví sinh hoạt**.

### 7. 🔑 Khôi Phục Mật Khẩu (Forgot Password)
- Tìm lại mật khẩu thông qua **Câu Hỏi Bảo Mật**.
- Mã hóa mật khẩu an toàn chuẩn **SHA-256**.

### 8. 🤖 Trợ Lý AI Advisor Chatbox 24/7
- Chatbot tự động phân tích sức khỏe tài chính, đưa ra lời khuyên cắt giảm chi tiêu và gợi ý quy tắc tích lũy.

---

## 🛠️ Công Nghệ Sử Dụng

- **Ngôn ngữ lập trình**: C# (.NET 8.0 Windows Forms)
- **Cơ sở dữ liệu**: Microsoft SQL Server (Stored Procedures, Triggers, Foreign Keys)
- **Kiến trúc dữ liệu**: Data Access Layer (DAL) decoupled, Hashing SHA-256, Dynamic DataGridView Styling
- **Biểu đồ & Đồ họa**: Custom Visual Bar Chart Rendering (`████████`), Progress Indicators & Interactive Metric Cards

---

## 📂 Cấu Trúc Thư Mục Dự Án

```
QL_TaiChinh/
│
├── QL_TaiChinh/
│   ├── SQL/
│   │   ├── Script_QLChiTieu_v2.sql   # Script SQL v2 (Core Tables & Stored Procedures)
│   │   ├── Script_QLChiTieu_v3.sql   # Script SQL v3 (Forgot Password, Budget & HySu)
│   │   ├── Script_QLChiTieu_v4.sql   # Script SQL v4 (Investment & Debt Tracking)
│   │   └── Script_QLChiTieu_v5.sql   # Script SQL v5 (6 Analytics Procedures)
│   │
│   └── Bai_1/
│       ├── Form1.cs                  # Màn hình Đăng nhập / Đăng ký / Quên MK
│       ├── FormQuenMatKhau.cs        # Form Khôi phục mật khẩu
│       ├── Home Page.cs              # Trang chủ Dashboard tổng quan
│       ├── FormKhoiTaoVi.cs          # Form Khởi tạo ví & Ví gia đình dùng chung
│       ├── Chi_Tieu.cs               # Form Ghi chi tiêu & Cảnh báo 80%
│       ├── Thu_Nhap.cs               # Form Ghi thu nhập
│       ├── FormQuanLyNganSach.cs     # Form Quản lý hạn mức ngân sách
│       ├── FormBaoCaoTaiChinh.cs     # Form Báo cáo tài chính & Xuất CSV
│       ├── FormPhanTichDuLieu.cs     # Form 6 Biểu đồ phân tích chuyên sâu & AI Insights
│       ├── FormDauTuVayNo.cs         # Form Theo dõi Đầu tư & Vay nợ (ROI %)
│       ├── FormAIChatbox.cs          # Form AI Advisor Chatbox 24/7
│       ├── DSHySu.cs                 # Form Sổ Hỷ sự & Trả lễ
│       ├── DataModel.cs              # Lớp xử lý dữ liệu SQL & nghiệp vụ
│       └── AIAdvisorEngine.cs        # Động cơ phân tích tài chính AI
│
└── README.md                         # File hướng dẫn & giới thiệu đồ án
```

---

## 🚀 Hướng Dẫn Cài Đặt & Khởi Chạy

### Bước 1: Khởi Tạo Cơ Sở Dữ Liệu SQL Server
1. Mở **SQL Server Management Studio (SSMS)**.
2. Tạo CSDL tên `QL_ChiTieu` hoặc mở lần lượt các file script trong thư mục `SQL/`:
   - Run `Script_QLChiTieu_v2.sql`
   - Run `Script_QLChiTieu_v3.sql`
   - Run `Script_QLChiTieu_v4.sql`
   - Run `Script_QLChiTieu_v5.sql`

### Bước 2: Cấu Hình Chuỗi Kết Nối (Connection String)
Trong file [`DataModel.cs`](file:///d:/C%23/QL_TaiChinh/QL_TaiChinh/Bai_1/DataModel.cs), kiểm tra chuỗi kết nối SQL Server:
```csharp
string chietNoi = "Data Source=localhost;Initial Catalog=QL_ChiTieu;Integrated Security=True;TrustServerCertificate=True";
```

### Bước 3: Biên Dịch & Chạy Dự Án
Sử dụng `.NET CLI` hoặc Visual Studio để build và chạy:
```bash
dotnet build QL_TaiChinh/Bai_1/Bai_1.csproj
dotnet run --project QL_TaiChinh/Bai_1/Bai_1.csproj
```

---

## 👨‍💻 Tác Giả & Bản Quyền
- **Đồ án**: Quản Lý Tài Chính Cá Nhân & Gia Đình
- **Phiên bản**: Ver 3.0 (Full Features + AI Advisor + 6 Analytics Charts + Investment & Debt Tracking)
