namespace ClinicDB.Models;

public class Prescription
{
    public int PrescriptionId { get; set; }

    public int PersonalId { get; set; }
    public int StaffId { get; set; }   // läkare/sjuksköterska som skriver

    public DateTime IssuedAt { get; set; }
    public DateTime? ValidUntil { get; set; }

    public string Status { get; set; } = null!; // Active/Cancelled/Expired

    public string? Notes { get; set; }
}
