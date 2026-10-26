\# IN4211 — Phát Triển Phần Mềm Hướng Đối Tượng



> \*\*Học phần:\*\* IN4211 — Phát triển phần mềm hướng đối tượng  

> \*\*Giảng viên hướng dẫn:\*\* ThS. Nguyễn Tuấn Kiệt  

> \*\*Sinh viên thực hiện:\*\* Nguyễn Huỳnh Phúc Thịnh  

> \*\*Mã số sinh viên:\*\* `0024417329`  

> \*\*Bài tập:\*\* Chương 1 — Phân tích yêu cầu và Domain Modeling EduHub (Đánh giá HĐ 1.3)



\---



\## 📌 1. Giới thiệu bài tập



Dự án \*\*EduHub\*\* là hệ thống quản lý câu lạc bộ và sự kiện sinh viên. Bài tập Chương 1 tập trung vào việc mô hình hóa miền bài toán (Domain Modeling) theo tư duy hướng đối tượng hiện đại và các nguyên tắc thiết kế sạch (Clean OOP):



\* \*\*Tính đóng gói (Encapsulation):\*\* Toàn bộ thuộc tính sử dụng `private set`, constructor để `private` ngăn chặn việc khởi tạo tùy tiện từ bên ngoài.

\* \*\*Mẫu khởi tạo Factory Method:\*\* Sử dụng phương thức tĩnh `Create(...)` kiểm tra chặt chẽ tính hợp lệ (Validation) ngay từ cổng vào, đảm bảo không bao giờ tồn tại thực thể ở trạng thái lỗi.

\* \*\*Bảo vệ bất biến (Invariants):\*\* Danh sách thành viên trong `Club` được bao bọc dưới dạng `IReadOnlyList<Member>`, chỉ có thể thêm mới thông qua phương thức nghiệp vụ `AddMember(...)` để chống trùng lặp.

\* \*\*Máy trạng thái (State Machine):\*\* Phiếu đăng ký `Registration` kiểm soát luồng trạng thái chặt chẽ: `Pending` $\\rightarrow$ `Confirmed` $\\rightarrow$ `Cancelled` (trạng thái hủy là cuối cùng, không thể kích hoạt lại).

\* \*\*Quy tắc điểm danh:\*\* Thực thể `CheckIn` chỉ cho phép tạo khi phiếu đăng ký đã ở trạng thái `Confirmed`.



\---



\## 🏛 2. Sơ đồ lớp (Class Diagram)



```mermaid

classDiagram

&#x20;   class Club {

&#x20;       +Guid Id

&#x20;       +string Name

&#x20;       +string Description

&#x20;       +DateTime CreatedAt

&#x20;       +IReadOnlyList\~Member\~ Members

&#x20;       +AddMember(Member)

&#x20;       +MemberCount() int

&#x20;   }

&#x20;   class Member {

&#x20;       +Guid Id

&#x20;       +string Name

&#x20;       +string Email

&#x20;       +string StudentCode

&#x20;       +DateTime JoinedAt

&#x20;       +bool IsActive()

&#x20;       +ToString() string

&#x20;   }

&#x20;   class Event {

&#x20;       +Guid Id

&#x20;       +Guid ClubId

&#x20;       +string Title

&#x20;       +DateTime Date

&#x20;       +int Capacity

&#x20;       +bool IsOnline

&#x20;       +HasCapacity(int) bool

&#x20;   }

&#x20;   class Registration {

&#x20;       +Guid Id

&#x20;       +Guid MemberId

&#x20;       +Guid EventId

&#x20;       +DateTime RegisteredAt

&#x20;       +string Status

&#x20;       +Confirm()

&#x20;       +Cancel()

&#x20;   }

&#x20;   class CheckIn {

&#x20;       +Guid Id

&#x20;       +Guid RegistrationId

&#x20;       +DateTime CheckedInAt

&#x20;       +string Method

&#x20;       +Summary() string

&#x20;   }



&#x20;   Club "\*" -- "\*" Member : chứa thành viên

&#x20;   Club "1" --> "\*" Event : tổ chức (ClubId)

&#x20;   Member "1" --> "\*" Registration : đăng ký (MemberId)

&#x20;   Event "1" --> "\*" Registration : tiếp nhận (EventId)

&#x20;   Registration "1" --> "0..1" CheckIn : xác nhận điểm danh (RegistrationId)

\## 🚀 3. Chaỵ chương trình

dotnet build starter/Ch01.Console/Ch01.Console.csproj

dotnet run --project starter/Ch01.Console/Ch01.Console.csproj

\## 📊 4. Kết quả thực thi thực tế (Console Output)

=== EduHub — Club \& Event Management ===



CLB vừa tạo: Tech Club — Câu lạc bộ công nghệ: workshop, hackathon, chia sẻ kiến thức.

\+ Đã thêm: Nguyễn Văn An DH24001

\+ Đã thêm: Trần Thị Bình DH24002

\+ Đã thêm: Lê Hoàng Cường DH24003

Tổng số thành viên trong CLB: 3



Sự kiện: Workshop AI — Ngày: 02/11/2026 14:00 — Sức chứa: 50

Nguyễn Văn An đăng ký thành công -> Trạng thái: Pending

Trần Thị Bình đăng ký thành công -> Trạng thái: Pending

Xác nhận phiếu cb43f3d0 -> Trạng thái mới: Confirmed

Xác nhận phiếu f78cc2c8 -> Trạng thái mới: Confirmed



Check-in 16:52:57 qua QrCode (phiếu cb43f3d0)



\--- BÁO CÁO THAM DỰ SỰ KIỆN ---

Số lượng đăng ký: 2/50

Số lượng đã check-in: 1

\- Nguyễn Văn An: ĐÃ CHECK-IN

\- Trần Thị Bình: CHƯA CHECK-IN



✅ Demo complete!

