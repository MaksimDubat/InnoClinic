namespace InnoClinic.AccountService.Domain.Entities;

public class Office
{
    public int Id { get; set; }
    public string Address { get; set; } = null!;
    public int? PhotoId { get; set; }
    public Photo Photo { get; set; } = null!;
    public string RegistryPhoneNumber { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    public ICollection<Receptionist> Receptionists { get; set; } = new List<Receptionist>();
}
