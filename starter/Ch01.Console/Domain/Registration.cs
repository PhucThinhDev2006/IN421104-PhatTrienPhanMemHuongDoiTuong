namespace EduHub.Ch01.Domain;

/// <summary>Phiếu đăng ký của Member cho Event (bảng nối M:N).</summary>
public class Registration
{
    // TODO: Guid Id, Guid MemberId, Guid EventId, DateTime RegisteredAt, string Status (private set)
    public Guid Id  { get; private set; }
    public Guid MemberId  { get; private set; }
    public Guid EventId   { get; private set; }
    public DateTime RegisteredAt  { get; private set; }
    public string Status   { get; private set; }
    // TODO: hằng số cho Status: "Pending" / "Confirmed" / "Cancelled" (static class hoặc const) — không dùng magic string
    public const string Pending = "Pending";
    public const string Confirmed = "Confirmed";
    public const string Cancelled = "Cancelled";
    // TODO: constructor PRIVATE + public static Registration Create(Guid memberId, Guid eventId)
    //       → Status khởi tạo = Pending

    // TODO: public void Confirm() — chỉ hợp lệ khi Pending, sai thì throw InvalidOperationException
    // TODO: public void Cancel()  — hợp lệ khi Pending/Confirmed; đã Cancelled thì throw
}
