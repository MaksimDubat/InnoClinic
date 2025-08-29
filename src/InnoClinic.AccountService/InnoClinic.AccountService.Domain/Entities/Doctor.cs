namespace InnoClinic.AccountService.Domain.Entities;

public class Doctor
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public int? SpecializationId { get; set; }
    public Specialization? Specialization { get; set; }
    public int? OfficeId { get; set; }
    public Office? Office { get; set; }
    public int CareerStartYear { get; set; }
    public string Status { get; set; } = null!;
}
