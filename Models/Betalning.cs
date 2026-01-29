using System;

namespace ClinicDB.Models
{
    public partial class Betalning
    {
        public int BetalningId { get; set; }
        public int PatientId { get; set; }
        public decimal Belopp { get; set; }
        public DateTime Betalningsdatum { get; set; }
        public string Betalningssatt { get; set; } = null!;
        public string Betalningsstatus { get; set; } = null!;

        // Koppling till patient
        public virtual Patienter Patient { get; set; } = null!;
    }
}
