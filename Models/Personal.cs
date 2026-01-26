using System;
using System.Collections.Generic;

namespace ClinicDB.Models;

public partial class Personal
{
    public int PersonalId { get; set; }

    public string Namn { get; set; } = null!;

    public string Yrke { get; set; } = null!;

    public string? Telefonnummer { get; set; }

    public virtual ICollection<Bokningar> Bokningars { get; set; } = new List<Bokningar>();
}
