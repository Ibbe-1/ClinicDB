USE ClinicDB;
GO

SELECT p.FirstName, p.LastName, b.StartTid, b.Status
FROM Patienter p
JOIN Bokningar b ON p.PatientId = b.PatientId;
GO

SELECT b.Id, p.FirstName, pr.Namn AS Personal, b.StartTid, b.Status
FROM Bokningar b
JOIN Patienter p ON b.PatientId = p.PatientId
JOIN Personal pr ON b.PersonalId = pr.PersonalId;
GO

SELECT bp.BetalningId, p.FirstName, p.LastName, bp.Belopp, bp.Betalningsstatus
FROM Betalning bp
JOIN Patienter p ON bp.PatientId = p.PatientId;
GO

SELECT b.Id AS BokningId, p.FirstName, bp.Belopp, bp.Betalningsstatus
FROM Bokningar b
JOIN Betalning bp ON b.PatientId = bp.PatientId
JOIN Patienter p ON b.PatientId = p.PatientId;
GO


SELECT p.FirstName, p.LastName, COUNT(b.Id) AS AntalBokningar
FROM Patienter p
LEFT JOIN Bokningar b ON p.PatientId = b.PatientId
GROUP BY p.FirstName, p.LastName;
GO

SELECT p.FirstName, p.LastName, SUM(bp.Belopp) AS TotalBelopp
FROM Patienter p
LEFT JOIN Betalning bp ON p.PatientId = bp.PatientId
GROUP BY p.FirstName, p.LastName;
GO


SELECT b.Id, p.FirstName, pr.Namn AS Personal, b.StartTid
FROM Bokningar b
JOIN Patienter p ON b.PatientId = p.PatientId
JOIN Personal pr ON b.PersonalId = pr.PersonalId
WHERE b.Status = 'Inställd'
ORDER BY b.StartTid DESC;
GO


SELECT TOP 5 p.FirstName, p.LastName, COUNT(b.Id) AS AntalBokningar
FROM Patienter p
JOIN Bokningar b ON p.PatientId = b.PatientId
GROUP BY p.FirstName, p.LastName
ORDER BY AntalBokningar DESC;
GO
