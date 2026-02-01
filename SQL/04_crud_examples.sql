USE ClinicDB;
GO


-- CREATE (INSERT)
INSERT INTO Patienter (FirstName, LastName, WaitingNumber, PhoneNumber, CreatedAt)
VALUES ('Test', 'Patient', 99, '0709999999', GETDATE());

-- READ (SELECT)
SELECT * FROM Patienter WHERE LastName = 'Patient';

-- UPDATE
UPDATE Patienter
SET PhoneNumber = '0701234567'
WHERE LastName = 'Patient';

-- DELETE
DELETE FROM Patienter
WHERE LastName = 'Patient';
GO



-- CREATE
INSERT INTO Bokningar (PatientId, PersonalId, StartTid, Konummer, Status, Skapad)
VALUES (1, 1, DATEADD(HOUR, 1, GETDATE()), 201, 'Bokad', GETDATE());

-- READ
SELECT B.Id, P.FirstName, Pr.Namn, B.StartTid, B.Status
FROM Bokningar B
JOIN Patienter P ON B.PatientId = P.PatientId
JOIN Personal Pr ON B.PersonalId = Pr.PersonalId
WHERE B.Konummer = 201;

-- UPDATE
UPDATE Bokningar
SET Status = 'Genomförd', Betyg = 5
WHERE Konummer = 201;

-- DELETE
DELETE FROM Bokningar
WHERE Konummer = 201;
GO


-- CREATE
INSERT INTO Betalning (PatientId, Belopp, Betalningsdatum, Betalningssatt, Betalningsstatus)
VALUES (2, 350, GETDATE(), 'Swish', 'Betald');

-- READ
SELECT * FROM Betalning WHERE PatientId = 2;

-- UPDATE
UPDATE Betalning
SET Belopp = 400
WHERE PatientId = 2;

-- DELETE
DELETE FROM Betalning
WHERE PatientId = 2 AND Belopp = 400;
GO
