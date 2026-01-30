using System;
using System.Collections.Generic;

namespace ClinicDB.Models;

public partial class Patienter
{
    public int PatientId { get; set; }

    public string Förnamn { get; set; } = null!;

    public string Efternamn { get; set; } = null!;

    public string? Telefonnummer { get; set; }

    public DateTime? Skapad { get; set; }

    public virtual ICollection<Betalning> Betalnings { get; set; } = new List<Betalning>();

    public virtual ICollection<Bokningar> Bokningars { get; set; } = new List<Bokningar>();
}
