public class Member
{
    public string Name { get; set; }
    public string MemberId { get; set; }

    public Member(string? name, string? memberId)  // تغییر `string` به `string?`
    {
        Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null");
        MemberId = memberId ?? throw new ArgumentNullException(nameof(memberId), "Member ID cannot be null");
    }
}
