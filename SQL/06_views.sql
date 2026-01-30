-- ================= Public views =================
-- Patienter public view
IF OBJECT_ID('vw_Patienter_Public', 'V') IS NOT NULL
    DROP VIEW vw_Patienter_Public;
GO

CREATE VIEW vw_Patienter_Public AS
SELECT PatientId, Förnamn, Efternamn
FROM Patienter;
GO

-- Personal public view
IF OBJECT_ID('vw_Personal_Public', 'V') IS NOT NULL
    DROP VIEW vw_Personal_Public;
GO

CREATE VIEW vw_Personal_Public AS
SELECT PersonalId, Namn, Yrke
FROM Personal;
GO

-- ================= Rapport view =================
-- Rapport view: används i Console App
IF OBJECT_ID('vw_Bokningar_Rapport', 'V') IS NOT NULL
    DROP VIEW vw_Bokningar_Rapport;
GO

CREATE VIEW vw_Bokningar_Rapport AS
SELECT 
    b.Id AS BokningsId,
    p.Förnamn AS PatientFörnamn,
    p.Efternamn AS PatientEfternamn,
    per.Namn AS PersonalNamn,
    b.StartTid,
    b.Konummer,
    b.Status
FROM Bokningar b
JOIN Patienter p ON b.PatientId = p.PatientId
JOIN Personal per ON b.PersonalId = per.PersonalId;
GO
