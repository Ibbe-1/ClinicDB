USE ClinicDB;
GO

 --  1. Public View – Patienter (döljer PhoneNumber)
CREATE VIEW vw_PublicPatienter AS
SELECT 
    PatientId,
    FirstName,
    LastName,
    WaitingNumber,
    CreatedAt
FROM Patienter;
GO

--   2. Report View – Patientbokningar (antal bokningar per patient)

CREATE VIEW vw_PatientBokningStat AS
SELECT 
    p.PatientId,
    p.FirstName,
    p.LastName,
    COUNT(b.Id) AS AntalBokningar,
    SUM(CASE WHEN b.Status = 'Genomförd' THEN 1 ELSE 0 END) AS Genomförda,
    SUM(CASE WHEN b.Status = 'Bokad' THEN 1 ELSE 0 END) AS Kommande
FROM Patienter p
LEFT JOIN Bokningar b ON p.PatientId = b.PatientId
GROUP BY p.PatientId, p.FirstName, p.LastName;
GO
