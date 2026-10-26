namespace EduHub.Ch01.Domain;

/// <summary>Ghi nhận sự hiện diện thực tế của một Registration (quan hệ 1–1).</summary>
public class CheckIn
{
    // TODO: Guid Id, Guid RegistrationId, DateTime CheckedInAt, string Method ("Manual" hoặc "QrCode") (private set)
    public Guid Id { get; private set; }
    public Guid RegistrationId  { get; private set; }
    public DateTime CheckedInAt  { get; private set; }
    public string Method { get; private set; }
    public const string Manual = "Manual";
    public const string QrCode  = "QrCode";
    // TODO: constructor PRIVATE + public static CheckIn Create(Registration registration, string method)
    //       → chỉ cho phép khi registration.Status == Confirmed

    // TODO: public string Summary() — chuỗi mô tả để in báo cáo
    public string Sumary() => $"Check-in {CheckedInAt: HH:mm:ss} qua {Method} (phiếu {RegistrationId.ToString()[..8]})";
}
