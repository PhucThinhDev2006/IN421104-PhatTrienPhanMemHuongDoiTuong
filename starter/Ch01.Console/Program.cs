using EduHub.Ch01.Domain;

// ═══════════════════════════════════════════════════════════════
//  EduHub Ch01 — Console demo (luồng nghiệp vụ đầy đủ)
//  Dùng hằng số cho separator, KHÔNG hardcode chuỗi lặp lại.
// ═══════════════════════════════════════════════════════════════

Console.WriteLine("=== EduHub — Club & Event Management ===");

// TODO 1: Tạo CLB "Tech Club" với mô tả phù hợp         → Club.Create(...)
var club = Club.Create("Tech Club", "Câu lạc bộ công nghệ: workshop, hackathon, chia sẻ kiến thức.");
Console.WriteLine($"\nCLB vừa tạo: {club.Name} — {club.Description}");
// TODO 2: Tạo 3 Member, thêm vào CLB                      → Member.Create(...), club.AddMember(...)
// TODO 2: Tạo 3 Member, thêm vào CLB
var members = new[]
{
    Member.Create("Nguyễn Văn An", "an.nv@student.dthu.edu.vn", "DH24001"),
    Member.Create("Trần Thị Bình", "binh.tt@student.dthu.edu.vn", "DH24002"),
    Member.Create("Lê Hoàng Cường", "cuong.lh@student.dthu.edu.vn", "DH24003")
};

foreach (var member in members)
{
    club.AddMember(member);
    Console.WriteLine($"+ Đã thêm: {member}");
}
Console.WriteLine($"Tổng số thành viên trong CLB: {club.MemberCount()}");
// TODO 3: Tạo sự kiện "Workshop AI", capacity = 50        → Event.Create(club.Id, ...)
var workshop = Event.Create(club.Id, "Workshop AI", DateTime.Today.AddDays(7).AddHours(14), 50);
Console.WriteLine($"\nSự kiện: {workshop.Title} — Ngày: {workshop.Date:dd/MM/yyyy HH:mm} — Sức chứa: {workshop.Capacity}");
// TODO 4: 2 Member đăng ký (kiểm tra HasCapacity) → Pending → gọi Confirm()
var registrations = new List<Registration>();
// Lấy 2 thành viên đầu tiên đăng ký
foreach (var member in members.Take(2))
{
    if (!workshop.HasCapacity(registrations.Count))
    {
        Console.WriteLine($"Hết chỗ, không nhận đăng ký cho {member}");
        continue;
    }
    var reg = Registration.Create(member.Id, workshop.Id);
    registrations.Add(reg);
    Console.WriteLine($"{member.Name} đăng ký thành công -> Trạng thái: {reg.Status}");
}
// Duyệt phiếu (Confirm)
foreach (var reg in registrations)
{
    reg.Confirm();
    Console.WriteLine($"Xác nhận phiếu {reg.Id.ToString()[..8]} -> Trạng thái mới: {reg.Status}");
}
// TODO 5: 1 Member check-in                               → CheckIn.Create(registration, ...)
// TODO 6: In báo cáo tham dự: số đăng ký, số check-in, danh sách tên

Console.WriteLine("\n✅ Demo complete!");
