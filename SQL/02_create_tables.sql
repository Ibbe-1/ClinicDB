-- ================= PATIENTER =================
CREATE TABLE Patienter (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    Förnamn NVARCHAR(50) NOT NULL,
    Efternamn NVARCHAR(50) NOT NULL,
    Telefonnummer NVARCHAR(20) NULL,
    Skapad DATETIME DEFAULT GETDATE()
);

-- ================= PERSONAL =================
CREATE TABLE Personal (
    PersonalId INT IDENTITY(1,1) PRIMARY KEY,
    Namn NVARCHAR(100) NOT NULL,
    Yrke NVARCHAR(50) NOT NULL,
    Telefonnummer NVARCHAR(20) NULL
);

-- ================= KONUMMERSEKVENS =================
CREATE TABLE KonummerSekven (
    MottagningId INT NOT NULL,
    Datum DATE NOT NULL,
    SistaKonummer INT NOT NULL,
    PRIMARY KEY (MottagningId, Datum)
);

-- ================= BOKNINGAR =================
CREATE TABLE Bokningar (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    PersonalId INT NOT NULL,
    StartTid DATETIME NOT NULL,
    Konummer INT NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    Skapad DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Patienter(PatientId),
    FOREIGN KEY (PersonalId) REFERENCES Personal(PersonalId)
);

-- ================= BETALNING =================
CREATE TABLE Betalning (
    BetalningId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    Belopp DECIMAL(10,2) NOT NULL,
    Betalningsdatum DATETIME DEFAULT GETDATE(),
    Betalningssatt NVARCHAR(50) NOT NULL,
    Betalningsstatus NVARCHAR(30) DEFAULT 'Obetald'
    FOREIGN KEY (PatientId) REFERENCES Patienter(PatientId)
);
