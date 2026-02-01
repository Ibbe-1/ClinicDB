USE ClinicDB;
GO
-- skapa roll
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'reportReader')
    CREATE ROLE reportReader;
GO


--   Skapa användare

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'reportUser')
    CREATE USER reportUser WITHOUT LOGIN;
GO

-- lägg användare till roll
ALTER ROLE reportReader ADD MEMBER reportUser;
GO

-- ge behörigheter
GRANT SELECT ON vw_PublicPatienter TO reportReader;
GRANT SELECT ON vw_PatientBokningStat TO reportReader;
GO
