-- ================= PATIENTER =================
-- CREATE
INSERT INTO Patienter (Förnamn, Efternamn, Telefonnummer) 
VALUES ('Karin', 'Karlsson', '0701112233');

-- READ
SELECT * FROM Patienter;

-- UPDATE
UPDATE Patienter
SET Telefonnummer = '0709998888'
WHERE Förnamn = 'Alice';

-- DELETE
DELETE FROM Patienter
WHERE Förnamn = 'Eva';

-- ================= PERSONAL =================
-- CREATE
INSERT INTO Personal (Namn, Yrke, Telefonnummer)
VALUES ('Lena Berg', 'Sjuksköterska', '0739998877');

-- READ
SELECT * FROM Personal;

-- UPDATE
UPDATE Personal
SET Yrke = 'Läkare'
WHERE Namn = 'Erik Persson';

-- DELETE
DELETE FROM Personal
WHERE Namn = 'David Nilsson';

-- ================= BOKNINGAR =================
-- CREATE
INSERT INTO Bokningar (PatientId, PersonalId, StartTid, Konummer, Status)
VALUES (1, 2, '2026-01-31 09:00', 6, 'Bokad');

-- READ
SELECT * FROM Bokningar;

-- UPDATE
UPDATE Bokningar
SET Status = 'Klar'
WHERE Id = 1;

-- DELETE
DELETE FROM Bokningar
WHERE Id = 5;
