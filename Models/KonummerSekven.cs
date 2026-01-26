using System;
using System.Collections.Generic;

namespace ClinicDB.Models;

public partial class KonummerSekven
{
    public int MottagningId { get; set; }

    public DateOnly Datum { get; set; }

    public int SistaKonummer { get; set; }
}
