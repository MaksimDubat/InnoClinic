namespace InnoClinic.AccountService.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public bool IsLinkedToAccount { get; set; } = false;
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
}
