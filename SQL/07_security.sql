-- Skapa roll
CREATE ROLE KlinikReader;

-- Skapa användare
CREATE USER KlinikUser WITHOUT LOGIN;

-- Lägg användare i roll
EXEC sp_addrolemember 'KlinikReader', 'KlinikUser';

-- Grant SELECT på views
GRANT SELECT ON vw_Patienter_Public TO KlinikReader;
GRANT SELECT ON vw_Personal_Public TO KlinikReader;
GRANT SELECT ON vw_Bokningar_Rapport TO KlinikReader;
