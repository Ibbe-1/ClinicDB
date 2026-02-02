using System;
using System.Collections.Generic;

namespace ClinicDB.Models;

public partial class Bokningar
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int PersonalId { get; set; }

    public DateTime StartTid { get; set; }

    public int Konummer { get; set; }

    public string Status { get; set; } = null!;

    public DateTime Skapad { get; set; }

    public virtual Patienter Patient { get; set; } = null!;

    public virtual Personal Personal { get; set; } = null!;

    public virtual KonummerSekven KonummerSekvens { get; set; } = null!;
}
