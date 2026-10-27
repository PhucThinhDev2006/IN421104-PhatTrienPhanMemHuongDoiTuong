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
    private CheckIn(Guid registrationId, string method)
    {
        Id = Guid.NewGuid();
        RegistrationId = registrationId;
        Method = method;
        CheckedInAt = DateTime.UtcNow;
    }

    public static CheckIn Create(Registration registration, string method = Manual)
    {
        ArgumentNullException.ThrowIfNull(registration);
        if (registration.Status != Registration.Confirmed)
        {
            throw new InvalidOperationException("Chỉ có phiếu đã Confirmed mới được check-in.");
        }

        if (method is not (Manual or QrCode))
        {
            throw new InvalidOperationException($"Hình thức không hợp lệ: {method}");
        }
        return new CheckIn(registration.Id, method);
    }
    // TODO: public string Summary() — chuỗi mô tả để in báo cáo
    public string Summary() => $"Check-in {CheckedInAt: HH:mm:ss} qua {Method} (phiếu {RegistrationId.ToString()[..8]})";
}
