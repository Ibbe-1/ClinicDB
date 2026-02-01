namespace ClinicDB.Models;

public class PrescriptionItem
{
    public int PrescriptionId { get; set; }
    public int MedicationId { get; set; }

    public string Dosage { get; set; } = null!;     // ex "1 tablett"
    public string Frequency { get; set; } = null!;  // ex "2 ggr/dag"
    public int Days { get; set; }                   // ex 10 dagar
}
