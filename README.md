🏥 ClinicDB – Databasprojekt

ClinicDB är ett databassystem för en klinik, byggt i SQL Server och använt via en .NET Console App (Database First + LINQ).

Projektet innehåller databasdesign, testdata, SQL-queries, views, säkerhet och en menybaserad applikation.

📊 ER-Diagram

ERD visar alla tabeller, PK och relationer.
Se filen ClinicDB_ERD.pdf i repot.

Relationer:

Patienter 1 → M Bokningar

Personal 1 → M Bokningar

Patienter 1 → M Betalning

🗄️ Databas – Tabeller

Patienter (huvudtabell)
PatientId (PK), FirstName, LastName, WaitingNumber (UNIQUE), PhoneNumber, CreatedAt (DEFAULT)

Personal
PersonalId (PK), Namn, Yrke, Telefonnummer

Bokningar
Id (PK), PatientId (FK), PersonalId (FK), StartTid, Konummer, Status (DEFAULT 'Bokad'), Skapad (DEFAULT)

Betalning
BetalningId (PK), PatientId (FK), Belopp, Betalningsdatum (DEFAULT), Betalningssatt, Betalningsstatus (DEFAULT 'Obetald')

KonummerSekven
MottagningId (PK), Datum (PK)

📂 Projektstruktur
ClinicDB/
│
├── sql/
│   ├── 01_create_database.sql
│   ├── 02_create_tables.sql
│   ├── 03_seed_data.sql
│   ├── 04_crud_examples.sql
│   ├── 05_queries_joins.sql
│   ├── 06_views.sql
│   ├── 07_security.sql
│   └── 08_cleanup.sql
│
├── ClinicConsoleApp/
│   ├── Program.cs          # Meny och logik
│   ├── Models/             # Scaffoldade EF-modeller
│   └── ClinicDbContext.cs  # Databaskoppling
│
├── ClinicDB_ERD.pdf        # ER-diagram
└── README.md

📂 SQL-Filer
Fil	Innehåll
01_create_database.sql	Skapar databasen
02_create_tables.sql	Tabeller + PK/FK + constraints
03_seed_data.sql	Testdata
04_crud_examples.sql	CRUD-exempel
05_queries_joins.sql	Joins och rapportfrågor
06_views.sql	Public + Report view
07_security.sql	Roll och behörigheter
08_cleanup.sql	Rensa databasen
💻 Console App Funktioner

Lista patienter

Lista personal

Skapa bokning

Registrera betalning

Uppdatera bokningsstatus

Ta bort bokning

Rapportmeny (minst 2 rapporter)

📈 Exempel på rapporter

Patienter med flest bokningar

Antal bokningar per personal

Senaste aktiviteter

Obetalda betalningar

🚀 Starta projektet

Kör SQL-filerna i ordning (01–03, 06, 07)

Scaffolda modeller med EF Core

Kör Console Appen

✅ Krav uppfyllda

✔ 5+ tabeller
✔ PK & FK
✔ Constraints & DEFAULT
✔ ERD inlämnad
✔ SQL-struktur enligt krav
✔ Console App med CRUD & rapporter
