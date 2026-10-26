namespace EduHub.Ch01.Domain;

/// <summary>Câu lạc bộ sinh viên.</summary>
public class Club
{
    // TODO: Guid Id, string Name, string Description, DateTime CreatedAt  (private set)
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    // TODO: danh sách thành viên: field private List<Member> + property IReadOnlyList<Member> Members
    //       (bên ngoài không được .Add() trực tiếp — phải đi qua AddMember)
    private List<Member> _members = [];
   public IReadOnlyList<Member> Members => _members; 
    // TODO: constructor PRIVATE + public static Club Create(string name, string description)
    private Club(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new Club(name.Trim(), description.Trim() ?? string.Empty);
    }
    // TODO: public void AddMember(Member member) — chặn null và thành viên trùng
    // TODO: public int MemberCount()
}
