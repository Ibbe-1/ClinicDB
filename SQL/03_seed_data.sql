-- ================= PATIENTER =================
SET IDENTITY_INSERT Patienter ON;

INSERT INTO Patienter (PatientId, Förnamn, Efternamn, Telefonnummer)
VALUES
(1, 'Alice', 'Andersson', '0701234567'),
(2, 'Björn', 'Berg', '0702345678'),
(3, 'Carla', 'Carlsson', '0703456789'),
(4, 'Simon', 'Dahl', '0704567890'),
(5, 'Eva', 'Ek', '0705678901'),
(6, 'Fredrik', 'Fors', '0706789012'),
(7, 'Gina', 'Gustavsson', '0707890123'),
(8, 'Henrik', 'Hansson', '0708901234'),
(9, 'Isabella', 'Ivarsson', '0709012345'),
(10, 'Jonas', 'Johansson', '0700123456');
-- ================= PERSONAL =================
INSERT INTO Personal (PersonalId, Namn, Yrke, Telefonnummer)
VALUES
(1, 'Anna Svensson', 'Läkare', '0731234567'),
(2, 'Björn Johansson', 'Sjuksköterska', '0732345678'),
(3, 'Carin Lind', 'Läkare', '0733456789'),
(4, 'David Nilsson', 'Sjuksköterska', '0734567890'),
(5, 'Erik Persson', 'Fysioterapeut', '0735678901'),
(6, 'Frida Olsson', 'Läkare', '0736789012');
-- ================= BOKNINGAR =================
INSERT INTO Bokningar (Id, PatientId, PersonalId, StartTid, Konummer, Status)
VALUES
(1, 1, 1, '2026-01-30 09:00', 1, 'Bokad'),
(2, 2, 2, '2026-01-30 10:00', 2, 'Bokad'),
(3, 3, 3, '2026-01-30 11:00', 3, 'Bokad'),
(4, 4, 4, '2026-01-30 12:00', 4, 'Bokad'),
(5, 5, 5, '2026-01-30 13:00', 5, 'Bokad'),
(6, 6, 1, '2026-01-30 14:00', 6, 'Bokad'),
(7, 7, 2, '2026-01-30 15:00', 7, 'Bokad'),
(8, 8, 3, '2026-01-30 16:00', 8, 'Bokad'),
(9, 9, 4, '2026-01-30 17:00', 9, 'Bokad');
-- ================= BETALNING =================
INSERT INTO Betalning (BetalningId, PatientId, Belopp, Betalningssatt, Betalningsstatus)
VALUES
(1, 1, 500, 'Kort', 'Betald'),
(2, 2, 300, 'Kontant','Betald'),
(3, 3, 450, 'Kort', 'Betald'),
(4, 4, 600, 'swish', 'Betald'),
(5, 5, 200, 'Kort', 'Betald'),
(6, 6, 350, 'Kort', 'Betald');
-- ================= KONUMMERSEKVENS =================
INSERT INTO KonummerSekven (MottagningId, Datum, SistaKonummer)
VALUES
(1, '2026-01-30', 25);
