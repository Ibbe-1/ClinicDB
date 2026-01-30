using ClinicDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8; // emojis
        using var context = new ClinicDbContext();

        while (true)
        {
            try
            {
                Console.Clear();
                SkrivMeny();

                string val = Console.ReadLine()?.Trim() ?? "";

                switch (val)
                {
                    case "1": ListaPatienter(context); break;
                    case "2": ListaPersonal(context); break;
                    case "3": SkapaBokning(context); break;
                    case "4": UppdateraStatus(context); break;
                    case "5": TaBortBokning(context); break;
                    case "6": VisaRapport(context); break;
                    case "7": VisaBetalningar(context); break;
                    case "8": Console.WriteLine("Avslutar programmet..."); return;
                    default:
                        Console.WriteLine("\nOgiltigt val! Tryck valfri knapp för att fortsätta...");
                        Console.ReadKey();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nEtt fel inträffade:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Tryck valfri knapp för att fortsätta...");
                Console.ReadKey();
            }
        }
    }

    static void SkrivMeny()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===================================");
        Console.WriteLine("          🎯 KLINIK                ");
        Console.WriteLine("===================================");
        Console.WriteLine("🩺   1. Lista patienter"); 
        Console.WriteLine("🧑‍⚕️  2. Lista personal");
        Console.WriteLine("📅  3. Skapa bokning");
        Console.WriteLine("🔄  4. Uppdatera bokningsstatus");
        Console.WriteLine("❌  5. Ta bort bokning");
        Console.WriteLine("📊  6. Visa rapport");
        Console.WriteLine("💰  7. Visa betalningar");
        Console.WriteLine("🚪  8. Avsluta");
        Console.WriteLine("-----------------------------------");
        Console.Write("Välj ett alternativ: ");
        Console.ResetColor();
    }

    // ================= LISTA =================
    static void ListaPatienter(ClinicDbContext context)
    {
        Console.Clear();

        // Hämta max 5 patienter, sorterade på ID
        var patienter = context.Patienters
                               .OrderBy(p => p.PatientId)
                               .Take(5)
                               .ToList();

        if (!patienter.Any())
        {
            Console.WriteLine("Inga patienter finns.");
        }
        else
        {
            Console.WriteLine("ID | Förnamn       | Efternamn    | KöNr");
            Console.WriteLine("-----------------------------------------");

            foreach (var p in patienter)
            {
                var förnamn = p.Förnamn.Length > 12 ? p.Förnamn.Substring(0, 12) : p.Förnamn;
                var efternamn = p.Efternamn.Length > 12 ? p.Efternamn.Substring(0, 12) : p.Efternamn;

                // ---------------- FIX ----------------
                // Hämta alla Konummer för patienten först
                var konummerLista = context.Bokningars
                                           .Where(b => b.PatientId == p.PatientId)
                                           .Select(b => b.Konummer)
                                           .ToList();

                // Ta det senaste, eller 0 om ingen bokning finns
                var senasteKonummer = konummerLista.Any() ? konummerLista.Max() : 0;
                // -------------------------------------

                Console.WriteLine($"{p.PatientId,-2} | {förnamn,-12} | {efternamn,-12} | {senasteKonummer,-4}");
            }

            // Om det finns fler än 5, visa en liten notis
            int total = context.Patienters.Count();
            if (total > 5);
                
        }

        Console.WriteLine("\nTryck valfri knapp för att återgå till menyn...");
        Console.ReadKey();
    }


    static void ListaPersonal(ClinicDbContext context)
    {
        Console.Clear();
        var personal = context.Personals.ToList();

        if (!personal.Any())
        {
            Console.WriteLine("Ingen personal finns.");
        }
        else
        {
            Console.WriteLine("ID | Namn           | Yrke");
            Console.WriteLine("----------------------------");
            foreach (var p in personal)
            {
                var namn = p.Namn.Length > 15 ? p.Namn.Substring(0, 15) : p.Namn;
                var yrke = p.Yrke.Length > 10 ? p.Yrke.Substring(0, 10) : p.Yrke;
                Console.WriteLine($"{p.PersonalId,-2} | {namn,-15} | {yrke,-10}");
            }
        }
        Console.WriteLine("\nTryck valfri knapp för att återgå till menyn...");
        Console.ReadKey();
    }

    // ================= CREATE =================
    static void SkapaBokning(ClinicDbContext context)
    {
        Console.Clear();
        Console.WriteLine("Skapa ny bokning");
        Console.WriteLine("----------------");

        Console.Write("Patient-ID: ");
        if (!int.TryParse(Console.ReadLine(), out int patientId))
        {
            Console.WriteLine("Felaktigt Patient-ID");
            Console.ReadKey();
            return;
        }

        Console.Write("Personal-ID: ");
        if (!int.TryParse(Console.ReadLine(), out int personalId))
        {
            Console.WriteLine("Felaktigt Personal-ID");
            Console.ReadKey();
            return;
        }

        var patient = context.Patienters.Find(patientId);
        var personal = context.Personals.Find(personalId);

        if (patient == null || personal == null)
        {
            Console.WriteLine("Patient eller personal finns inte");
            Console.ReadKey();
            return;
        }

        // Hämta senaste KöNummer för patienten +1
        // Hämta alla Konummer för patienten till minnet
        var konummerLista = context.Bokningars
                                   .Where(b => b.PatientId == patientId)
                                   .Select(b => b.Konummer)
                                   .ToList();

        // Ta Max + 1, eller 1 om inga bokningar finns
        int konummer = konummerLista.Any() ? konummerLista.Max() + 1 : 1;


        var bokning = new Bokningar
        {
            PatientId = patientId,
            PersonalId = personalId,
            StartTid = DateTime.Now,
            Konummer = konummer,
            Status = "Bokad",
            Skapad = DateTime.Now
        };

        context.Bokningars.Add(bokning);
        context.SaveChanges();

        Console.WriteLine($"\n✅ Bokning skapad med KöNummer {konummer}");
        Console.WriteLine("\nTryck valfri knapp för att återgå till menyn...");
        Console.ReadKey();
    }

    // ================= UPDATE =================
    static void UppdateraStatus(ClinicDbContext context)
    {
        Console.Clear();
        Console.Write("Boknings-ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Felaktigt ID");
            Console.ReadKey();
            return;
        }

        var bokning = context.Bokningars.Find(id);
        if (bokning == null)
        {
            Console.WriteLine("Bokning hittades ej");
            Console.ReadKey();
            return;
        }

        Console.Write("Ny status (Bokad / Avbokad / Klar): ");
        var status = Console.ReadLine()!;
        if (status != "Bokad" && status != "Avbokad" && status != "Klar")
        {
            Console.WriteLine("Ogiltig status");
            Console.ReadKey();
            return;
        }

        bokning.Status = status;
        context.SaveChanges();
        Console.WriteLine("Status uppdaterad");
        Console.WriteLine("\nTryck valfri knapp för att återgå till menyn...");
        Console.ReadKey();
    }

    // ================= DELETE =================
    static void TaBortBokning(ClinicDbContext context)
    {
        Console.Clear();
        Console.Write("Boknings-ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Felaktigt ID");
            Console.ReadKey();
            return;
        }

        var bokning = context.Bokningars.Find(id);
        if (bokning == null)
        {
            Console.WriteLine("Bokning hittades ej");
        }
        else
        {
            context.Bokningars.Remove(bokning);
            context.SaveChanges();
            Console.WriteLine("Bokning borttagen");
        }

        Console.WriteLine("\nTryck valfri knapp för att återgå till menyn...");
        Console.ReadKey();
    }

    // ================= RAPPORT =================
    static void VisaRapport(ClinicDbContext context)
    {
        Console.Clear();
        var rapport = context.Patienters
            .Select(p => new
            {
                PatientNamn = $"{p.Förnamn} {p.Efternamn}",
                Antal = context.Bokningars.Count(b => b.PatientId == p.PatientId)
            })
            .OrderByDescending(x => x.Antal)
            .ToList();

        foreach (var r in rapport)
        {
            Console.WriteLine($"Patient: {r.PatientNamn} – {r.Antal} bokningar");
        }

        Console.WriteLine("\nTryck valfri knapp för att återgå till menyn...");
        Console.ReadKey();
    }

    // ================= BETALNING =================
    static void VisaBetalningar(ClinicDbContext context)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("💰 Betalningar");
        Console.WriteLine("------------------------------");
        Console.ResetColor();

        var betalningar = context.Betalnings
                                .Include(b => b.Patient)
                                .ToList();

        if (!betalningar.Any())
        {
            Console.WriteLine("Inga betalningar finns.");
        }
        else
        {
            Console.WriteLine("Patient          | Belopp   | Betalningssätt      | Status");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var b in betalningar)
            {
                var namn = b.Patient != null ? $"{b.Patient.Förnamn} {b.Patient.Efternamn}" : "Okänd";
                var status = string.IsNullOrEmpty(b.Betalningsstatus) ? "Obetald" : b.Betalningsstatus;
                var betalningssatt = b.Betalningssatt.Length > 15 ? b.Betalningssatt.Substring(0, 15) : b.Betalningssatt;

                Console.WriteLine($"{namn,-15} | {b.Belopp,7} kr | {betalningssatt,-18} | {status}");
            }
        }

        Console.WriteLine("\nTryck valfri knapp för att återgå till menyn...");
        Console.ReadKey();
    }
}
