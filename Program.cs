using System;
using System.Linq;
using ClinicDB.Models;

class Program
{
    static ClinicDbContext db = new ClinicDbContext();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== CLINIC DB ===");
            Console.WriteLine("1. List Patients");
            Console.WriteLine("2. List Staff");
            Console.WriteLine("3. Create Booking");
            Console.WriteLine("4. Add Payment");
            Console.WriteLine("5. Update Booking Grade (IG/G)");
            Console.WriteLine("6. Delete Booking");
            Console.WriteLine("7. Reports");
            Console.WriteLine("0. Exit");

            switch (Console.ReadLine())
            {
                case "1": ListPatients(); break;
                case "2": ListStaff(); break;
                case "3": CreateBooking(); break;
                case "4": AddPayment(); break;
                case "5": UpdateGrade(); break;
                case "6": DeleteBooking(); break;
                case "7": ReportsMenu(); break;
                case "0": return;
            }
        }
    }

    // 1️⃣ List main entity
    static void ListPatients()
    {
        foreach (var p in db.Patienters)
            Console.WriteLine($"{p.PatientId}: {p.FirstName} {p.LastName}");
        Pause();
    }

    // 2️⃣ List secondary entity
    static void ListStaff()
    {
        foreach (var s in db.Personals)
            Console.WriteLine($"{s.PersonalId}: {s.Namn} ({s.Yrke})");
        Pause();
    }

    // 3️⃣ Create relation (Patient + Staff → Booking)
    static void CreateBooking()
    {
        Console.Write("Patient ID: ");
        int pid = int.Parse(Console.ReadLine());
        Console.Write("Staff ID: ");
        int sid = int.Parse(Console.ReadLine());

        db.Bokningars.Add(new Bokningar
        {
            PatientId = pid,
            PersonalId = sid,
            StartTid = DateTime.Now,
            Status = "Bokad"
        });

        db.SaveChanges();
        Pause();
    }

    // 4️⃣ Create transaction (Payment)
    static void AddPayment()
    {
        Console.Write("Patient ID: ");
        int pid = int.Parse(Console.ReadLine());
        Console.Write("Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        db.Betalnings.Add(new Betalning
        {
            PatientId = pid,
            Belopp = amount,
            Betalningssatt = "Kort",
            Betalningsstatus = "Betald",
            Betalningsdatum = DateTime.Now
        });

        db.SaveChanges();
        Pause();
    }

    // 5️⃣ Update grade IG/G
    static void UpdateGrade()
    {
        Console.Write("Booking ID: ");
        int id = int.Parse(Console.ReadLine());
        var b = db.Bokningars.Find(id);
        if (b == null) return;

        Console.Write("Grade (IG=0, G=1): ");
        int grade = int.Parse(Console.ReadLine());

        if (grade == 0 || grade == 1)
        {
            b.Betyg = grade;
            db.SaveChanges();
        }
        Pause();
    }

    // 6️⃣ Delete record
    static void DeleteBooking()
    {
        Console.Write("Booking ID: ");
        int id = int.Parse(Console.ReadLine());
        var b = db.Bokningars.Find(id);
        if (b != null)
        {
            db.Bokningars.Remove(b);
            db.SaveChanges();
        }
        Pause();
    }

    // 7️⃣ Reports
    static void ReportsMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Top Patients (Most Bookings)");
        Console.WriteLine("2. Bookings per Staff");
        Console.WriteLine("0. Back");

        switch (Console.ReadLine())
        {
            case "1": TopPatients(); break;
            case "2": BookingsPerStaff(); break;
        }
    }

    static void TopPatients()
    {
        var r = db.Bokningars
            .GroupBy(b => b.PatientId)
            .Select(g => new { PatientId = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);

        foreach (var x in r)
            Console.WriteLine($"Patient {x.PatientId} - {x.Count} bookings");
        Pause();
    }

    static void BookingsPerStaff()
    {
        var r = db.Bokningars
            .GroupBy(b => b.PersonalId)
            .Select(g => new { StaffId = g.Key, Count = g.Count() });

        foreach (var x in r)
            Console.WriteLine($"Staff {x.StaffId} - {x.Count} bookings");
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
