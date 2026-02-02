namespace ClinicDB.Models;

public class Prescription
{
    public int PrescriptionId { get; set; }

    public int PersonalId { get; set; }

    public DateTime IssuedAt { get; set; }
    public DateTime? ValidUntil { get; set; }

    public string Status { get; set; } = null!; // Active/Cancelled/Expired

    public string? Notes { get; set; }
}
