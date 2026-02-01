USE ClinicDB;
GO

-- Ta bort vyer
DROP VIEW IF EXISTS vw_PublicPatienter;
DROP VIEW IF EXISTS vw_PatientBokningStat;
GO

-- Ta bort tabeller
DROP TABLE IF EXISTS Betalning;
DROP TABLE IF EXISTS Bokningar;
DROP TABLE IF EXISTS Personal;
DROP TABLE IF EXISTS Patienter;
DROP TABLE IF EXISTS KonummerSekven;
GO

-- Ta bort databasen
USE master;
GO
DROP DATABASE IF EXISTS ClinicDB;
GO
