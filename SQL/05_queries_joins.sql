-- 1. JOIN Patienter + Bokningar
SELECT p.Förnamn, p.Efternamn, b.StartTid, b.Status
FROM Patienter p
JOIN Bokningar b ON p.PatientId = b.PatientId;

-- 2. JOIN Personal + Bokningar
SELECT per.Namn, per.Yrke, b.StartTid, b.Status
FROM Personal per
JOIN Bokningar b ON per.PersonalId = b.PersonalId;

-- 3. JOIN Patienter + Betalning
SELECT p.Förnamn, p.Efternamn, b.Belopp, b.Betalningsstatus
FROM Patienter p
JOIN Betalning b ON p.PatientId = b.PatientId;

-- 4. JOIN alla tre
SELECT p.Förnamn, p.Efternamn, per.Namn AS PersonalNamn, bk.StartTid, bk.Status
FROM Bokningar bk
JOIN Patienter p ON bk.PatientId = p.PatientId
JOIN Personal per ON bk.PersonalId = per.PersonalId;

-- 5. GROUP BY Patienter, antal bokningar
SELECT p.Förnamn, p.Efternamn, COUNT(b.Id) AS AntalBokningar
FROM Patienter p
LEFT JOIN Bokningar b ON p.PatientId = b.PatientId
GROUP BY p.Förnamn, p.Efternamn;

-- 6. GROUP BY Personal, antal bokningar
SELECT per.Namn, COUNT(b.Id) AS AntalBokningar
FROM Personal per
LEFT JOIN Bokningar b ON per.PersonalId = b.PersonalId
GROUP BY per.Namn;

-- 7. WHERE + ORDER BY
SELECT * FROM Bokningar
WHERE Status = 'Bokad'
ORDER BY StartTid ASC;

-- 8. Rapportfråga: Patienter med total betalning
SELECT p.Förnamn, p.Efternamn, SUM(b.Belopp) AS TotalBetalning
FROM Patienter p
JOIN Betalning b ON p.PatientId = b.PatientId
GROUP BY p.Förnamn, p.Efternamn;
