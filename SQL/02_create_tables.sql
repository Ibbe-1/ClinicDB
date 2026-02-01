USE ClinicDB;
GO

CREATE TABLE Patienter (
    PatientId INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    WaitingNumber INT NOT NULL,
    PhoneNumber NVARCHAR(20),
    CreatedAt DATETIME
);
GO

CREATE TABLE Personal (
    PersonalId INT IDENTITY PRIMARY KEY,
    Namn NVARCHAR(100) NOT NULL,
    Yrke NVARCHAR(50) NOT NULL,
    Telefonnummer NVARCHAR(20)
);
GO

CREATE TABLE Betalning (
    BetalningId INT IDENTITY PRIMARY KEY,
    PatientId INT NOT NULL,
    Belopp DECIMAL(10,2) NOT NULL,
    Betalningsdatum DATETIME NOT NULL,
    Betalningssatt NVARCHAR(50) NOT NULL,
    Betalningsstatus NVARCHAR(50)
        CHECK (Betalningsstatus IN ('Betald','Obetald')) NOT NULL,
    FOREIGN KEY (PatientId) REFERENCES Patienter(PatientId)
);
GO

CREATE TABLE Bokningar (
    Id INT IDENTITY PRIMARY KEY,
    PatientId INT NOT NULL,
    PersonalId INT NOT NULL,
    StartTid DATETIME NOT NULL,
    Konummer INT NOT NULL,
    Status NVARCHAR(50)
        CHECK (Status IN ('Bokad','Genomförd','Inställd')) NOT NULL,
    Betyg INT
        CHECK (Betyg BETWEEN 1 AND 5 OR Betyg IS NULL),
    Skapad DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Patienter(PatientId),
    FOREIGN KEY (PersonalId) REFERENCES Personal(PersonalId)
);
GO


CREATE TABLE KonummerSekven (
    MottagningId INT PRIMARY KEY,
    Datum DATE NOT NULL,
    SistaKonummer INT NOT NULL
);
GO
