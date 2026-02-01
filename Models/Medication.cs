namespace ClinicDB.Models;

public class Medication
{
    public int MedicationId { get; set; }
    public string Name { get; set; } = null!;
    public string? Strength { get; set; }  // ex "500 mg"
    public DateTime CreatedAt { get; set; }
}
