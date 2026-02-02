using System;
using System.Linq;
using ClinicDB.Models;

namespace ClinicDB.Managers
{
    internal static class ClinicManager
    {
        public static void ShowMainMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Clinic Manager ===");
                Console.WriteLine("1. Patienter");
                Console.WriteLine("2. Personal");
                Console.WriteLine("3. Bokningar");
                Console.WriteLine("4. Betalningar");
                Console.WriteLine("5. Avsluta");
                Console.Write("Välj: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ShowPatientMenu(); break;
                    case "2": ShowStaffMenu(); break;
                    case "3": ShowBookingMenu(); break;
                    case "4": ShowPaymentMenu(); break;
                    case "5": exit = true; break;
                    default: Console.WriteLine("Ogiltigt val!"); break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nTryck på valfri tangent...");
                    Console.ReadKey();
                }
            }
        }

        // ---------------------- Patienter ----------------------
        private static void ShowPatientMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== Patienter ===");
                Console.WriteLine("1. Lista patienter");
                Console.WriteLine("2. Lägg till patient");
                Console.WriteLine("3. Radera patient");
                Console.WriteLine("4. Tillbaka");
                Console.Write("Välj: ");

                switch (Console.ReadLine())
                {
                    case "1": ListPatients(); break;
                    case "2": AddPatient(); break;
                    case "3": DeletePatient(); break;
                    case "4": back = true; break;
                    default: Console.WriteLine("Ogiltigt val!"); break;
                }

                if (!back) Console.ReadKey();
            }
        }

        private static void ListPatients()
        {
            try
            {
                using var db = new ClinicDbContext();
                var list = db.Patienters.ToList();
                Console.WriteLine("\nID\tNamn\tTelefon");
                foreach (var p in list)
                    Console.WriteLine($"{p.PatientId}\t{p.FirstName} {p.LastName}\t{p.PhoneNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid hämtning av patienter: " + ex.Message);
            }
        }

        private static void AddPatient()
        {
            Console.Write("Förnamn: "); string fn = Console.ReadLine();
            Console.Write("Efternamn: "); string ln = Console.ReadLine();
            Console.Write("Telefon: "); string phone = Console.ReadLine();

            try
            {
                using var db = new ClinicDbContext();
                db.Patienters.Add(new Patienter { FirstName = fn, LastName = ln, PhoneNumber = phone });
                db.SaveChanges();
                Console.WriteLine("Patient tillagd!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid tillägg av patient: " + ex.Message);
            }
        }

        private static void DeletePatient()
        {
            Console.Write("PatientID att ta bort: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID!");
                return;
            }

            try
            {
                using var db = new ClinicDbContext();
                var patient = db.Patienters.Find(id);
                if (patient != null)
                {
                    db.Patienters.Remove(patient);
                    db.SaveChanges();
                    Console.WriteLine("Patient borttagen!");
                }
                else Console.WriteLine("Patient hittades ej!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid borttagning: " + ex.Message);
            }
        }

        // ---------------------- Personal ----------------------
        private static void ShowStaffMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== Personal ===");
                Console.WriteLine("1. Lista personal");
                Console.WriteLine("2. Lägg till personal");
                Console.WriteLine("3. Radera personal");
                Console.WriteLine("4. Tillbaka");
                Console.Write("Välj: ");

                switch (Console.ReadLine())
                {
                    case "1": ListStaff(); break;
                    case "2": AddStaff(); break;
                    case "3": DeleteStaff(); break;
                    case "4": back = true; break;
                    default: Console.WriteLine("Ogiltigt val!"); break;
                }

                if (!back) Console.ReadKey();
            }
        }

        private static void ListStaff()
        {
            try
            {
                using var db = new ClinicDbContext();
                var list = db.Personals.ToList();
                Console.WriteLine("\nID\tNamn\tYrke\tTelefon");
                foreach (var s in list)
                    Console.WriteLine($"{s.PersonalId}\t{s.Namn}\t{s.Yrke}\t{s.Telefonnummer}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid hämtning av personal: " + ex.Message);
            }
        }

        private static void AddStaff()
        {
            Console.Write("Namn: "); string name = Console.ReadLine();
            Console.Write("Yrke: "); string job = Console.ReadLine();
            Console.Write("Telefon: "); string phone = Console.ReadLine();

            try
            {
                using var db = new ClinicDbContext();
                db.Personals.Add(new Personal { Namn = name, Yrke = job, Telefonnummer = phone });
                db.SaveChanges();
                Console.WriteLine("Personal tillagd!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid tillägg av personal: " + ex.Message);
            }
        }

        private static void DeleteStaff()
        {
            Console.Write("PersonalID att ta bort: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID!");
                return;
            }

            try
            {
                using var db = new ClinicDbContext();
                var staff = db.Personals.Find(id);
                if (staff != null)
                {
                    db.Personals.Remove(staff);
                    db.SaveChanges();
                    Console.WriteLine("Personal borttagen!");
                }
                else Console.WriteLine("Personal hittades ej!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid borttagning: " + ex.Message);
            }
        }

        // ---------------------- Bokningar ----------------------
        private static void ShowBookingMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== Bokningar ===");
                Console.WriteLine("1. Lista bokningar");
                Console.WriteLine("2. Lägg till bokning");
                Console.WriteLine("3. Radera bokning");
                Console.WriteLine("4. Tillbaka");
                Console.Write("Välj: ");

                switch (Console.ReadLine())
                {
                    case "1": ListBookings(); break;
                    case "2": AddBooking(); break;
                    case "3": DeleteBooking(); break;
                    case "4": back = true; break;
                    default: Console.WriteLine("Ogiltigt val!"); break;
                }

                if (!back) Console.ReadKey();
            }
        }

        private static void ListBookings()
        {
            try
            {
                using var db = new ClinicDbContext();
                var list = db.Bokningars.ToList();
                Console.WriteLine("\nID\tPatient\tPersonal\tStartTid\tStatus");
                foreach (var b in list)
                    Console.WriteLine($"{b.Id}\t{b.PatientId}\t{b.PersonalId}\t{b.StartTid}\t{b.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid hämtning av bokningar: " + ex.Message);
            }
        }

        private static void AddBooking()
        {
            if (!ReadInt("PatientID: ", out int pid)) return;
            if (!ReadInt("PersonalID: ", out int sid)) return;
            if (!ReadDate("StartTid (yyyy-MM-dd HH:mm): ", out DateTime start)) return;

            try
            {
                using var db = new ClinicDbContext();
                if (db.Patienters.Find(pid) == null) { Console.WriteLine("Patient finns ej!"); return; }
                if (db.Personals.Find(sid) == null) { Console.WriteLine("Personal finns ej!"); return; }

                db.Bokningars.Add(new Bokningar { PatientId = pid, PersonalId = sid, StartTid = start });
                db.SaveChanges();
                Console.WriteLine("Bokning tillagd!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid bokning: " + ex.Message);
            }
        }

        private static void DeleteBooking()
        {
            if (!ReadInt("BokningID att ta bort: ", out int id)) return;

            try
            {
                using var db = new ClinicDbContext();
                var b = db.Bokningars.Find(id);
                if (b != null)
                {
                    db.Bokningars.Remove(b);
                    db.SaveChanges();
                    Console.WriteLine("Bokning borttagen!");
                }
                else Console.WriteLine("Bokning hittades ej!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid borttagning: " + ex.Message);
            }
        }

        // ---------------------- Betalningar ----------------------
        private static void ShowPaymentMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== Betalningar ===");
                Console.WriteLine("1. Lista betalningar");
                Console.WriteLine("2. Lägg till betalning");
                Console.WriteLine("3. Ta bort betalning");
                Console.WriteLine("4. Tillbaka");
                Console.Write("Välj: ");

                switch (Console.ReadLine())
                {
                    case "1": ListPayments(); break;
                    case "2": AddPayment(); break;
                    case "3": DeletePayment(); break;
                    case "4": back = true; break;
                    default: Console.WriteLine("Ogiltigt val!"); break;
                }

                if (!back) Console.ReadKey();
            }
        }

        private static void ListPayments()
        {
            try
            {
                using var db = new ClinicDbContext();
                var list = db.Betalnings.ToList();
                Console.WriteLine("\nID\tPatient\tBelopp\tStatus\tDatum");
                foreach (var p in list)
                    Console.WriteLine($"{p.BetalningId}\t{p.PatientId}\t{p.Belopp}\t{p.Betalningsstatus}\t{p.Betalningsdatum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid hämtning av betalningar: " + ex.Message);
            }
        }

        private static void AddPayment()
        {
            if (!ReadInt("PatientID: ", out int pid)) return;
            if (!ReadDecimal("Belopp: ", out decimal amount)) return;

            Console.Write("Betalningssätt: ");
            string method = Console.ReadLine();

            try
            {
                using var db = new ClinicDbContext();
                if (db.Patienters.Find(pid) == null) { Console.WriteLine("Patient finns ej!"); return; }

                db.Betalnings.Add(new Betalning { PatientId = pid, Belopp = amount, Betalningssatt = method });
                db.SaveChanges();
                Console.WriteLine("Betalning tillagd!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid betalning: " + ex.Message);
            }
        }

        private static void DeletePayment()
        {
            if (!ReadInt("BetalningID att ta bort: ", out int id)) return;

            try
            {
                using var db = new ClinicDbContext();
                var p = db.Betalnings.Find(id);
                if (p != null)
                {
                    db.Betalnings.Remove(p);
                    db.SaveChanges();
                    Console.WriteLine("Betalning borttagen!");
                }
                else Console.WriteLine("Betalning hittades ej!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel vid borttagning: " + ex.Message);
            }
        }

        // ---------------------- Hjälpmetoder ----------------------
        private static bool ReadInt(string prompt, out int result)
        {
            Console.Write(prompt);
            if (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ogiltigt tal!");
                return false;
            }
            return true;
        }

        private static bool ReadDecimal(string prompt, out decimal result)
        {
            Console.Write(prompt);
            if (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ogiltigt tal!");
                return false;
            }
            return true;
        }

        private static bool ReadDate(string prompt, out DateTime result)
        {
            Console.Write(prompt);
            if (!DateTime.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Ogiltigt datum!");
                return false;
            }
            return true;
        }
    }
}
