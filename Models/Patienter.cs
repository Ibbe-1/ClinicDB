using System;
using System.Collections.Generic;

namespace ClinicDB.Models;

public partial class Patienter
{
    public int PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int WaitingNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }
}
