USE ClinicDB;
GO

INSERT INTO Patienter (FirstName, LastName, WaitingNumber, PhoneNumber, CreatedAt) VALUES
('Anna', 'Larsson', 1, '0701111111', GETDATE()),
('Erik', 'Svensson', 2, '0702222222', GETDATE()),
('Maria', 'Johansson', 3, '0703333333', GETDATE()),
('Johan', 'Karlsson', 4, '0704444444', GETDATE()),
('Elin', 'Lindberg', 5, '0705555555', GETDATE());
GO

INSERT INTO Personal (Namn, Yrke, Telefonnummer) VALUES
('Dr. Johan Ek', 'Läkare', '0731000000'),
('Sofia Berg', 'Sjuksköterska', '0732000000'),
('Eva Lind', 'Receptionist', '0733000000');
GO


INSERT INTO Bokningar (PatientId, PersonalId, StartTid, Konummer, Status, Betyg, Skapad) VALUES
(1, 1, DATEADD(HOUR, -2, GETDATE()), 101, 'Genomförd', 5, GETDATE()),
(2, 2, DATEADD(HOUR, -1, GETDATE()), 102, 'Genomförd', 4, GETDATE()),
(3, 1, DATEADD(HOUR, 1, GETDATE()), 103, 'Bokad', NULL, GETDATE()),
(4, 2, DATEADD(HOUR, 3, GETDATE()), 104, 'Bokad', NULL, GETDATE()),
(5, 3, DATEADD(HOUR, 5, GETDATE()), 105, 'Bokad', NULL, GETDATE()),
(1, 1, DATEADD(DAY, -1, GETDATE()), 106, 'Genomförd', 5, GETDATE());
GO

INSERT INTO Betalning (PatientId, Belopp, Betalningsdatum, Betalningssatt, Betalningsstatus) VALUES
(1, 500, DATEADD(HOUR, -2, GETDATE()), 'Kort', 'Betald'),
(2, 450, DATEADD(HOUR, -1, GETDATE()), 'Swish', 'Betald'),
(1, 500, DATEADD(DAY, -1, GETDATE()), 'Kort', 'Betald');
GO


INSERT INTO KonummerSekven (MottagningId, Datum, SistaKonummer)
VALUES (1, CAST(GETDATE() AS DATE), 200);
GO
